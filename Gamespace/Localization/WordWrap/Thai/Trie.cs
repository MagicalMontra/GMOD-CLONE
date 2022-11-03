using System;
using System.Linq;
using System.Text;
using Zenject;

namespace Gamespace.Localization
{
    public class Trie : IInitializable
    {
        private Trie _parent;
        private Trie[] _childs = new Trie[1];
        private int _numChildren;
        private char _character;
        private bool _isWord;

        //Creates a Trie using the root symbol as the character
        private void Initialize(char c)
        {
            _character = c;
        }
        public void Initialize()
        {
            _character = (char)251;
        }
        //Used to create the trie nodes when a string is added to a trie
        private Trie CreateNode(char c)
        {
            var newTrie = new Trie();
            newTrie.Initialize(c);
            return newTrie;
        }

        //Inserts the trie as the last child
        private void AddChild(Trie t)
        {
            InsertChild(t, _numChildren);
        }

        //Inserts the trie at the specified index.  
        // If successful, the parent of the specified trie is updated to be this trie.
        private void InsertChild(Trie t, int index)
        {
            if (index < 0 || index > _numChildren)
                throw new ArgumentException("required: index >= 0 && index <= numChildren");
            if (t == null)
                throw new ArgumentException("cannot add null child");
            if (t._parent != null)
                throw new ArgumentException("specified child still belongs to parent");
            if (HasChar(t._character))
                throw new ArgumentException("duplicate chars not allowed");
            if (IsDescendent(t))
                throw new ArgumentException("cannot add cyclic reference");

            t._parent = this;

            if (_numChildren == _childs.Length)
            {
                Trie[] arr = new Trie[2 * (_numChildren + 1)];
                
                for (int i = 0; i < _numChildren; i++)
                    arr[i] = _childs[i];
                
                _childs = arr;
            }

            for (int i = _numChildren; i > index; i--)
                _childs[i] = _childs[i - 1];
            
            _childs[index] = t;
            _numChildren++;
        }

        //Returns true if this node is a descendent of the specified node or this node and the specified
        //node are the same node, false otherwise.
        private bool IsDescendent(Trie t)
        {
            var r = this;
            while (r != null)
            {
                if (r == t)
                    return true;
                
                r = r._parent;
            }
            return false;
        }

        //End of tree-level operations.  Start of string operations.
        //Adds the string to the trie.  Returns true if the string is added or false if the string
        //is already contained in the trie.

        public bool Add(String s)
        {
            return Add(s, 0);
        }
        private bool Add(String s, int index)
        {
            if (index == s.Length)
            {
                if (_isWord)
                {
                    return false;
                }
                _isWord = true;
                return true;
            }
            char c = s[index]; //char c=s.charAt(index);
            for (int i = 0; i < _numChildren; i++)
            {
                if (_childs[i]._character == c)
                {
                    return _childs[i].Add(s, index + 1);
                }
            }
            // this code adds from the bottom to the top because the addChild method
            // checks for cyclic references.  This prevents quadratic runtime.
            int ii = s.Length - 1;
            Trie t = CreateNode(s[ii--]);
            t._isWord = true;
            while (ii >= index)
            {
                Trie n = CreateNode(s[ii--]);
                n.AddChild(t);
                t = n;
            }
            AddChild(t);
            return true;
        }

        //Returns the child that has the specified character or null if no child has the specified character.
        public Trie GetNode(char c)
        {
            for (int i = 0; i < _numChildren; i++)
            {
                if (_childs[i]._character == c)
                {
                    return _childs[i];
                }
            }
            return null;
        }

        //Returns the last trie in the path that prefix matches the specified prefix string
        //rooted at this node, or null if there is no such prefix path.
        private Trie GetNode(String prefix)
        {
            return GetNode(prefix, 0);
        }

        private Trie GetNode(String prefix, int index)
        {
            if (index == prefix.Length)
            {
                return this;
            }
            char c = prefix[index]; //char c=prefix.charAt(index);
            for (int i = 0; i < _numChildren; i++)
            {
                if (_childs[i]._character == c)
                {
                    return _childs[i].GetNode(prefix, index + 1);
                }
            }
            return null;
        }

        //Returns the number of nodes that define isWord as true, starting at this node and including
        //all of its descendents.  This operation requires traversing the tree rooted at this node.
        private int Size()
        {
            int size = 0;
            if (_isWord)
            {
                size++;
            }
            for (int i = 0; i < _numChildren; i++)
            {
                size += _childs[i].Size();
            }
            return size;
        }

        //Returns all of the words in the trie that begin with the specified prefix rooted at this node.
        //An array of length 0 is returned if there are no words that begin with the specified prefix.
        public string[] GetWords(String prefix)
        {
            Trie n = GetNode(prefix);
            if (n == null)
            {
                return new String[0];
            }
            String[] arr = new String[n.Size()];
            n.GetWords(arr, 0);
            return arr;
        }

        private int GetWords(String[] arr, int x)
        {
            if (_isWord)
            {
                arr[x++] = base.ToString();
            }
            for (int i = 0; i < _numChildren; i++)
            {
                x = _childs[i].GetWords(arr, x);
            }
            return x;
        }

        //Returns true if the specified string has a prefix path starting at this node.
        //Otherwise false is returned.
        public bool HasPrefix(String s)
        {
            Trie t = GetNode(s);
            if (t == null)
            {
                return false;
            }
            return true;
        }

        //Check if the specified string is in the trie
        //Retrun value if contains, 0 if hasPrefix, else -1
        public int Contains(String s)
        {
            Trie t = GetNode(s);
            if (t == null)
            {
                return -1;
            }
            if (t._isWord)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //Returns true if this node has a child with the specified character.
        private bool HasChar(char c)
        {
            for (int i = 0; i < _numChildren; i++)
            {
                if (_childs[i]._character == c)
                {
                    return true;
                }
            }
            return false;
        }

        //Returns the number of nodes from this node up to the root node.  The root node has height 0.
        private int GetHeight()
        {
            int h = -1;
            Trie t = this;
            while (t != null)
            {
                h++;
                t = t._parent;
            }
            return h;
        }

        //Returns a string containing the characters on the path from this node to the root, but
        //not including the root character.  The last character in the returned string is the
        //character at this node.

        public string ToString()
        {
            StringBuilder sb = new StringBuilder(GetHeight());
            Trie t = this;
            while (t._parent != null)
            {
                sb.Append(t._character);
                t = t._parent;
            }
            return new string(sb.ToString().ToCharArray().Reverse().ToArray());
        }
        // End 
    }
}