using Questica.Model;

namespace QuesticaAPI.Models
{
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