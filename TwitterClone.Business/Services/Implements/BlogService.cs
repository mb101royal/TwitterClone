using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Dtos.BlogDtos;
using TwitterClone.Business.Repositories.Interfaces;
using TwitterClone.Business.Services.Interfaces;
using TwitterClone.Core.Entities;

namespace TwitterClone.Business.Services.Implements
{
    public class BlogService : IBlogService
    {
        readonly string userId;

        IBlogRepository _blogRepo { get; }
        IHttpContextAccessor _contextAccessor { get; }
        UserManager<AppUser> _userManager { get; }

        public BlogService(IBlogRepository blogRepo, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager)
        {
            _blogRepo = blogRepo;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
            // Catch from Token service
            /* username = _contextAccessor.HttpContext?.User.Claims.First(x => x.Type == ClaimTypes.Name).Value ?? throw new NullReferenceException();*/
            userId = _contextAccessor.HttpContext?.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value ?? throw new NullReferenceException();
        }

        public async Task Create(BlogCreateDto dto)
        {
            Blog newBlog = new()
            {
                AppUserId = userId,
                Content = dto.Content
            };

            await _blogRepo.CreateAsync(newBlog);

            await _blogRepo.SaveAsync();
        }
    }
}
