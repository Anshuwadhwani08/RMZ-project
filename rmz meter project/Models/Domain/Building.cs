namespace rmz_meter_project.Models.Domain
{
    public class Building
    {
        public int BuildingId { get; set; }
        public string BuildingName { get; set;}

        public Facility? Facility { get; set; }
        public ICollection<Floor> Floor { get; set; }

    }
}
