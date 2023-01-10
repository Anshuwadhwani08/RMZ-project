namespace rmz_meter_project.Models.Domain
{
    public class Floor
    {
        public int FloorId { get; set; }
        public string FloorName { get; set;}
        public Building building { get; set; }
        public ICollection<Zone> zones { get; set; }
    }
}
