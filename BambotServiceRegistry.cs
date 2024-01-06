using System;
using System.Reflection;
using Bam.Net.Automation;
using Bam.Net.CoreServices;
using Bam.Net.Services;
using Bam.Net.Services.Automation;
using System.Linq;
using Bam.Net.Profiguration;

namespace Bam.Net.Application
{
    [ServiceRegistryContainer]
    public class BambotServiceRegistry : ServiceRegistry
    {
        public const string ApplicationName = "Bambot";

        public static ServiceRegistry ForCurrentProcessMode()
        {
            ProcessModes current = ProcessMode.Current.Mode;
            MethodInfo creator = typeof(BambotServiceRegistry).GetMethods().FirstOrDefault(m =>
            {
                if (m.HasCustomAttributeOfType(out ServiceRegistryLoaderAttribute attr))
                {
                    return attr.ProcessModes.Contains(current);
                }

                return false;
            });

            if (creator != null)
            {
                return (ServiceRegistry) creator.Invoke(null, null);
            }

            return Dev();
        }
        
        
        [ServiceRegistryLoader(ApplicationName, ProcessModes.Dev)]
        public static ServiceRegistry Dev()
        {
             // customize for Dev
            return Create();
        }
        
        [ServiceRegistryLoader(ApplicationName, ProcessModes.Test)]
        public static ServiceRegistry Test()
        {
            // customize for Test
            return Create();
        }
        
        [ServiceRegistryLoader(ApplicationName, ProcessModes.Prod)]
        public static ServiceRegistry Prod()
        {
            // customize for Prod
            return Create();
        }
        
        public static ServiceRegistry Create(Action<ServiceRegistry> configure = null)
        {
            ServiceRegistry result = ForProcess(appSvcReg =>
            {
                appSvcReg.For<CommandService>().Use<CommandService>();
                appSvcReg.For<IApplicationNameProvider>().Use<ProcessApplicationNameProvider>();
                appSvcReg.For<JobManagerService>().Use<JobManagerService>();
            });
            configure?.Invoke(result);

            return result;
        } 
    }
}