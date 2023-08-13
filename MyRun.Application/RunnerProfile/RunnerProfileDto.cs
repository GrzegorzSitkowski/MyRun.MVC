using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.RunnerProfile
{
    public class RunnerProfileDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = default!;
        public int? Age { get; set; }
        public string? Weight { get; set; }
        public string? Pb5k { get; set; }
        public string? Pb10k { get; set; }
        public string? PbHalfMarathon { get; set; }
        public string? PbFullMarathon { get; set; }
        public string? About { get; set; }
        public string? PhotoUrl { get; set; }
        public string? Accomplishments { get; set; }

        public bool IsEditable { get; set; }
    }
}
