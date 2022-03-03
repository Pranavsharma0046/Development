using ManageAmericaAPI.Models;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageAmericaAPI.DataAccess.Repository.Manager
{
    public interface IManagerRepository
    {
        Task<IEnumerable> AddManager(ManagerModel _manager);
        List<ManagerModel> AvailableManagersList();
        ManagerModel GetManagerById(long Id);
    }
}
