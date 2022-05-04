using eShop.Core.Interfaces.Repositories;
using eShop.Core.Interfaces.Services;
using eShop.Core.Models;
using eShop.SharedKernel.Interfaces;
using eShop.SharedKernel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Core.Services
{
    public class UserService : BaseService<UserModel>, IUserService           
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override IEnumerable<UserModel> GetList()
        {
            return _unitOfWork.UserRepository.GetList();
        }
    }
}
