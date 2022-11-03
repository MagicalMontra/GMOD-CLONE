using System.Collections.Generic;

namespace Gamespace.UI
{
    public class CircleWheelPageWorker
    {
        public bool isInitialize => _isInitialize;
        public CircleWheelAction[] currentPage => _pages[_currentPage];
        
        private bool _isInitialize;
        private int _currentPage = 0;
        private List<CircleWheelAction[]> _pages = new List<CircleWheelAction[]>();
        
        public void Initialize(CircleWheelAction[] actions)
        {
            if (actions.Length < 8)
            {
                _isInitialize = false;
                return;
            }

            var count = 0;
            var pages = new List<CircleWheelAction>();

            for (int i = 0; i < actions.Length; i++)
            {
                if (count > 8)
                {
                    _pages.Add(pages.ToArray());
                    count = 0;
                    pages.Clear();
                }
                
                pages.Add(actions[i]);
                count++;
            }

            _pages.Add(pages.ToArray());
            _currentPage = 0;
            _isInitialize = true;
        }
        public void ChangePage(int value)
        {
            if (!_isInitialize)
                return;
            
            _currentPage += value;
            
            if (_currentPage < 0)
                _currentPage = _pages.Count - 1;
            
            if (_currentPage >= _pages.Count)
                _currentPage = 0;
        }
    }
}