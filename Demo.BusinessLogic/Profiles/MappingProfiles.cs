using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demo.BusinessLogic.DataTransferObjescts.EmployeeDtos;
using Demo.DataAccessLayer.Models.EmployeeModel;

namespace Demo.BusinessLogic.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles() {
            CreateMap<Employees, EmployeeDto>()
                .ForMember(destination=>destination.Gender , Options=>Options.MapFrom(src=>src.Gender))
                .ForMember(destination=>destination.EmployeeType , Options=>Options.MapFrom(src=>src.EmployeeType));
            CreateMap<Employees, EmployeeDetailsDto>()
                .ForMember(destination => destination.Gender, Options => Options.MapFrom(src => src.Gender))
                .ForMember(destination => destination.EmployeeType, Options => Options.MapFrom(src => src.EmployeeType))
                .ForMember(destination => destination.HiringDate, Options => Options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)));
                
            CreateMap<CreatedEmployeeDto, Employees>()
                .ForMember(destination => destination.HiringDate, Options => Options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

            CreateMap<UpdatedEmployeeDto, Employees>()
                .ForMember(destination => destination.HiringDate, Options => Options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

        }
    }
}
