namespace Gamespace.Core.Actions
{
    public class StringVariableFlagSetSignal
    {
        public string flagName => _flagName;
        public string value => _value;
        private string _flagName;
        private string _value;
        
        public StringVariableFlagSetSignal(string flagName, string value)
        {
            _flagName = flagName;
            _value = value;
        }
    }
}