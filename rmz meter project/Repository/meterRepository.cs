using Microsoft.EntityFrameworkCore;
using rmz_meter_project.MeterDbcontext;
using rmz_meter_project.Models.Domain;
using rmz_meter_project.Models.DTO;
using System.Collections;

namespace rmz_meter_project.Repository
{
    public class meterRepository : ImeterRepository
    {
        private readonly meterDbContext meterDbContext;

        public meterRepository(meterDbContext meterDbContext)
        {
            this.meterDbContext = meterDbContext;
        }

        public object Floorlevel(string DateRange)
        {
            var detail = (from f in meterDbContext.floors join z in meterDbContext.zones
                          on f.FloorId equals z.floor.FloorId into ans
                          from a in ans.DefaultIfEmpty()
                          join m in meterDbContext.meters on
                          a.ZoneId equals m.Zone.ZoneId into ans1
                          from b in ans1.DefaultIfEmpty()
                          where b.currentTimestamp >= DateTime.Parse(DateRange)
                          select new
                          {
                              FloorId = f.FloorId,
                              FloorName = f.FloorName,
                              ZoneName = a.ZoneName,
                              MeterDetails = b
                          }
                          ).ToList();
            return detail;

        }

        public object Buildinglevel(string DateRange)
        {
            var result = (from b in meterDbContext.buildings join fl in meterDbContext.floors 
                          on b.BuildingId equals fl.building.BuildingId into ans1
                          from fl in ans1.DefaultIfEmpty() join z in meterDbContext.zones 
                          on fl.FloorId equals z.floor.FloorId into ans2
                          from z in ans2.DefaultIfEmpty()
                          join m in meterDbContext.meters on z.ZoneId equals m.Zone.ZoneId into ans4
                          from m in ans4.DefaultIfEmpty()
                          where m.currentTimestamp >= DateTime.Parse(DateRange)

                          select new
                          {
                              BuildingId = b.BuildingId,
                              BuildingName = b.BuildingName,
                              FloorName = fl.FloorName,
                              ZoneName = z.ZoneName,
                              meterDetail = m


                          }).ToList();
            return result;

        }

        public object Facilitylevel(string DateRange)
        {
            //var result = await meterDbContext.facilities.Include(a => a.buildings).ThenInclude(a => a.Floor).ThenInclude(a => a.zones).ThenInclude(a => a.meters).ToListAsync();
            var result = (from f in meterDbContext.facilities join b in meterDbContext.buildings 
                          on f.FacilityId equals b.Facility.FacilityId into ans1
                          from b in ans1.DefaultIfEmpty() join fl in meterDbContext.floors 
                          on b.BuildingId equals fl.building.BuildingId into ans2
                          from fl in ans2.DefaultIfEmpty()
                          join z in meterDbContext.zones on fl.FloorId 
                          equals z.floor.FloorId into ans3
                          from z in ans3.DefaultIfEmpty()
                          join m in meterDbContext.meters on z.ZoneId equals m.Zone.ZoneId into ans4
                          from m in ans4.DefaultIfEmpty() 
                          where m.currentTimestamp >= DateTime.Parse(DateRange)

                          select new 
                          {
                              FacilityId = f.FacilityId,
                              FacilityName = f.FacilityName,
                              BuildingName = b.BuildingName,
                              FloorName = fl.FloorName,
                              ZoneName = z.ZoneName,
                              meterDetail = m


                          }).ToList();
            return result;
        }

        public object Citylevel(string DateRange)
        {
            var detail = (from c in meterDbContext.cities join f in meterDbContext.facilities
                          on c.cityId equals f.City.cityId into ans1
                          from x in ans1 join b in meterDbContext.buildings on 
                          x.FacilityId equals b.Facility.FacilityId into ans2
                          from y in ans2 join fl in meterDbContext.floors on
                          y.BuildingId equals fl.building.BuildingId into ans3
                          from k in ans3 join z in meterDbContext.zones on 
                          k.FloorId equals z.floor.FloorId into ans4
                          from l in ans4 join m in meterDbContext.meters on 
                          l.ZoneId equals m.Zone.ZoneId into ans5
                          from m in ans5 where m.currentTimestamp>= DateTime.Parse(DateRange)
                          select new
                          {
                              cityId = c.cityId,
                              CityName = c.Cityname,
                              FacilityName = x.FacilityName,
                              BuildingName = y.BuildingName,
                              FloorName = k.FloorName,
                              ZoneName = l.ZoneName,
                              meterDetail = m
                          }
                          ).ToList();
            return detail;
        }

        public object Zonelevel(string DateRange)
        {
            var detail = (from z in meterDbContext.zones
                          join m in meterDbContext.meters on
                          z.ZoneId equals m.Zone.ZoneId into ans1
                          from m in ans1.DefaultIfEmpty()
                          where m.currentTimestamp >= DateTime.Parse(DateRange)
                          select new
                          {
                              zoneId = z.ZoneId,
                              ZoneName = z.ZoneName,
                              MeterDetails = m
                          }
                          ).ToList();
            return detail;

        }

        public object meterlevel(string DateRange)
        {
            return meterDbContext.meters.Where(m => m.currentTimestamp >= DateTime.Parse(DateRange));
        }
    }
}


        