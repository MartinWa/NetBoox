namespace NetBoox.AutoMapper
{
    public interface IMapperFacade
    {
        TDestination Map<TDestination>(object source);
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
