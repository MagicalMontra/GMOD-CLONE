using System;
using System.Collections;
using System.IO;
using Zenject;

namespace Gamespace.Localization
{
    public class LexitronDictionary : IDictionary
    {
        public int first => 0;
        public int next => (short) _enumerator.Current;
        public bool hasNext => _enumerator.MoveNext();

        public ArrayList lineList => _lineList;
        public ArrayList typeList => _typeList;
        public ArrayList indexList => _indexList;

        [Inject] private Trie _trie;
        [Inject] private LongParseTree _longParseTree;
        
        private ArrayList _lineList;
        private ArrayList _typeList;
        private ArrayList _indexList;
        private IEnumerator _enumerator;
        public void Initialize(StreamReader input)
        {
            if (input!=null)
                AddDict(input);
            
            _indexList = new ArrayList();
            _lineList = new ArrayList();
            _typeList = new ArrayList();
            _longParseTree.Initialize(_trie, _indexList, _typeList);
        }
        private void AddDict(StreamReader dictFile) //File dictFile
        {
            //Read words from dictionary
            String line = ""; //, word, word2;
            
            while ((line = dictFile.ReadLine()) != null)
            {
                line = line.Trim();
                // ignore if start with #
                if (line.Length > 0 && !line.StartsWith("#"))
                {
                    _trie.Add(line);
                }
            }
        }
        public void WordInstance(string text)
        {
            indexList.Clear();
            typeList.Clear();
            int pos;
            char ch;
            pos = 0;
            while (pos < text.Length)
            {
                ch = text[pos];
                //English
                var withinCapA = ch >= 'A';
                var withinCapZ = ch <= 'Z';
                var withinA = ch >= 'a';
                var withinZ = ch <= 'z';
                
                //Digits
                var betweenZeroAndNine = ch >= '0' && ch <= '9';
                var betweenThaiZeroAndNine = ch >= '๐' && ch <= '๙';

                if (withinCapA && withinCapZ || withinA && withinZ)
                {
                    while (pos < text.Length && withinCapA && withinCapZ || withinA && withinZ)
                        ch = text[pos++];
                    
                    if (pos < text.Length)
                        pos--;
                    
                    indexList.Add((short)pos);
                    typeList.Add((short)3);
                }
                else if (betweenZeroAndNine || betweenThaiZeroAndNine)
                {
                    while ((pos < text.Length) && betweenZeroAndNine || betweenThaiZeroAndNine || ch == ',' || ch == '.')
                    {
                        ch = text[pos++];
                    }
                    if (pos < text.Length)
                    {
                        pos--;
                    }
                    indexList.Add((short)pos);
                    typeList.Add((short)3);
                }
                //Special characters
                else if (ch <= '~' || ch == 'ๆ' || ch == 'ฯ' || ch == '“' || ch == '”' || ch == ',')
                {
                    pos++;
                    indexList.Add((short)pos);
                    typeList.Add((short)4);
                }
                //Thai word (known/unknown/ambiguous)
                else
                {
                    pos = _longParseTree.ParseWordInstance(pos, text);
                }
            }
            
            _enumerator = indexList.GetEnumerator();
        }
        public void LineInstance(string text)
        {
            int windowSize = 10; //for detecting parentheses, quotes
            int curType, nextType, tempType, curIndex, nextIndex, tempIndex;
            _lineList.Clear();
            WordInstance(text);
            int i;
            for (i = 0; i < typeList.Count - 1; i++)
            {
                curType = (short)typeList[i];
                curIndex = (short)indexList[i];
                if (curType == 3 || curType == 4)
                {
                    //Parenthesese                    
                    if (curType == 4 && text[curIndex - 1] == '(')
                    {
                        int pos = i + 1;
                        while (pos < typeList.Count && pos < i + windowSize)
                        {
                            tempType = (short)typeList[pos];
                            tempIndex = (short)indexList[pos++];
                            if (tempType == 4 && text[tempIndex - 1] == ')')
                            {
                                _lineList.Add((short)tempIndex);
                                i = pos - 1;
                                break;
                            }
                        }
                    }
                    //Single quote
                    else if (curType == 4 && text[curIndex - 1] == '\'')
                    {
                        int pos = i + 1;
                        while (pos < typeList.Count && pos < i + windowSize)
                        {
                            tempType = (short)typeList[pos];
                            tempIndex = (short)indexList[pos++];
                            
                            if (tempType == 4 && text[tempIndex - 1] == '\'')
                            {
                                _lineList.Add((short)tempIndex);
                                i = pos - 1;
                                break;
                            }
                        }
                    }
                    //Double quote
                    else if (curType == 4 && text[curIndex - 1] == '\"')
                    {
                        int pos = i + 1;
                        while (pos < typeList.Count && pos < i + windowSize)
                        {
                            tempType = (short)typeList[pos];
                            tempIndex = (short)indexList[pos++];
                            if (tempType == 4 && text[tempIndex - 1] == '\'')
                            {
                                _lineList.Add((short)tempIndex);
                                i = pos - 1;
                                break;
                            }
                        }
                    }
                    else
                        _lineList.Add((short)curIndex);
                }
                else
                {
                    nextType = (short)typeList[i + 1];
                    nextIndex = (short)indexList[i + 1];
                    if (nextType == 3 || nextType == 4 && text[nextIndex - 1] == ' ' || text[nextIndex - 1] == '\"' || text[nextIndex - 1] == '(' || text[nextIndex - 1] == '\'')
                    {
                        
                    }
                    else
                    {
                        if ((curType == 1) && (nextType != 0) && (nextType != 4))
                        {
                            _lineList.Add((short)indexList[i]);
                        }
                    }

                    // if (1 == 2)
                    // {
                    //
                    // }
                    // else if (1 == 3)
                    // {
                    //
                    // }
                }
            }
            if (i < typeList.Count)
                _lineList.Add((short)indexList.Count - 1);
            
            _enumerator = (IEnumerator) _lineList;
        }
    }
}