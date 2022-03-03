using ManageAmericaAPI.DataAccess.Repository.Manager;
using ManageAmericaAPI.Helpers;
using ManageAmericaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageAmericaAPI.Data.Services
{
    public class ManagerService
    {

        private readonly IManagerRepository _managerRepository;



        public ManagerService(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public void AddManager(ManagerModel _manager)
        {
            try
            {
                var manager = new ManagerModel()
                {
                    FirstName = _manager.FirstName,
                    MiddleName = _manager.MiddleName,
                    LastName = _manager.LastName,
                    Email = _manager.Email,
                    PhoneNumber = _manager.PhoneNumber,
                    IsActive = _manager.IsActive,
                };
                _managerRepository.AddManager(_manager);

            }
            catch (Exception)
            {
                throw new UnSucessFullException("ManagerService: UnSuccessfull");
            }
        }
        public List<ManagerModel> AvailableManagersList()

        {
            try
            {
                return _managerRepository.AvailableManagersList();
            }
            catch (Exception)
            {
                throw new ConflictException("ManagerService: Conflict Arises In adding Items");
            }

        }

        public ManagerModel GetManagerById(long Id)
        {
            try
            {
                return _managerRepository.GetManagerById(Id);
            }
            catch (Exception)
            {
                throw new ConflictException("ManagerService: Conflict Arises In adding Items");
            }

        }


    }
}
