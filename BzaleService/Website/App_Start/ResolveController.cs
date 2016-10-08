using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.App_Start
{
    public class ResolveController : IDependencyResolver

    {

        private static readonly ISensorReadingStore ReadingStore = new SensorReadingStore();


        public object GetService(Type serviceType)

        {

            return serviceType == typeof(SensorReadingController) ? new SensorReadingController(ReadingStore) : null;

        }


        public IEnumerable<object> GetServices(Type serviceType)

        {

            return new List<object>();

        }


        public IDependencyScope BeginScope()

        {

            return this;

        }


        public void Dispose()

        {



        }

    }

}
}