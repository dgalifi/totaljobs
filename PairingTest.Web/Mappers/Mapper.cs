using System.Diagnostics.CodeAnalysis;

namespace PairingTest.Web.Mappers
{
    public class Mapper : IMapper
    {
        [ExcludeFromCodeCoverage]
        public T2 Map<T1, T2>(T1 source)
        {
            return AutoMapper.Mapper.Map<T1, T2>(source);
        }
    }
}