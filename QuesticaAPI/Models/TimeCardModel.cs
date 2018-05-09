using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Questica.Model;

namespace QuesticaAPI.Models
{
    public class TimeCardModel
    {
        public TimeCardModel()
        {
            Entries = new List<TimeCardEntryModel>();
        }

        public ICollection<TimeCardEntryModel> Entries { get; set; }

        public DateTime PayPeriodEndDate { get; set; }

        public DateTime PayPeriodStartDate { get; set; }

        public int TimePeriodID { get; set; }

        public static implicit operator TimeCardModel(TimeCard source)
        {
            var result = new TimeCardModel
            {
                PayPeriodEndDate = source.PayPeriodEndDate,
                PayPeriodStartDate = source.PayPeriodStartDate,
                TimePeriodID = source.TimePeriodID
            };
            foreach (var entry in source.Entries)
            {
                result.Entries.Add(entry);
            }

            return result;
        }
    }
}
