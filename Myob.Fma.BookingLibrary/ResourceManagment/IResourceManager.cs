using Myob.Fma.BookingLibrary.Resources;

namespace Myob.Fma.BookingLibrary.ResourceManagment
{
    public interface IResourceManager
    {
        void AddResourceToInventory(IResource resource);
        void RemoveResourceFromInventory(IResource resource);
        bool IsResourceAvailableToBorrow(int id);
        bool IsResourceInInventory(int id);
        void CheckoutResource(int resourceId);
        void ReturnResource(int resourceId);
        IResource GetResource(int resourceId);
        void CheckResourceIsAvailableToBorrow(int resourceId);
        void CheckForResourceInInventory(int resourceId);
    }
}