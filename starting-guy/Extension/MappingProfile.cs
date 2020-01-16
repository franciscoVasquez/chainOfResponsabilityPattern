using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using responsibilityPattern.Models;
using starting_guy.Models;

namespace starting_guy.Extension
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            AnimalProfile();
        }

        private void AnimalProfile()
        {
            CreateMap<AnimalDto ,Animal>()
                .ForMember(dest => dest.Food,
                    opt => opt.MapFrom(src => src.Food))
                .ForMember(dest => dest.Specie,
                    opt => opt.MapFrom(src => src.Specie))
                .ReverseMap();
        }
    }
}