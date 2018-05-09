using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.Json;
using Nancy.ModelBinding;
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

                return result;
            }
        }

        private object PutTimeEntry()
        {
            var entry = this.Bind<TimeCardEntryModel>();
            Console.WriteLine($"Creating entry on project {entry.ProjectID}::{entry.SpecID} for {entry.HourTime} hours.");
            return new EmptyResponse();
        }

        private object UpdateTimeEntry()
        {
            var entry = this.Bind<TimeCardEntryModel>();
            Console.WriteLine($"Updatein entry on project {entry.ProjectID}::{entry.SpecID} from {entry.TimeDate} to {entry.HourTime} hours.");
            return new EmptyResponse();
        }
    }
}
