namespace Gamespace.Core.Actions
{
    public abstract class FloatActionBehaviour : BaseActionBehavior
    {
        protected abstract override ActionVariable[] Variables();
        public override void Perform()
        {
            Perform(0f);
        }
        public override void Perform(int value)
        {
            Perform((float)value);
        }
        public abstract override void Perform(float value);
        public override void Perform(string value)
        {
            float.TryParse(value, out var outValue);
            Perform(outValue);
        }
    }
}