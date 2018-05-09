using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using QuesticaAPI.Responses;

namespace QuesticaAPI.Modules.Api
{
    public class HelloModule : BaseApiModule
    {
        public HelloModule() : base("/hello")
        {
            Get("/", p=> SayHello());
        }

        private object SayHello()
        {
            return new HelloResponse();
        }
    }
}
