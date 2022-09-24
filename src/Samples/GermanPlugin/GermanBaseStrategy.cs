using CommonComponents;
using System;

namespace GermanPlugin
{
    public class GermanBaseStrategy : ABaseStrategy
    {
        public GermanBaseStrategy(IStrategySettings strategySettings, IWorld world, ISeparator separator, IFinisher finisher)
            : base(strategySettings, world, separator, finisher) {}
        protected override string Language => "German";
        public override bool Start()
        {

            Console.WriteLine($"{Language} started..");
            return true;
        }
    }
}