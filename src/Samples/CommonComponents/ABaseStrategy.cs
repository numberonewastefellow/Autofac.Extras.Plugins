namespace CommonComponents
{
    public abstract class ABaseStrategy : IBaseStrategy
    {
        readonly IFinisher mFinisher;
        readonly IStrategySettings _mStrategySettings;
        readonly ISeparator mSeparator;
        readonly IWorld mWorld;
        protected ABaseStrategy(IStrategySettings strategySettings, IWorld world, ISeparator separator, IFinisher finisher)
        {
            _mStrategySettings = strategySettings;
            mWorld = world;
            mSeparator = separator;
            mFinisher = finisher;
        }
        protected abstract string StrategyName { get; }

        public abstract bool Start();
        
        public string GetStrategyName
        {
            get
            {
                var parts = new[] {_mStrategySettings.Hello, mWorld.World};
                var greeting = mFinisher.Beautify(mSeparator.Separate(parts));
                return $"In {StrategyName} the strategy :\r\n{greeting}";
            }
        }
    }
}