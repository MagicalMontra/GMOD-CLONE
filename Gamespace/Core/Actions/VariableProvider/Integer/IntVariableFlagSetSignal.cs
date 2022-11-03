namespace Gamespace.Core.Actions
{
    public class IntVariableFlagSetSignal
    {
        public string flagName => _flagName;
        public int value => _value;
        private string _flagName;
        private int _value;
        
        public IntVariableFlagSetSignal(string flagName, int value)
        {
            _flagName = flagName;
            _value = value;
        }
    }
}