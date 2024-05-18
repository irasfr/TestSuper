using AutoMapper;
using Application.Common;
using Application.Commands;

namespace WebApi.Models
{
    public class CreateInfo : IMapWith<Post>
    {
        public CreateInfo(string name, string id)
        {
            this.Name = name;
            this.Id = id;

        }
        public string Name { get; set; }
        public string Id { get; set; }
        public Guid UserId { get; internal set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateInfo, Post>()
                .ForMember(x => x.Id,
                    opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name,
                    opt => opt.MapFrom(x => x.Name));
        }
    }
}