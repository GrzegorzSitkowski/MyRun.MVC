using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRun.Application.Race
{
    public class RaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Number { get; set; }
        public string? Place { get; set; }
        public string Distance { get; set; } = default!;
        public string? Result { get; set; }
        public string? AveragePace { get; set; }
        public DateTime? Date { get; set; }
        public string? Note { get; set; }

        public bool IsEditable { get; set; }
    }
}
