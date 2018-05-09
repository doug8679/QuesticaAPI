using Questica.Model;

namespace QuesticaAPI.Models
{
    public class ProjectModel
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }

        public static implicit operator ProjectModel(Project source)
        {
            return new ProjectModel{ProjectName = source.ProjectName, ProjectID = source.ProjectID};
        }
    }
}