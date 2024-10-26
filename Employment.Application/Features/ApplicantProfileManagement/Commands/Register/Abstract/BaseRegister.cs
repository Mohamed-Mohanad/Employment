using Employment.Domain.Entities;
using Employment.Domain.Repositories;
using Employment.Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace Employment.Application.Features.Auth.Commands.Register.Abstract
{
    internal abstract class BaseRegister
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly UserManager<User> _userManager;

        public BaseRegister(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            UserManager<User> userManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public abstract RegisterType Type { get; set; }

        public abstract Task<ResponseModel> Register(RegisterCommand command);
    }
}
