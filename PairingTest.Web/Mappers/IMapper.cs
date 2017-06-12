namespace PairingTest.Web.Mappers
{
    public interface IMapper
    {
        T2 Map<T1, T2>(T1 source);
    }
}
