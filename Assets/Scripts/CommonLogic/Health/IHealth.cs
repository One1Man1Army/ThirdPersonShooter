namespace TPS.CommonLogic
{
    public interface IHealth : IHittable
    {
        float Current { get; set; }
        float Max { get; }
    }
}
