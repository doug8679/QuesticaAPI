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

    public class ObjectiveModel
    {
        public string ObjectiveName { get; set; }
        public int ProjectID { get; set; }
        public double SpecID { get; set; }

        public static implicit operator ObjectiveModel(Objective obj)
        {
            return new ObjectiveModel
            {
                ObjectiveName = obj.ObjectiveName,
                ProjectID = obj.ProjectID,
                SpecID = obj.SpecID
            };
        }
    }
}