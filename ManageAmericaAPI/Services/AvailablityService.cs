using ManageAmericaAPI.Data;
using ManageAmericaAPI.DataAccess.Repository.Availablity;
using ManageAmericaAPI.Helpers;
using ManageAmericaAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace ManageAmericaAPI.Services
{
    public class AvailablityService
    {
        private readonly IAvailablityRepository _availablityRepository;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AvailablityService(IAvailablityRepository availablityRepository, ApplicationDbContext context,IConfiguration configuration)
        {
            _availablityRepository = availablityRepository;
            _context = context;
            _configuration = configuration;
        }
        /// <summary>
        /// Insert Availablity
        /// Update existing record
        /// </summary>
        /// <param name="avail"></param>
        /// <returns></returns>
        /// <exception cref="ConflictException"></exception>
        public async Task<IEnumerable> SetAvailabity(List<SetAvailablity> avail)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                int months = Convert.ToInt32( _configuration.GetSection("MySettings").GetSection("Months").Value);
                int AddDays = Convert.ToInt32(_configuration.GetSection("MySettings").GetSection("AddDays").Value);
                int Takes = Convert.ToInt32(_configuration.GetSection("MySettings").GetSection("Takes").Value);
                var result = new List<AvailablityModel>();

                AvailablityModel avail1 = null;
                for (int i = 0; i < avail.Count; i++)
                {
                    foreach (var item in avail[i].availablity)
                    {
                        var data = _context.Availablity.Where(p => p.Id == item.Id).FirstOrDefault();
                        if (data == null)
                        {
                            if (item.IsReccurence == true)
                            {

                                avail1 = new AvailablityModel();
                                avail1.ManagerId = item.ManagerId;
                                avail1.Date = item.Date;
                                avail1.PropertyId = item.PropertyId;
                                avail1.ToDate = item.ToDate;
                                avail1.FromDate = item.FromDate;
                                avail1.ToTime = item.ToTime;
                                avail1.FromTime = item.FromTime;
                                avail1.CreatedBy = item.ManagerId;
                                avail1.CreatedDate = item.CreatedDate;
                                avail1.IsReccurence = item.IsReccurence;
                                avail1.IsDeleted = false;
                                //set reccurennce 1 month
                                var StartDate = item.FromDate;
                                var SeriesEndDate = StartDate.AddMonths(months);
                                List<DateTime> dates = new List<DateTime>();

                                DayOfWeek weekday = StartDate.DayOfWeek;

                                for (DateTime day = StartDate.Date; day.Date <= SeriesEndDate.Date; day = day.AddDays(AddDays))
                                {
                                    dates.Add(day);
                                }
                                var query = dates.Where(d => d.DayOfWeek == weekday).GroupBy(d => d.Month).Select(e => e.Take(Takes));
                                foreach (var itemquery in query)
                                {
                                    foreach (var date in itemquery)
                                    {
                                        Reccurence reccurence = new Reccurence();
                                        reccurence.Date = date.Date;
                                        reccurence.FromTime = item.FromTime;
                                        reccurence.ToTime = item.ToTime;
                                        reccurence.CreatedBy = item.ManagerId;
                                        reccurence.CreatedDate = item.CreatedDate;
                                        avail1.Reccurences.Add(reccurence);
                                    }
                                }

                            }
                            else
                            {
                                avail1 = new AvailablityModel();
                                avail1.ManagerId = item.ManagerId;
                                avail1.Date = item.Date;
                                avail1.PropertyId = item.PropertyId;
                                avail1.ToDate = item.ToDate;
                                avail1.FromDate = item.FromDate;
                                avail1.ToTime = item.ToTime;
                                avail1.FromTime = item.FromTime;
                                avail1.CreatedBy = item.ManagerId;
                                avail1.CreatedDate = item.CreatedDate;
                                avail1.IsReccurence = item.IsReccurence;
                                avail1.IsDeleted = false;
                            }
                            result.Add(avail1);
                        }

                        ///Id exist in Database them Update is required
                        else
                        {
                            if (data.IsReccurence == true)
                            {
                                data.Date = item.Date;
                                data.ToTime = item.ToTime;
                                data.FromTime = item.FromTime;
                                data.ModifiedDate = item.ModifiedDate;
                                data.ModifiedBy = item.ManagerId;
                                data.PropertyId = item.PropertyId;
                                data.ManagerId = item.ManagerId;

                                if (item.IsReccurence == true || data.Reccurences.Count() > 0)
                                {
                                    data.IsReccurence = item.IsReccurence;
                                    var response = _context.Reccurence.Where(c => c.AvailablityId == item.Id && c.Date == item.Date).FirstOrDefault();
                                    response.IsDeleted = item.IsDeleted;
                                    response.FromTime = item.FromTime;
                                    response.ToTime = item.ToTime;
                                    response.ModifiedBy = item.ManagerId;
                                    response.ModifiedDate = item.ModifiedDate;
                                    _context.Update(response);
                                }
                                else if (item.IsReccurence == false)
                                {
                                    data.IsReccurence = item.IsReccurence;

                                    //fetch response from Reccurence table
                                    var response = _context.Reccurence.Where(c => c.Date.Date == item.Date.Date && c.AvailablityId == item.Id).FirstOrDefault();
                                    response.IsDeleted = true;
                                    response.DeletedDate = item.DeletedDate;
                                    response.DeletedBy = item.ManagerId;
                                    _context.Update(response);

                                }
                                _context.Update(data);
                            }
                            else
                            {
                                if (item.IsReccurence == true)
                                {
                                    data.ManagerId = item.ManagerId;
                                    data.Date = item.Date;
                                    data.PropertyId = item.PropertyId;
                                    data.ToDate = item.ToDate;
                                    data.FromDate = item.FromDate;
                                    data.ToTime = item.ToTime;
                                    data.FromTime = item.FromTime;
                                    data.CreatedBy = item.ManagerId;
                                    data.CreatedDate = item.CreatedDate;
                                    data.IsReccurence = item.IsReccurence;
                                    data.IsDeleted = false;
                                    //set reccurennce 1 month
                                    var StartDate = item.FromDate;
                                    var SeriesEndDate = StartDate.AddMonths(months);
                                    List<DateTime> dates = new List<DateTime>();

                                    DayOfWeek weekday = StartDate.DayOfWeek;

                                    for (DateTime day = StartDate.Date; day.Date <= SeriesEndDate.Date; day = day.AddDays(AddDays))
                                    {
                                        dates.Add(day);
                                    }
                                    avail1 = new AvailablityModel();
                                    var query = dates.Where(d => d.DayOfWeek == weekday).GroupBy(d => d.Month).Select(e => e.Take(Takes));
                                    foreach (var itemquery in query)
                                    {
                                        foreach (var date in itemquery)
                                        {
                                            Reccurence reccurence = new Reccurence();
                                            reccurence.Date = date.Date;
                                            reccurence.FromTime = item.FromTime;
                                            reccurence.ToTime = item.ToTime;
                                            reccurence.CreatedBy = item.ManagerId;
                                            reccurence.CreatedDate = item.CreatedDate;
                                            data.Reccurences.Add(reccurence);
                                        }
                                    }
                                    _context.Update(data);


                                }
                                else
                                {
                                    avail1 = new AvailablityModel();
                                    avail1.ManagerId = item.ManagerId;
                                    avail1.Date = item.Date;
                                    avail1.PropertyId = item.PropertyId;
                                    avail1.ToDate = item.ToDate;
                                    avail1.FromDate = item.FromDate;
                                    avail1.ToTime = item.ToTime;
                                    avail1.FromTime = item.FromTime;
                                    avail1.CreatedBy = item.ManagerId;
                                    avail1.CreatedDate = item.CreatedDate;
                                    avail1.IsReccurence = item.IsReccurence;
                                    avail1.IsDeleted = false;
                                    result.Add(avail1);
                                }
                            }

                        }
                    }
                }

                _context.Availablity.AddRange(result);
                _context.SaveChanges();
                return "success";
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("AvailablityService: Conflict Arises In adding Items");
            }

        }

        /// <summary>
        /// Get Availablity
        /// </summary>
        /// <returns>Get all availablities details</returns>

        public Task<IEnumerable<GetAvailablityModel>> GetAvailablities()
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return _availablityRepository.GetAvailablities();
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("AvailablityService: Conflict Arises In adding Items");
            }
        }


        public async Task<IEnumerable> GetAllAvailablities()
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return await _availablityRepository.GetAllAvailablities();
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("AvailablityService: Conflict Arises In adding Items");
            }
        }


        /// <summary>
        /// Get Availablity by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>get dtails by Id</returns>
        public AvailablityModel GetAvailablityById(long id)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return _availablityRepository.GetAvailablityById(id);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("AvailablityService: Conflict Arises In adding Items");
            }

        }

        /// <summary>
        /// get Availablity by ManagerId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>get details by Id</returns>
        public async Task<IEnumerable> GetAvailablityByManagerId(long ManagerId)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return await _availablityRepository.GetAvailablityByManagerId(ManagerId);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("AvailablityService: Conflict Arises In adding Items");
            }

        }
        /// <summary>
        ///  updating the Availablities details by ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public AvailablityModel UpdateById(long id, AvailablityUpdateModel _availablity)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return _availablityRepository.UpdateById(id, _availablity);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("AvailablityService: Conflict Arises In adding Items");
            }

        }
        /// <summary>
        /// Delete Availblity
        /// </summary>
        /// <param name="AvailablityId"></param>
        /// <param name="ReccurenceId"></param>
        /// <param name="availablityDeleteModel"></param>
        /// <returns></returns>
        /// <exception cref="ConflictException"></exception>

        public AvailablityModel DeleteAvailablityById(long AvailablityId, long ReccurenceId, AvailablityDeleteModel availablityDeleteModel)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return _availablityRepository.DeleteAvailablityById(AvailablityId, ReccurenceId, availablityDeleteModel);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("AvailablityService: Conflict Arises In adding Items");
            }
        }

        /// <summary>
        /// Get Property Name and PropertyId by ManagerId
        /// </summary>
        /// <param name="ManagerId"></param>
        /// <returns></returns>
        /// <exception cref="ConflictException"></exception>
        public async Task<IEnumerable> GetPropertyByManagerId(long ManagerId)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return await _availablityRepository.GetPropertyByManagerId(ManagerId);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("AvailablityService: Conflict Arises In adding Items");
            }

        }

        /// <summary>
        /// Get availblity by Datewise ,ManagerId and PropertyId format
        /// </summary>
        /// <param name="ManagerId"></param>
        /// <param name="PropertyId"></param>
        /// <returns></returns>
        /// <exception cref="ConflictException"></exception>
        public Task<IEnumerable<GetAvailablityModel>> AvailablityByIds(long ManagerId, long PropertyId)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return _availablityRepository.AvailablityByIds(ManagerId, PropertyId);

            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("AvailablityService: Conflict Arises In adding Items");
            }

        }
        /// <summary>
        /// Get availblity by Datewise ,ManagerId and PropertyId format
        /// </summary>
        /// <param name="ManagerId"></param>
        /// <returns></returns>
        /// <exception cref="ConflictException"></exception>
        public Task<IEnumerable<GetAvailablityModel>> AvailablityByManagerId(long ManagerId)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return _availablityRepository.AvailablityByManagerId(ManagerId);

            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("AvailablityService: Conflict Arises In adding Items");
            }

        }
        /// <summary>
        /// Get Availablity manager Id and property Id
        /// </summary>
        /// <param name="PropertyId"></param>
        /// <param name="ManagerId"></param>
        /// <returns></returns>
        /// <exception cref="ConflictException"></exception>

        public async Task<IEnumerable> GetAvailablity(long PropertyId, long ManagerId)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return await _availablityRepository.GetAvailablity(PropertyId, ManagerId);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("AvailablityService: Conflict Arises In adding Items");
            }
        }
    }
}
