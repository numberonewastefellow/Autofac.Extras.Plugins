namespace CommonComponents
{
    public interface IBaseStrategy
    {
        string StrategyName { get; }
        bool Start();
    }
}