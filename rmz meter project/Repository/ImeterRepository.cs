using rmz_meter_project.Models.Domain;
using rmz_meter_project.Models.DTO;
using System.Collections;

namespace rmz_meter_project.Repository
{
    public interface ImeterRepository
    {
        public object Citylevel(string DateRange);
        public object Facilitylevel(string DateRange);
        public object Buildinglevel(string DateRange);

        public object Floorlevel(string DateRange);
        public object Zonelevel(string DateRange);
        public object meterlevel(string DateRange);
    }

    
}
