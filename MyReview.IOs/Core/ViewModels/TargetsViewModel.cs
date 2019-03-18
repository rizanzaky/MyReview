using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using MyReview.Core.Models;

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
                        Id = group.target.Id, Name = group.target.Name, IsMarked = marking?.IsMarked ?? false
                    }).ToList();
        }

        private DateTime _panelDate;

        public List<TargetModel> Targets { get; set; }
        public List<TargetModel> Markings { get; set; }

        private List<TargetModel> GetMarkings()
        {
            var markings = new List<TargetModel>();

            try
            {
                markings.AddRange(File.ReadAllLines("./MarkingsDataFile.txt").Select(line =>
                {
                    var lines = line.Split(',');
                    return new TargetModel
                    {
                        Id = int.Parse(lines[0]),
                        Date = DateTime.Parse(lines[1], new CultureInfo("en-GB")),
                        IsMarked = true
                    };
                }));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return markings;
        }

        private List<TargetModel> GetTargets()
        {
            var targets = new List<TargetModel>();

            try
            {
                targets.AddRange(File.ReadAllLines("./TargetDataFile.txt").Select(line =>
                {
                    var lines = line.Split(',');
                    return new TargetModel
                    {
                        Id = int.Parse(lines[0]),
                        Name = lines[1]
                    };
                }));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return targets;
        }

        private void AddMarking(int itemId, DateTime itemDate)
        {

        }

        private void DeleteMarking(int itemId, DateTime itemDate)
        {
            try
            {
                //File.WriteAllLines("./MarkingsDataFile.txt", new List<string>{"Hello World"});

                //var oldMarkings = File.ReadAllLines("./MarkingsDataFile.txt");
                //var newMarkings = oldMarkings.SkipWhile(line => line.Contains($"{itemId},{_panelDate:d/M/yyyy}"));
                //File.WriteAllLines("./MarkingsDataFile.txt", newMarkings);
                //var a = File.ReadAllLines("./MarkingsDataFile.txt");
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
}