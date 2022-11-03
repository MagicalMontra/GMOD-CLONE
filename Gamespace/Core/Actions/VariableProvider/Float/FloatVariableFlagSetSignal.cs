namespace Gamespace.Core.Actions
{
    public class FloatVariableFlagSetSignal
    {
        public string flagName => _flagName;
        public float value => _value;
        private string _flagName;
        private float _value;
        
        public FloatVariableFlagSetSignal(string flagName, float value)
        {
            _flagName = flagName;
            _value = value;
        }
    }
}