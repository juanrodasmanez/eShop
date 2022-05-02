using eShop.Core.Interfaces.Repositories;
using eShop.Core.Interfaces.Services;
using eShop.Core.Models;
using eShop.SharedKernel.Services;

namespace eShop.Core.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
