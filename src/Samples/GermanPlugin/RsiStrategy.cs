using CommonComponents;
using System;

namespace GermanPlugin
{
    public class RsiStrategy : ABaseStrategy
    {
        public RsiStrategy(IStrategySettings strategySettings, IWorld world, ISeparator separator, IFinisher finisher)
            : base(strategySettings, world, separator, finisher) {}
        protected override string StrategyName => "RSI";
        public override bool Start()
        {

            Console.WriteLine($"{StrategyName} started..");
            return true;
        }
    }
}