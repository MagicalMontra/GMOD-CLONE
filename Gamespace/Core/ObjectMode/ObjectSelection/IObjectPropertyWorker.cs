namespace Gamespace.Core.ObjectMode.Selection
{
    public interface IObjectPropertyWorker
    {
        void Open(IPlaceableObject placeableObject);
        void Close();
    }
}