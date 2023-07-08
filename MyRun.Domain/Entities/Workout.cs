using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Domain.Entities
{
    public class Workout
    {
        public int Id { get; set; }
        public string Distance { get; set; } = default!;
        public string? Result { get; set; }
        public string? AveragePace { get; set; }
        public string? MaxPace { get; set; }
        public DateTime? Date { get; set; }
        public string? Calories { get; set; }
        public string? MapPhoto { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
