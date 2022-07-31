using Application.Dtos.JobOfferDtos;
using AutoMapper;
using DAL.Entities.JobOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    internal class JobOfferProfile : Profile
    {
        public JobOfferProfile()
        {
            CreateMap<JobOffer, JobOfferRequestDto>()
                .ReverseMap();
        }
    }
}
