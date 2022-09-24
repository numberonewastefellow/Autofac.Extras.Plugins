using Autofac;
using Autofac.Extras.Plugins;
using CommonComponents;

namespace GermanPlugin
{
    public class GermanModule : Module
    {
        const string Key = "GermanPlugin";
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RsiStrategy>().AsPlugin().Provide<IBaseStrategy>(Key);
            builder.RegisterType<GermanStrategySettings>().AsPlugin().Provide<IStrategySettings>(Key);
            builder.RegisterType<GermanWorld>().AsPlugin().Provide<IWorld>(Key);
            builder.RegisterType<GermanSeparator>().AsPlugin().Provide<ISeparator>(Key);
            builder.RegisterType<GermanFinisher>().AsPlugin().Override<IFinisher>(Key);
        }
    }
}