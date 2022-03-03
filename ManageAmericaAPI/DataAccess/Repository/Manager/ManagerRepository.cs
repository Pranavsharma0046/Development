using ManageAmericaAPI.Data;
using ManageAmericaAPI.Helpers;
using ManageAmericaAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageAmericaAPI.DataAccess.Repository.Manager
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public ManagerRepository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<IEnumerable> AddManager(ManagerModel _manager)
        {
            try
            {
                await _dbcontext.Manager.AddAsync(_manager);
                await _dbcontext.SaveChangesAsync();
                return ("SuccessfullY Added");
            }
            catch (Exception)
            {
                throw new UnSucessFullException("ManagerRepository: UnSuccessFull Attempt");
            }
        }
        public List<ManagerModel> AvailableManagersList()
        {
            try
            {
                var resp = _dbcontext.Manager.Where(p => p.IsActive == true).ToList();
                return resp;
            }
            catch
            {
                throw new HttpResponseException("ManagerRepository: not found");
            }

        }
        public ManagerModel GetManagerById(long Id)
        {
            try
            {
                return _dbcontext.Manager.FirstOrDefault(x => x.Id == Id);
            }
            catch (Exception)
            {
                throw new HttpResponseException("ManagerRepository: not found");
            }
        }


    }


}
