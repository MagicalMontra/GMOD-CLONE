namespace Gamespace.Core.Actions
{
    public class StringVariableFlagResponseSignal
    {
        public string flagName => _flagName;
        public string value => _value;
        private string _flagName;
        private string _value;
        
        public StringVariableFlagResponseSignal(string flagName, string value)
        {
            _flagName = flagName;
            _value = value;
        }
    }
}