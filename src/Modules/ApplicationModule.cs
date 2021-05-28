using Autofac;
using netHelpers.Framework.Application;

namespace netHelpers.Framework.Modules
{
    public class ApplicationModule : Module
    {
        private const string ApplicationName = "ApplicationInfo:Name";
        private const string ApplicationVersion = "ApplicationInfo:Version";
        private const string ApplicationCode = "ApplicationInfo:Code";

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationInfo>().As<IApplicationInfo>()
                .WithParameter("name", ApplicationName)
                .WithParameter("version", ApplicationVersion)
                .WithParameter("code", ApplicationCode);

            base.Load(builder);
        }
    }
}
