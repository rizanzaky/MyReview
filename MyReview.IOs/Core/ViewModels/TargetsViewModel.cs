using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using MyReview.Core.Models;
using SQLite;

namespace MyReview.Core.ViewModels
{
    public class TargetsViewModel
    {
        public TargetsViewModel()
        {
            Markings = GetMarkings();
            MergeMarkingsIntoTargets(DateTime.Now);
        }

        public void MergeMarkingsIntoTargets(DateTime date)
        {
            _panelDate = date;
            
            Targets = GetTargets()
                .GroupJoin(Markings.Where(f => f.Date.Date == date.Date), target => target.Id, marking => marking.Id,
                    (target, markings) => new {target, markings })
                .SelectMany(group => group.markings.DefaultIfEmpty(),
                    (group, marking) => new TargetModel
                    {
                        Id = group.target.Id, Name = group.target.Name, IsMarked = marking != null
                    }).ToList();
        }

        private DateTime _panelDate;

        public List<TargetModel> Targets { get; set; }
        public List<TargetModel> Markings { get; set; }
        
        private List<TargetModel> GetMarkings()
        {
            var dataLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "database.db3");
            using (var database = new SQLiteConnection(dataLocation))
            {
                var t = database.Query<Temporary>("SELECT * FROM Markings;")
                        ?.Select(s => new TargetModel {Id = s.TargetId, Date = DateTime.Parse(s.Date, new CultureInfo("en-GB"))}).ToList() 
                        ?? new List<TargetModel>();
                return t;
            }
        }

        private List<TargetModel> GetTargets()
        {
            var dataLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "database.db3");
            using (var database = new SQLiteConnection(dataLocation))
            {
                return database.Query<TargetModel>("SELECT * FROM Targets;") ?? new List<TargetModel>();
            }
        }

        private void AddMarking(int itemId, DateTime itemDate)
        {

        }

        private void DeleteMarking(int itemId, DateTime itemDate)
        {
            try
            {
                var dataLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "database.db3");
                using (var database = new SQLiteConnection(dataLocation))
                {
                    database.Execute($"DELETE from Markings WHERE TargetId={itemId} AND Date=\"{_panelDate:d/M/yyyy}\""); 
                    Markings = GetMarkings();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void UpdateMarking(bool itemIsMarked, int itemId, DateTime itemDate)
        {
            if (itemIsMarked)
            {
                AddMarking(itemId, itemDate);
            }
            else
            {
                DeleteMarking(itemId, itemDate);
            }
        }
    }

    public class Temporary
    {
        public int TargetId { get; set; }
        public string Date { get; set; }
    }
}