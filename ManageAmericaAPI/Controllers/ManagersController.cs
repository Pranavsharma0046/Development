using ManageAmericaAPI.Data.Services;
using ManageAmericaAPI.Helpers;
using ManageAmericaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ManageAmericaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {

        public ManagerService _managerService;

        public ManagersController(ManagerService managerService)
        {
            _managerService = managerService;
        }

        /// <summary>
        /// get api for selecting all Available ManagerList
        /// </summary>
        /// <returns>Return list of all available Managers from available model</returns>

        [HttpGet]
        [Route("GetAllAvailableManagers")]
        public IActionResult AvailableManagersList()
        {
            try
            {
                var result = _managerService.AvailableManagersList();
                return Ok(result);
            }
            catch (Exception)
            {
                throw new HttpResponseException("ManagersController:Not Found");
            }
        }
        /// <summary>
        /// get api for selecting Managers by ID
        /// </summary>
        /// <param name="Id">Id of the manager</param>
        /// <returns>Return list of Managers by Id from resgister manager</returns>

        [HttpGet]
        [Route("manager/{Id}")]
        public IActionResult GetManagerById(long Id)
        {
            try
            {
                var result = _managerService.GetManagerById(Id);
                if (result == null) throw new HttpResponseException("ManagersController:Not Found");
                return Ok(result);
            }
            catch (Exception)
            {
                throw new HttpResponseException("ManagersController:Not Found");
            }
        }
       
    }
}
