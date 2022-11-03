namespace Gamespace.Core.Actions
{
    public class StringVariableFlagRequestSignal
    {
        public string flagName => _flagName;
        private string _flagName;

        public StringVariableFlagRequestSignal(string flagName)
        {
            _flagName = flagName;
        }
    }
}