namespace rmz_meter_project.Models.Domain
{
    public class meter
    {
        public int meterId { get; set; }
        public string meterName { get; set;}
        public string meterType { get; set;}

        public DateTime installationTimestamp { get; set; }

        public DateTime currentTimestamp { get; set; }

        public long meterreading { get; set; }

        public Zone Zone { get; set; }


    }
}
