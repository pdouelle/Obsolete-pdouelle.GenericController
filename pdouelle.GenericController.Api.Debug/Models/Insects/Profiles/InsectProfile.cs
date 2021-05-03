using AutoMapper;
using pdouelle.GenericController.Api.Debug.Models.Insects.Entities;
using pdouelle.GenericController.Api.Debug.Models.Insects.Models;
using pdouelle.GenericController.Api.Debug.Models.Insects.Models.Commands.CreateInsect;
using pdouelle.GenericController.Api.Debug.Models.Insects.Models.Commands.PatchInsect;
using pdouelle.GenericController.Api.Debug.Models.Insects.Models.Commands.UpdateInsect;

namespace pdouelle.GenericController.Api.Debug.Models.Insects.Profiles
{
    public class InsectProfile : Profile

    {
        public InsectProfile()
        {
            CreateMap<Insect, InsectDto>();
            CreateMap<CreateInsectCommandModel, Insect>();
            CreateMap<UpdateInsectCommandModel, Insect>();
            CreateMap<PatchInsectCommandModel, Insect>();
        }
    }
}