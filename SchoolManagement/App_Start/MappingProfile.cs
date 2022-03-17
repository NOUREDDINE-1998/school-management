using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolManagement.Models;
using SchoolManagement.DTOs;

namespace SchoolManagement.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Etudiant, EtudiantsDTO>();
            Mapper.CreateMap<EtudiantsDTO, Etudiant>();
        }
    }
}