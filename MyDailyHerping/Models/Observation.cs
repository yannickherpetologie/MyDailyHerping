using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyDailyHerping.Models
{
    class Observation
    {
        public int ObservationID { get; set; }
        public string Species { get; set; }
        public string CommonName { get; set; }
        public int QtAdulte { get; set; }
        public int QtMale { get; set; }
        public int QtFemale { get; set; }
        public int QtJuvenile { get; set; }
        public int QtLarva { get; set; }
        public int QtEggs { get; set; }
        public int QtReproduction { get; set; }
        public int QtShed { get; set; }

        public int AreaID { get; set; }
        public Area Area { get; set; }
    }
}
