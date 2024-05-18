using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Application.Commands;
using WebApi.Models;
using WebApi.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    public class Controller : BaseController
    {
        private readonly IMapper _mapper;

        public Controller(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<PostHandler>> GetAll()
        {
            var query = new Get
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostHandler>> Get(string name)
        {
            var query = new Get
            {
                UserId = UserId,
                Name = name
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateInfo create)
        {
            var command = _mapper.Map<CreateInfo>(create);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        private readonly IMemoryCache _cache;

        public Controller(IMemoryCache memoryCache) => _cache = memoryCache;


        [HttpPost]
        [ServiceFilter(typeof(CacheAuthorizationFilterAttribute))]
        public IActionResult Post([FromBody] string data)
        {
            string authorizedUser = _cache.Get<string>("AuthorizedUser");

            if (!string.IsNullOrEmpty(authorizedUser))
            {
                return Ok($"Data received: {data}");
            }
            else
            {
                return Unauthorized("Unauthorized access");
            }
        }


    }
}