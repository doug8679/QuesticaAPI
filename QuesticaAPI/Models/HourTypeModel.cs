using Questica.Model;

namespace QuesticaAPI.Models
{
    public class HourTypeModel
    {
        public string EarningNumber { get; set; }

        public bool Exported { get; set; }

        public bool HourActive { get; set; }

        public string HourClass { get; set; }

        public decimal? HourCost { get; set; }

        public string HourDescription { get; set; }

        public int HourID { get; set; }

        public static implicit operator HourTypeModel(HourType source)
        {
            return new HourTypeModel
            {
                EarningNumber = source.EarningNumber,
                Exported = source.Exported,
                HourActive = source.HourActive,
                HourClass = source.HourClass,
                HourCost = source.HourCost,
                HourDescription = source.HourDescription,
                HourID = source.PKHourType
            };
        }
    }
}