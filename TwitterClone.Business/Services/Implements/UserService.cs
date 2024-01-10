using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Dtos.AuthDtos;
using TwitterClone.Business.Exceptions.AppUser;
using TwitterClone.Business.Exceptions.Role;
using TwitterClone.Business.Services.Interfaces;
using TwitterClone.Core;
using TwitterClone.Core.Entities;

namespace TwitterClone.Business.Services.Implements
{
    public class UserService : IUserService
    {
        UserManager<AppUser> _userManager { get; }
        RoleManager<IdentityRole> _roleManager { get; }
        IMapper _mapper { get; }

        public UserService(UserManager<AppUser> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task CreateAsync(RegisterDto dto)
        {
            AppUser user = _mapper.Map<AppUser>(dto);

            var userCreationResult = await _userManager.CreateAsync(user, dto.Password);

            if(!userCreationResult.Succeeded)
            {
                StringBuilder sb = new();

                foreach(var error in userCreationResult.Errors) sb.Append(error.Description + " ");

                throw new UserCreationFailedException(sb.ToString().TrimEnd());
            }

            var roleAssigningResult = await _userManager.AddToRoleAsync(user, nameof(Roles.Member));

            if (!roleAssigningResult.Succeeded)
            {
                StringBuilder sb = new();

                foreach (var error in roleAssigningResult.Errors) sb.Append(error.Description + " ");

                throw new RoleAssigningFailedException(sb.ToString().TrimEnd());
            }
        }
    }
}
