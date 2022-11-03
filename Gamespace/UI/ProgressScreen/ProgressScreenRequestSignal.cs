namespace Gamespace.UI.ProgressScreen
{
    public class ProgressScreenRequestSignal
    {
        public int current => _current;
        public int total => _total;
        public string progressText => _progressText;
        
        private int _current;
        private int _total;
        private string _progressText;

        public ProgressScreenRequestSignal(int current, int total, string progressText)
        {
            _current = current;
            _total = total;
            _progressText = progressText;
        }
    }

    public class ProgressScreenCompleteSignal
    {
        public string progressText => _progressText;
        private string _progressText;

        public ProgressScreenCompleteSignal(string progressText)
        {
            _progressText = progressText;
        }
    }
}