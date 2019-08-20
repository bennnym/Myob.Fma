namespace Myob.Fma.PetShop.Composition
{
    public interface IWalk
    {
        void Walk();
        bool CanWalk { get; set; }
    }
}