namespace Gamespace.Core.Save
{
    public class SaveRequestSignal
    {
       public string saveName => _saveName;

        private string _saveName;
        
        public SaveRequestSignal(string saveName)
        {
            _saveName = saveName;
        }
    }
}
