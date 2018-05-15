using System;
using System.Linq;
using Nancy;
using Nancy.Json;
using Nancy.Responses.Negotiation;
using Questica.Model;
using QuesticaAPI.Models;
using QuesticaAPI.Responses;

namespace QuesticaAPI.Modules.Api
{
    public abstract class BaseApiModule : NancyModule
    {
        protected string basePath = "/api";

        protected BaseApiModule() : base("/api") { }

        protected BaseApiModule(string modulePath) : base($"/api{modulePath}") { }
    }

    public class JobCodeModule : BaseApiModule
    {
        public JobCodeModule() : base("/job-codes")
        {
            Get("/", p => ListJobCodes());
        }

        private object ListJobCodes()
        {
            var result = new JobCodesResponse();
            try
            {
                using (var db = new TimeData())
                {
                    var codes = db.JobCodes.ToList();
                    result.JobCodes.AddRange(codes.Select(c => (HourTypeModel) c).ToList());
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.error = ex.ToString();
            }
            return result;
        }
    }
}
