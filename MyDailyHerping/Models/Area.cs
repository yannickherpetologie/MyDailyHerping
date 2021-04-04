using System.ComponentModel.DataAnnotations;

namespace MyDailyHerping.Models
{
    class Area
    {
        [Key]
        public int AreaID { get; set; }
        public string ObjectID { get; set; }
        public string Name { get; set; }
        public double Long { get; set; }
        public double Lat { get; set; }
        public string Type { get; set; }
        public Observation Observation { get; set; }
    }
}
