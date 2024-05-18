using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace WebApi.Filters
{
    public class CacheAuthorizationFilterAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IMemoryCache _cache;

        public CacheAuthorizationFilterAttribute(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!_cache.TryGetValue("AuthorizedUser", out string authorizedUser))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}