using AutoMapper;
using Base.Api.Data.Models;

namespace Base.Api.ViewModels
{
    public class UpdateDummyVm
    {
        public string Name { get; set; }
    }

    public class UpdateDummyProfile : Profile
    {
        public UpdateDummyProfile()
        {
            CreateMap<UpdateDummyVm, Dummy>();
        }
    }
}
