using AutoMapper;
using ETS.Model.Dtos.Structure;
using ETS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS.Business.MapperProfiles
{
    public class StructureMapperProfile : Profile
    {
        public StructureMapperProfile() 
        { 
            CreateMap<Structure, StructureGetDto>();
            CreateMap<StructurePostDto, Structure>();
            CreateMap<StructurePutDto, Structure>();
        }
        
    }
}
