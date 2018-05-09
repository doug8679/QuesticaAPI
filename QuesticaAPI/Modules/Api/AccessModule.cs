using System;
using System.Linq;
using Nancy.ModelBinding;
using Questica.Model;
using QuesticaAPI.Responses;

namespace QuesticaAPI.Modules.Api
{
    public class AccessModule : BaseApiModule
    {
        public AccessModule() : base("/login")
        {
            Post("/", p=> ProcessLogin());
        }

        private object ProcessLogin()
        {
            var login = this.Bind<LoginRequest>();
            var hash = Convert.FromBase64String(login.passwd);
            var response = new EmployeeResponse();

            // Todo: Attempt to validate username and hash against database...
            using (var db = new TimeData())
            {
                var emp = db.Employees.FirstOrDefault(e => e.UserID.Equals(login.username) && e.Password.Equals(hash));
                if (emp != null)
                {
                    response.Employee = emp;
                    response.success = true;
                    return response;
                }

                response.success = false;
                response.error = $"Could not locate employee \"{login.username}\" in database.";
            }

            return response;
        }
    }
}