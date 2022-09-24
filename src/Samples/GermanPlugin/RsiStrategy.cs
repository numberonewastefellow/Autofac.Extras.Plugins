using CommonComponents;
using System;

namespace GermanPlugin
{
    public class RsiStrategy : ABaseStrategy
    {
        public RsiStrategy(IStrategySettings strategySettings, IWorld world, ISeparator separator, IFinisher finisher)
            : base(strategySettings, world, separator, finisher) {}
        protected override string Language => "RSI";
        public override bool Start()
        {

            Console.WriteLine($"{Language} started..");
            return true;
        }
    }
}