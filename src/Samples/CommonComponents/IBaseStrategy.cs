namespace CommonComponents
{
    public interface IBaseStrategy
    {
        string GetStrategyName { get; }
        bool Start();
    }
}