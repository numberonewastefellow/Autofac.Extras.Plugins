using System;
using CommonComponents;

namespace EnglishPlugin
{
    public class EnglishBaseStrategy : ABaseStrategy
    {
        public EnglishBaseStrategy(IStrategySettings strategySettings, IWorld world, ISeparator separator, IFinisher finisher)
            : base(strategySettings, world, separator, finisher) {}
        protected override string Language => "English";
        public override bool Start()
        {
            Console.WriteLine($"{Language} started..");
            return true;
        }
    }
}