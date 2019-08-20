namespace Myob.Fma.PetShop.Composition
{
    public class Horse : IWalk
    {
        public void Walk()
        {
            throw new System.NotImplementedException();
        }

        public bool CanWalk { get; set; }
    }
}