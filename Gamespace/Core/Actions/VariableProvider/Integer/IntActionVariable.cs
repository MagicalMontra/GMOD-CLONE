using System;

namespace Gamespace.Core.Actions
{
    [Serializable]
    public class IntActionVariable : ActionVariable
    {
        public int value;

        public IntActionVariable(int defaultValue)
        {
            value = defaultValue;
        }
    }
    [Serializable]
    public class FloatActionVariable : ActionVariable
    {
        public float value;
        
        public FloatActionVariable(float defaultValue)
        {
            value = defaultValue;
        }
    }
    [Serializable]
    public class StringActionVariable : ActionVariable
    {
        public string value;
        
        public StringActionVariable(string defaultValue)
        {
            value = defaultValue;
        }
    }
    [Serializable]
    public class BoolActionVariable : ActionVariable
    {
        public bool value;
        
        public BoolActionVariable(bool defaultValue)
        {
            value = defaultValue;
        }
    }
}