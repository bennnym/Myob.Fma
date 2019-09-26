namespace Myob.Fma.BookingLibrary.Resources
{
    public interface IResourceManager
    {
        void AddResourceToInventory(IResource resource);
        void RemoveResourceFromInventory(IResource resource);
        bool IsResourceAvailableToBorrow(int id);
        bool IsResourceInInventory(int id);
        void CheckoutResource(int resourceId);
        void ReturnResource(int resourceId);
        int GetNewResourceId();
        IResource GetResource(int resourceId);
    }
}