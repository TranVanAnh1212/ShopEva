using ShopEva.Data.Infrastructure;
using ShopEva.Data.IRepositories;
using ShopEva.Data.Repositories;
using ShopEva.Models.Model;
using ShopEva.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEva.Services.Services
{
    public class ErrorService : IErrorService
    {
        private readonly IErrorRepository _errorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            _errorRepository = errorRepository;
            _unitOfWork = unitOfWork;
        }

        public Error Add(Error err)
        {
            return _errorRepository.Add(err);
        }

        public Task<IEnumerable<Error>> GetAll()
        {
            return Task.FromResult(_errorRepository.GetAll());
        }

        public void SaveChanged()
        {
            _unitOfWork.Commit();
        }
    }
}
