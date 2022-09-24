using Autofac;
using Autofac.Extras.Plugins;
using CommonComponents;

namespace EnglishPlugin
{
    public class EnglishModule : Module
    {
        const string Key = "EnglishPlugin";
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EnglishBaseStrategy>().AsPlugin().Provide<IBaseStrategy>(Key);
            builder.RegisterType<EnglishStrategySettings>().AsPlugin().Provide<IStrategySettings>(Key);
            builder.RegisterType<EnglishWorld>().AsPlugin().Provide<IWorld>(Key);
            builder.RegisterType<EnglishSeparator>().AsPlugin().Provide<ISeparator>(Key);
        }
    }
}