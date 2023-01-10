namespace rmz_meter_project.Models.Domain
{
    public class Zone
    {
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public string TypeofmeterPresent { get; set; }
       public Floor floor { get; set; }
        public ICollection<meter> meters { get; set; }
    }
}
