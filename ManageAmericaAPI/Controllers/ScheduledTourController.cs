using ManageAmericaAPI.Data.Services;
using ManageAmericaAPI.Helpers;
using ManageAmericaAPI.Models;
using ManageAmericaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace ManageAmericaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduledTourController : ControllerBase
    {

        private readonly ScheduledTourService _scheduledTourService;
        private readonly ManagerService _managerService;


        public ScheduledTourController(ScheduledTourService scheduledTourService, ManagerService managerService)
        {
            _scheduledTourService = scheduledTourService;
            _managerService = managerService;
        }


        /// <summary>
        /// Add Tour Detail API
        /// </summary>        
        /// <returns></returns>

        [HttpPost]
        [Route("scheduletour")]
        public async Task<IActionResult> ScheduledTours(List<ScheduledTourModel> scheduledTourModel)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var response = await _scheduledTourService.ScheduledTours(scheduledTourModel);
                return Ok(response);
            }
            catch (Exception)
            {

                throw new UnSucessFullException("ScheduledTourController: UnSuccessfull Attempt");
            }
        }

        /// <summary>
        /// Get all Tour Detail API
        /// </summary>
        /// <returns>List of all tours</returns>
        [HttpGet]
        [Route("tourDetails")]
        public IActionResult GetScheduledTourList()
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var result = _scheduledTourService.GetScheduledTourList();
                return Ok(result);
            }
            catch (Exception)
            {

                throw new HttpResponseException("ScheduledTourController: Not Found");
            }
        }
        [HttpGet]
        [Route("GetScheduledTourList")]
        public IActionResult GetScheduledTourListAll()
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var result = _scheduledTourService.GetScheduledTourListAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new HttpResponseException("ScheduledTourController: Not Found");
            }
        }

        /// <summary>
        ///  Get scheduled Tour ById
        /// </summary>
        /// <returns>single tour by Id</returns>
        [HttpGet]
        [Route("tourDetail/{Id}")]
        public IActionResult GetScheduledTourById(long Id)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var result = _scheduledTourService.GetScheduledTourById(Id);
                if (result == null) throw new InvalidException("ScheduledTourController: Invalid Id : Please Enter Correct Id");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new InvalidException("ScheduledTourController: Invalid Id : Please Enter Correct Id");
            }
        }
        /// <summary>
        ///  Get scheduled Tour ById
        /// </summary>
        /// <returns>single tour by Id</returns>
        [HttpGet]
        [Route("tourDetail/Property/{PropertyId}")]
        public IActionResult GetScheduledTourByPropertyId(long PropertyId)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var result = _scheduledTourService.GetScheduledTourByPropetyId(PropertyId);
                if (result == null) throw new InvalidException("ScheduledTourController: Invalid Id : Please Enter Correct Id");
                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new InvalidException("ScheduledTourController: Invalid Id : Please Enter Correct Id");
            }
        }

        /// <summary>
        /// Rescheduled-Tour-By-Manager API
        /// </summary>
        /// <returns></returns>

        [HttpPut]
        [Route("rescheduled-tour-manager/{Id}")]
        public IActionResult ReScheduledByManager(long Id, ReScheduledTourModel reScheduledTourModel)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var update = _scheduledTourService.ReScheduledTourByManager(Id, reScheduledTourModel);
                return Ok("ScheduledTourController: SuccessFully Updated");
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new InvalidException("ScheduledTourController: Id Not Found");
            }
        }

        /// <summary>
        /// Rescheduled-Tour-ByProspect API
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        [HttpPut]
        [Route("rescheduled-tour-prospect/{Id}")]
        public IActionResult ReScheduledByProspect(long Id, ReScheduledTourModelProspect reScheduled)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var update = _scheduledTourService.ReScheduledTourByProspect(Id, reScheduled);
                return Ok("ScheduledTourController: SuccessFully Updated");
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new InvalidException("ScheduledTourController: Id Not Found");
            }
        }

        /// <summary>
        /// Cancel-Tour-By Prospect API
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="scheduledTourService"></param>
        /// <returns></returns>

        [HttpPut]
        [Route("cancel-tour-prospect/{Id}")]
        public IActionResult CancelScheduledMeetingByProspect(long Id, CancelScheduledTourProspectModel cancelScheduledTour)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var resp = _scheduledTourService.CancelScheduledTourByProspect(Id, cancelScheduledTour);
                return Ok("ScheduledTourController: SuccessFully Cancelled");
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new UnSucessFullException("ScheduledTourController: unSuccessFul Attempt");
            }
        }

        /// <summary>
        /// Cancel-Tour-By manager
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="scheduledTourService"></param>
        /// <returns></returns>

        [HttpPut]
        [Route("cancel-tour-manager/{Id}")]
        public IActionResult CancelScheduledMeetingByManager(long Id, CancelScheduledTourModel cancelScheduled)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var resp = _scheduledTourService.CancelScheduledTourByManager(Id, cancelScheduled);
                return Ok("ScheduledTourController: SuccessFully Cancelled");
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new UnSucessFullException("ScheduledTourController: unSuccessFul Attempt");
            }
        }
       
        /// <summary>
        /// ReAssigned Available Managers
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="managerModel"></param>
        /// <param name="scheduledTour"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("reassigned-manager/{Id}")]
        public IActionResult ReAssignedManagers(long Id, ReassignedModel reassignedModel)

        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var result = _scheduledTourService.ReAssignedManagers(Id, reassignedModel);
                return Ok("ScheduledTourController: SuccessFully ReAssigned");
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new UnSucessFullException("ScheduledTourController: unSuccessFul Attempt");
            }
        }
        /// <summary>
        /// available Managers
        /// </summary>
        /// <returns></returns>
        /// <exception cref="UnSucessFullException"></exception>
        [HttpGet]
        [Route("available-managers")]
        public IActionResult ManagersList()
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var result = _scheduledTourService.ManagersList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new UnSucessFullException("scheduledtourController:unSuccessful Attempt");
            }
        }
        

        /// <summary>
        /// update Calendar
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="DefaultCalendar"></param>
        /// <returns></returns>
        /// <exception cref="UnSucessFullException"></exception>
        [HttpPut]
        [Route("set-default-calendar")]
        public IActionResult SetDefaultCalendar(long Id , string DefaultCalendar)

        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var result = _scheduledTourService.SetDefaultCalendar(Id, DefaultCalendar);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new UnSucessFullException("ScheduledTourController: unSuccessFul Attempt");
            }
        }


    }
}
