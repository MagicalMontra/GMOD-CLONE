namespace Gamespace.Core.Player
{
    public class EditorInitializedSignal
    {
        public EditorPlayer player => _player;
        private EditorPlayer _player;

        public EditorInitializedSignal(EditorPlayer player)
        {
            _player = player;
        }
    }
}