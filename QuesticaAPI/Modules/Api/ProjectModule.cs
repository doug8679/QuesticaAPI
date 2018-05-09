using System.Collections.Generic;
using System.Linq;
using Questica.Model;
using QuesticaAPI.Models;

namespace QuesticaAPI.Modules.Api
{
    public class ProjectModule : BaseApiModule
    {
        public ProjectModule() : base("/projects")
        {
            Get("/", p=> ListProjects());
            Get("/{id}", p => ListObjectives(p.id));
        }

        private object ListObjectives(int id)
        {
            using (var db = new TimeData())
            {
                var objs = db.Objectives.Where(o => o.ProjectID.Equals(id));
                var result = new List<ObjectiveModel>();
                foreach (var objective in objs)
                {
                    result.Add(objective);
                }

                return result;
            }
        }

        private object ListProjects()
        {
            using (var db = new TimeData())
            {
                var projects = db.Projects.Where(p=>p.PercentComplete == null && p.Status != null).ToList();
                var result = new List<ProjectModel>();
                foreach (var project in projects)
                {
                    result.Add(project);
                }

                return result;
            }
        }
    }
}