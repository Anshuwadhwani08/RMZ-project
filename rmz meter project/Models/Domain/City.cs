namespace rmz_meter_project.Models.Domain
{
    public class City
    {

        public int cityId { get; set; }

        public string Cityname { get; set; }

        public ICollection<Facility> facilities { get; set; }


    }
}
