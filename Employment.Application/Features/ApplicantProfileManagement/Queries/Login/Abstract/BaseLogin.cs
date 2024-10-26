using Employment.Application.Authentication;
using Employment.Domain.Entities;
using Employment.Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Employment.Application.Features.ApplicantProfileManagement.Queries.Login.Abstract
{
    internal abstract class BaseLogin
    {
        protected readonly IMapper _mapper;
        protected readonly UserManager<User> _userManager;
        protected readonly IJwtProvider _jwtProvider;

        public BaseLogin(
            IMapper mapper,
            UserManager<User> userManager,
            IJwtProvider jwtProvider)
        {
            _mapper = mapper;
            _userManager = userManager;
            _jwtProvider = jwtProvider;
        }

        public abstract LoginType Type { get; set; }

        public abstract Task<ResponseModel<LoginQueryResponse>> Login(LoginQuery query);
    }
}
