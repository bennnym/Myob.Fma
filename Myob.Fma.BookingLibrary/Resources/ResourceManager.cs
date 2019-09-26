using System.Collections.Generic;
using System.Linq;

namespace Myob.Fma.BookingLibrary.Resources
{
    public class ResourceManager : IResourceManager
    {
        private readonly List<IResource> _inventory = new List<IResource>();

        public void AddResourceToInventory(IResource resource)
        {
            _inventory.Add(resource);
        }
        
        public void RemoveResourceFromInventory(IResource resource)
        {
            _inventory.Remove(resource);
        }

        public bool IsResourceAvailableToBorrow(int id)
        {
            return _inventory.Any(r => r.Id == id && r.IsAvailable);
        }

        public bool IsResourceInInventory(int id)
        {
            return _inventory.Any(r => r.Id == id);
        }

        public void CheckoutResource(int resourceId)
        {
            var resource = GetResource(resourceId);
            resource.IsAvailable = false;
        }

        public void ReturnResource(int resourceId)
        {
            var resource = GetResource(resourceId);
            resource.IsAvailable = true;
        }

        public int GetNewResourceId()
        {
            return _inventory.Last().Id + 1;
        }

        public IResource GetResource(int resourceId)
        {
            return _inventory.Find(r => r.Id == resourceId);
        }
    }
}