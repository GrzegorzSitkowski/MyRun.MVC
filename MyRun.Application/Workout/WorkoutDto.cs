using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Workout
{
    public class WorkoutDto
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

        public bool IsEditable { get; set; }
    }
}
