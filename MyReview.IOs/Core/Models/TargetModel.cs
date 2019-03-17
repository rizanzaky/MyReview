using System;

namespace MyReview.Core.Models
{
    public class TargetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsMarked { get; set; }
        public DateTime Date { get; set; }
    }
}