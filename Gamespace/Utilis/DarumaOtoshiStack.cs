using System.Collections.Generic;

namespace Gamespace.Utilis
{
    public class DarumaOtoshiStack
    {
        public int count => _stack.Count;
        private List<string> _stack = new List<string>();

        public void Add(string identifier)
        {
            if (!_stack.Exists(stack => stack == identifier))
                _stack.Add(identifier);
        }
        public void Hit(string identifier)
        {
            var index = _stack.FindIndex(stack => stack == identifier);
            
            if (index > -1)
                _stack.RemoveAt(index);
        }
    }
}