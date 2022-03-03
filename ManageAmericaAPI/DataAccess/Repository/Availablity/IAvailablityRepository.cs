using ManageAmericaAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ManageAmericaAPI.DataAccess.Repository.Availablity

{
    public interface IAvailablityRepository
    {
        Task<IEnumerable<GetAvailablityModel>> GetAvailablities();
        Task<IEnumerable> GetAllAvailablities();
        AvailablityModel GetAvailablityById(long Id);
        Task<IEnumerable> GetAvailablityByManagerId(long ManagerId);
        AvailablityModel UpdateById(long Id, AvailablityUpdateModel _availablity);

        AvailablityModel DeleteAvailablityById(long AvailablityId, long ReccurenceId, AvailablityDeleteModel availablityDeleteModel);
        Task<IEnumerable> GetPropertyByManagerId(long ManagerId);
        Task<IEnumerable<GetAvailablityModel>> AvailablityByIds(long ManagerId, long PropertyId);
        Task<IEnumerable<GetAvailablityModel>> AvailablityByManagerId(long ManagerId);
        Task<IEnumerable> GetAvailablity(long PropertyId, long ManagerId);

    }
}
