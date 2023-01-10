using rmz_meter_project.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace rmz_meter_project.Models.DTO
{
    public class ResponseDTO
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public ICollection<Facility> facilities { get; set; }
        public ICollection<Building> buildings { get; set; }
        public ICollection<Floor> floors { get; set; }
        public ICollection<Zone> zones { get; set; }
        public ICollection<meter> meters { get; set; }

    }
}
