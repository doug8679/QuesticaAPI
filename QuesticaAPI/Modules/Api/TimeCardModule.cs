using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
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
            var result = new EmptyResponse();
            try
            {
                Console.WriteLine($"Deleting time entry for id ({timeId})...");
                using (var db = new TimeData())
                {
                    var entry = db.TimeCardEntries.Find(timeId);
                    db.TimeCardEntries.Remove(entry);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.error = ex.ToString();
            }
            return result;
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
                entry.TimeDate = entry.TimeDate.Date;
                using (var db = new TimeData())
                {
                    var nueEntry = db.TimeCardEntries.Add(entry);
                    db.SaveChanges();
                    entry = nueEntry;
                }
                Console.WriteLine(
                    $"Creating entry {entry.TimeID} on project {entry.ProjectID}::{entry.SpecID} for {entry.HourTime} hours.");
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
            var result = new TimeEntryResponse();
            try
            {
                var entry = this.Bind<TimeCardEntryModel>();
                entry.TimeDate = entry.TimeDate.Date;
                Console.WriteLine($"Updating entry on project {entry.ProjectID}::{entry.SpecID} from {entry.TimeDate} to {entry.HourTime} hours.");
                using (var db = new TimeData())
                {
                    var timeEntry = db.TimeCardEntries.Find(entry.TimeID);
                    if (timeEntry != null)
                    {
                        timeEntry.TimeDate = entry.TimeDate;
                        timeEntry.ProjectID = entry.ProjectID;
                        timeEntry.SpecID = entry.SpecID;
                        timeEntry.HourTime = entry.HourTime;
                        timeEntry.Comments = entry.Comments;
                        db.SaveChanges();
                    }
                    else
                    {
                        result.success = false;
                        result.error = $"Could not locate time card entry for TimeID {entry.TimeID}.";
                    }
                }

                result.TimeEntry = entry;
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