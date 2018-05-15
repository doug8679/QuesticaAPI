using System;
using System.Collections.Generic;
using System.Linq;
using Nancy.ModelBinding;
using Questica.Model;
using QuesticaAPI.Models;
using QuesticaAPI.Responses;

namespace QuesticaAPI.Modules.Api
{
    public class TimeCardModule : BaseApiModule
    {
        public TimeCardModule() : base("/time")
        {
            Get("/{employeeId}", p=> ListTimeEntries(p.employeeId));
            Post("/entry", p=> UpdateTimeEntry());
            Put("/entry", p=> PutTimeEntry());
            Delete("/entry/{timeId}", p=> DeleteTimeEntry(p.timeId));
        }

        private object DeleteTimeEntry(int timeId)
        {
            Console.WriteLine($"Deleting time entry for id ({timeId})...");
            return new EmptyResponse();
        }

        private object ListTimeEntries(int employeeId)
        {
            using (var db = new TimeData())
            {
                var times = db.TimeCardEntries.Include("TimeCard").Where(e => e.EmployeeID.Equals(employeeId)).ToList();
                var cards = times.Select(e => e.TimeCard).Where(c=>c.PayPeriodStartDate<=DateTime.Now && c.PayPeriodEndDate>=DateTime.Now).Distinct();
                var result = new List<TimeCardModel>();
                foreach (var timeCard in cards)
                {
                    result.Add(timeCard);
                }

                return new TimeCardsResponse {TimeCards = result};
            }
        }

        private object PutTimeEntry()
        {
            var result = new TimeEntryResponse();
            try
            {
                var entry = this.Bind<TimeCardEntryModel>();
                Console.WriteLine(
                    $"Creating entry on project {entry.ProjectID}::{entry.SpecID} for {entry.HourTime} hours.");
                result.TimeEntry = entry;
            }
            catch (Exception ex)
            {
                result.success = false;
                result.error = ex.ToString();
            }

            return result;
        }

        private object UpdateTimeEntry()
        {
            var entry = this.Bind<TimeCardEntryModel>();
            Console.WriteLine($"Updatein entry on project {entry.ProjectID}::{entry.SpecID} from {entry.TimeDate} to {entry.HourTime} hours.");
            return new TimeEntryResponse {TimeEntry = entry};
        }
    }
}