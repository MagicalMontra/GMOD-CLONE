
    public class PauseRequestSignal
    {
        public bool isPause => _isPause;
        private bool _isPause;

        public PauseRequestSignal(bool pause)
        {
            _isPause = pause;
        }
    }


