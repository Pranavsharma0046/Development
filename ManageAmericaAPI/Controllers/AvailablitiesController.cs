using ManageAmericaAPI.Helpers;
using ManageAmericaAPI.Models;
using ManageAmericaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reflection;


namespace ManageAmericaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class availablitiesController : ControllerBase
    {
        private readonly AvailablityService _availablityService;

        public availablitiesController(AvailablityService availablityService)
        {
            _availablityService = availablityService;
        }
        /// <summary>
        /// Insert Availablity by Manager
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("availablity")]
       
        public async Task<IActionResult> SetAvailablity(List<SetAvailablity> avail)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var result = await _availablityService.SetAvailabity(avail);
                return Ok(result);

                
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new UnSucessFullException("availablitiesController: UnSuccessfull Attempt");
            }
        }
        /// <summary>
        /// Get API for selecting all avalabalities In Datewise,ManagerId and PropertyId format
        /// </summary>
        /// <returns>list of all available managers</returns>

        [HttpGet]
        [Route("availablities")]
        public async Task<IEnumerable<GetAvailablityModel>> GetAvailablities()
        {
            try
            {
                Logger.WriteLog("started",MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return await _availablityService.GetAvailablities();

            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new HttpResponseException("availablitiesController: Not Found");
            }
        }

        /// <summary>
        /// Get API for selecting all avalabalities
        /// </summary>
        /// <returns>list of all available managers</returns>

        [HttpGet]
        [Route("all-availablities")]
        public async Task<IEnumerable> GetAllAvailablities()
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return await _availablityService.GetAllAvailablities();

            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new HttpResponseException("availablitiesController: Not Found");
            }
        }


        // <summary>
        /// Get Availablity by IDs
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>list of available managers by id</returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAvailablityById(long id)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var result = _availablityService.GetAvailablityById(id);
                if (result == null) throw new InvalidException("availablitiesController: Please Enter ID");

                return Ok(result);
            }
            catch (Exception ex )
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new HttpResponseException("availablitiesController: Not Found");
            }
        }

        // <summary>
        /// Get Availablity by ManagerId
        /// </summary>
        /// <param name="ManagerId"></param>
        /// return availablites by ManagerId


        [HttpGet]
        [Route("Manager/{ManagerId}")]
        public IActionResult GetAvailablityByManagerId(long ManagerId)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var result = _availablityService.GetAvailablityByManagerId(ManagerId);
                if (result == null) throw new InvalidException("availablitiesController: Please Enter Manager ID");

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new HttpResponseException("availablitiesController: Not Found");
            }
        }
        /// <summary>
        ///  Update the availablity by id
        /// </summary>
        /// <param name="Id">Availablity ID</param>
        /// <returns></returns>
        [HttpPut]
        [Route("update-availablity/{id}")]
        public IActionResult UpdateById(long id, AvailablityUpdateModel availablity)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var update = _availablityService.UpdateById(id, availablity);
                return base.Ok(update);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new InvalidException("availablitiesController: Invalid Id");
            }
        }

        /// <summary>
        ///  Delete the availablity by id
        /// </summary>
        /// <param name="Id">Availablity ID</param>

        [HttpDelete]
        [Route("delete-availablity/{AvailablityId}/{ReccurenceId}")]
        public IActionResult DeleteAvailablity(long AvailablityId, long ReccurenceId, AvailablityDeleteModel availablityDeleteModel)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var resp = _availablityService.DeleteAvailablityById(AvailablityId, ReccurenceId, availablityDeleteModel);
                return Ok("availablitiesController: SuccessFully Deleted");
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new InvalidException("availablitiesController: Invalid Id");
            }
        }

        [HttpGet]
        [Route("property-manager/{ManagerId}")]
        public IActionResult GetPropertyByManagerId(long ManagerId)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var result = _availablityService.GetPropertyByManagerId(ManagerId);
                if (result == null) throw new InvalidException("availablitiesController: Please Enter Manager ID");

                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new HttpResponseException("availablitiesController: Not Found");
            }
        }


        // <summary>
        /// Get Availablity by ManagerId and PropertyId
        /// </summary>
        /// <param name="ManagerId,PropertyId"></param>
        [HttpGet]
        [Route("availablity/{ManagerId}/{PropertyId}")]
        public async Task<IEnumerable<GetAvailablityModel>> AvailablityByIds(long ManagerId, long PropertyId)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return await _availablityService.AvailablityByIds(ManagerId, PropertyId);

            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new HttpResponseException("availablitiesController: Not Found");
            }
        }
        // <summary>
        /// Get Availablity by ManagerId 
        /// </summary>
        /// <param name="ManagerId"></param>
        [HttpGet]
        [Route("availablity/{ManagerId}")]
        public async Task<IEnumerable<GetAvailablityModel>> AvailablityByManagerId(long ManagerId)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return await _availablityService.AvailablityByManagerId(ManagerId);

            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new HttpResponseException("availablitiesController: Not Found");
            }
        }

        // <summary>
        /// Get Availablity Time by ManagerId and PropertyId 
        /// </summary>
        /// <param name="ManagerId & PropertyId"></param>
        [HttpGet]
        [Route("availablity-time/{PropertyId}/{ManagerId}")]
        public async Task<IEnumerable> GetAvailablity(long PropertyId, long ManagerId)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return await _availablityService.GetAvailablity(PropertyId, ManagerId);

            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new HttpResponseException("availablitiesController: Not Found");
            }
        }

    }
}
