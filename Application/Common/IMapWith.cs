using AutoMapper;

namespace Application.Common
{
    internal interface IMapWith<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());

    }
}
