using AutoMapper;
using BMW_GarageWebApi.Domain.DTOModels.DTOCarRepair;
using BMW_GarageWebApi.Domain.Models;

namespace BMW_GarageWebApi.BLL.Profiles
{
    public class CarRepairProfile : Profile
    {
        public CarRepairProfile() 
        {
            CreateMap<CarRepairDTO, CarRepair>();
            CreateMap<CarRepair, CarRepairDTO>();
        }
    }
}
