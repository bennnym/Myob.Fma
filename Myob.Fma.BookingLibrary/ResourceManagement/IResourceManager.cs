using Myob.Fma.BookingLibrary.Resources;

namespace Myob.Fma.BookingLibrary.ResourceManagement
{
    public interface IResourceManager
    {
        void AddResourceToInventory(IResource resource);
        void RemoveResourceFromInventory(IResource resource);
        void CheckoutResource(int resourceId);
        void ReturnResource(int resourceId);
        IResource GetResource(int resourceId);
        void CheckResourceIsAvailableToBorrow(int resourceId);
        void CheckForResourceInInventory(int resourceId);
    }
}