namespace Gamespace.Core.Actions
{
    public class FloatVariableFlagRequestSignal
    {
        public string flagName => _flagName;
        private string _flagName;

        public FloatVariableFlagRequestSignal(string flagName)
        {
            _flagName = flagName;
        }
    }
}