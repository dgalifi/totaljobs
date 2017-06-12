using System.Diagnostics.CodeAnalysis;
using PairingTest.Web.Models;
using PairingTest.Web.Services.Models;

namespace PairingTest.Web.Mappers
{
    [ExcludeFromCodeCoverage]
    public static class MapperConfig
    {
        public static void Setup()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Questionnaire, QuestionnaireViewModel>()
                .ForMember(x => x.QuestionnaireTitle, opts => opts.MapFrom(s => s.Title));
            });
        }
    }
}