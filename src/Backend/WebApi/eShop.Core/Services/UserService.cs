using eShop.Core.Interfaces.Repositories;
using eShop.Core.Interfaces.Services;
using eShop.Core.Models;
using eShop.SharedKernel.Services;

namespace eShop.Core.Services
{
    public class UserService : BaseService<UserModel>, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
