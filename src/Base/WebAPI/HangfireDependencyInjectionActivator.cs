using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;

namespace Template.Base.WebAPI
{
    public class HangfireDependencyInjectionActivator : JobActivator
    {
        private IServiceProvider ServiceProvider;

        public HangfireDependencyInjectionActivator(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public override object ActivateJob(Type type)
        {
            return ServiceProvider.GetService(type);
        }
    }
}
