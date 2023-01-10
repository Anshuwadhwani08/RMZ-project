using System.ComponentModel.DataAnnotations.Schema;

namespace rmz_meter_project.Models.Domain
{
    public class Facility
    {
        
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }

        public City City { get; set; }

        public ICollection<Building> buildings { get; set; }
    }
}
