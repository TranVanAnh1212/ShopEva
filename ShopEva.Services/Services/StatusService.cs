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
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StatusService(IStatusRepository statusRepository, IUnitOfWork unitOfWork)
        {
            _statusRepository = statusRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Sys_Status>> GetAllAsync()
        {
            return await _statusRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Sys_Status>> GetManyAsync(int status_of)
        {
            return await _statusRepository.GetManyAsync(x => x.Status_Of == status_of);
        }
    }
}
