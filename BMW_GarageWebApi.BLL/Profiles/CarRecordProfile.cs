using AutoMapper;
using BMW_GarageWebApi.Domain.DTOModels.DTOCarRecord;
using BMW_GarageWebApi.Domain.DTOModels.DTOEmployee;
using BMW_GarageWebApi.Domain.Models;

namespace BMW_GarageWebApi.BLL.Profiles
{
    public class CarRecordProfile : Profile
    {
        public CarRecordProfile()
        {
            CreateMap<CarRecordDTO, CarRecord>();
            CreateMap<CarRecord, CarRecordDTO>();
        }
    }
}
