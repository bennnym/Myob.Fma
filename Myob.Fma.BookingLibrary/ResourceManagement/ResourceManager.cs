using System.Collections.Generic;
using System.Linq;
using Myob.Fma.BookingLibrary.Constants;
using Myob.Fma.BookingLibrary.Exceptions;
using Myob.Fma.BookingLibrary.Resources;

namespace Myob.Fma.BookingLibrary.ResourceManagement
{
    public class ResourceManager : IResourceManager
    {
        private readonly List<IResource> _inventory;

        public ResourceManager()
        {
            _inventory = new List<IResource>();
        }

        public void AddResourceToInventory(IResource resource)
        {
            _inventory.Add(resource);
        }
        
        public void RemoveResourceFromInventory(IResource resource)
        {
            _inventory.Remove(resource);
        }

        public void CheckoutResource(int resourceId)
        {
            var resource = GetResource(resourceId);
            resource.IsAvailable = false;
        }

        public void ReturnBorrowedResource(int resourceId)
        {
            var resource = GetResource(resourceId);
            resource.IsAvailable = true;
        }

        public IResource GetResource(int resourceId)
        {
            return _inventory.Find(r => r.Id == resourceId);
        }
        
        public void CheckResourceIsAvailableToBorrow(int resourceId)
        {
            if (IsResourceAvailableToBorrow(resourceId) == false)
                throw new ResourceNotAvailableToBorrowException(Constant.ResourceNotAvailable);
        }
        
        public void CheckForResourceInInventory(int resourceId)
        {
            if (IsResourceInInventory(resourceId) == false)
                throw new ResourceNotInInventoryException(Constant.ResourceNotInInventory);
        }
        private bool IsResourceInInventory(int id)
        {
            return _inventory.Any(r => r.Id == id);
        }
        
        private bool IsResourceAvailableToBorrow(int id)
        {
            return _inventory.Any(r => r.Id == id && r.IsAvailable);
        }
    }
}