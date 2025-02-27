﻿using System;
using CommonComponents;

namespace EnglishPlugin
{
    public class VwapStrategy : ABaseStrategy
    {
        public VwapStrategy(IStrategySettings strategySettings, IWorld world, ISeparator separator, IFinisher finisher)
            : base(strategySettings, world, separator, finisher) {}
        protected override string StrategyName => "VWAP";
        public override bool Start()
        {
            Console.WriteLine($"{StrategyName} started..");
            return true;
        }
    }
}