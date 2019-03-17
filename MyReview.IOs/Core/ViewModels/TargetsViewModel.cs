using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MyReview.Core.Models;

namespace MyReview.Core.ViewModels
{
    public class TargetsViewModel
    {
        public TargetsViewModel()
        {
            Targets = GetTargets();
        }

        public List<TargetModel> Targets { get; set; }

        private List<TargetModel> GetTargets()
        {
            var targets = new List<TargetModel>();

            try
            {
                targets.AddRange(File.ReadAllLines("./TargetDataFile.txt").Select(line => new TargetModel {Name = line}));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return targets;
        }
    }
}