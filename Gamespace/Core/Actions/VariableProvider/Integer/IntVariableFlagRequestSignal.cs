namespace Gamespace.Core.Actions
{
    public class IntVariableFlagRequestSignal
    {
        public string flagName => _flagName;
        private string _flagName;

        public IntVariableFlagRequestSignal(string flagName)
        {
            _flagName = flagName;
        }
    }
}