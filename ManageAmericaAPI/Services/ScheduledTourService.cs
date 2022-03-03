using ManageAmericaAPI.DataAccess.Repository.ScheduledTour;
using ManageAmericaAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManageAmericaAPI.Helpers;
using ManageAmericaAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace ManageAmericaAPI.Services
{
    public class ScheduledTourService
    {

        private readonly IScheduledTourRepository _scheduledTourRepository;
        private readonly ApplicationDbContext _dbcontext;

        public ScheduledTourService(IScheduledTourRepository scheduledTourRepository, ApplicationDbContext dbcontext)
        {
            _scheduledTourRepository = scheduledTourRepository;
            _dbcontext = dbcontext;
        }


        /// <summary>
        /// Scedule Tour enter by prospect
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable> ScheduledTours(List<ScheduledTourModel> ScheduledTourModel)
        {

            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                List<ScheduledTourModel> result = new List<ScheduledTourModel>();
                foreach (ScheduledTourModel item in ScheduledTourModel)
                {
                    ScheduledTourModel value = new ScheduledTourModel();
                    value.ProspectName = item.ProspectName;
                    value.ProspectEmail = item.ProspectEmail;
                    value.ProspectPhone = item.ProspectPhone;
                    value.ProspectRemarks = item.ProspectRemarks;
                    value.TourDate= item.TourDate; 
                    value.StartTime = item.StartTime;
                    value.EndTime = item.EndTime;
                    value.CreatedBy = item.CreatedBy;
                    value.CreatedDate = item.CreatedDate;
                    value.PropertyId = item.PropertyId;
                    value.ManagerId =  _dbcontext.Availablity.Select(x => x.ManagerId).FirstOrDefault();
                    result.Add(value);
                }
                return await _scheduledTourRepository.ScheduledTours(result);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("ScheduledTourService: Conflict Arises In adding Items");
            }


        }

        /// <summary>
        /// get all schedule Tours
        /// </summary>
        /// <returns>list of tours</returns>
        public async Task<IEnumerable> GetScheduledTourList()
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return await _scheduledTourRepository.GetScheduledTourList();
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("ScheduledTourService: Conflict Arises In adding Items");
            }
        }

        public  List<ScheduledTourModel> GetScheduledTourListAll()
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return  _scheduledTourRepository.GetScheduledTourListAll ();
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("ScheduledTourService: Conflict Arises In adding Items");
            }
        }
        /// <summary>
        /// get all schedule tour API
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>lost of tours by ID</returns>

        public  Task<IEnumerable> GetScheduledTourById(long Id)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return  _scheduledTourRepository.GetScheduledTourById(Id); 
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("ScheduledTourService: Conflict Arises In adding Items");
            }
                     
        }
        /// <summary>
        /// Get Tour By propety Id
        /// </summary>
        /// <param name="PropertyId"></param>
        /// <returns></returns>
        /// <exception cref="ConflictException"></exception>
        public Task<IEnumerable> GetScheduledTourByPropetyId(long PropertyId)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return _scheduledTourRepository.GetScheduledTourByPropetyId(PropertyId);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("ScheduledTourService: Conflict Arises In adding Items");
            }

        }

        /// <summary>
        /// update API for reschedule Tour by Managers
        /// </summary>
        /// <param name="Id"></param>
        public ScheduledTourModel ReScheduledTourByManager(long Id, ReScheduledTourModel reScheduledTourModel)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return _scheduledTourRepository.ReScheduledTourByManager(Id, reScheduledTourModel);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("ScheduledTourService: Conflict Arises In adding Items");
            }         
            
        }
        /// <summary>
        /// update API for reschedule Tour by prospects
        /// </summary>
        /// <param name="Id"></param>

        public ScheduledTourModel ReScheduledTourByProspect(long Id, ReScheduledTourModelProspect reScheduled)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return _scheduledTourRepository.ReScheduledTourByProspect(Id, reScheduled);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("ScheduledTourService: Conflict Arises In adding Items");
            }
                       
        }
        /// <summary>
        /// update API for cancel schedule Tour by prospects
        /// </summary>
        /// <param name="Id"></param>
        public ScheduledTourModel CancelScheduledTourByProspect(long Id, CancelScheduledTourProspectModel cancelScheduledTour)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return _scheduledTourRepository.CancelScheduledTourByProspect(Id, cancelScheduledTour);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("ScheduledTourService: Conflict Arises In adding Items");
            }
                     
        }
        /// <summary>
        /// update API for cancel schedule Tour by Managers
        /// </summary>
        /// <param name="Id"></param>
        public ScheduledTourModel CancelScheduledTourByManager(long Id, CancelScheduledTourModel cancelScheduled )
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return _scheduledTourRepository.CancelScheduledTourByManager(Id, cancelScheduled);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("ScheduledTourService: Conflict Arises In adding Items");
            }
          
       
        }
        /// <summary>
        /// Update ReAssigned Manager
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="reassignedModel"></param>
        /// <returns></returns>
        /// <exception cref="ConflictException"></exception>
        public ScheduledTourModel ReAssignedManagers(long Id, ReassignedModel reassignedModel)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return _scheduledTourRepository.ReAssignedManagers(Id, reassignedModel);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("ScheduledTourService: Conflict Arises In adding Items");
            }               

        }
        /// <summary>
        /// Get Manager list
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ConflictException"></exception>
        public Task<IEnumerable> ManagersList()

        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return _scheduledTourRepository.ManagersList();
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("ScheduledTourService: Conflict Arises In adding Items");
            }
           
        }
        /// <summary>
        /// Default calendar in Tour for manager i.e Apple or google calendar
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="DefaultCalendar"></param>
        /// <returns></returns>
        /// <exception cref="ConflictException"></exception>
        public ManagerModel SetDefaultCalendar(long Id,string DefaultCalendar)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return _scheduledTourRepository.SetDefaultCalendar(Id, DefaultCalendar);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("ScheduledTourService: Conflict Arises In adding Items");
            }
         

        }

    }
}
