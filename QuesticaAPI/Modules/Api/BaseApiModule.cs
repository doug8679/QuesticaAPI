using Nancy;
using Nancy.Json;
using Nancy.Responses.Negotiation;

namespace QuesticaAPI.Modules.Api
{
    public abstract class BaseApiModule : NancyModule
    {
        protected string basePath = "/api";

        protected BaseApiModule() : base("/api") { }

        protected BaseApiModule(string modulePath) : base($"/api{modulePath}") { }
    }
}
