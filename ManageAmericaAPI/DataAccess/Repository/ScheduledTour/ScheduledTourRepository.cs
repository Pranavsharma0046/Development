using ManageAmericaAPI.Data;
using ManageAmericaAPI.Helpers;
using ManageAmericaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ManageAmericaAPI.DataAccess.Repository.ScheduledTour
{
    public class ScheduledTourRepository : IScheduledTourRepository
    {

        private readonly ApplicationDbContext _dbcontext;


        public ScheduledTourRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable> ScheduledTours(List<ScheduledTourModel> result)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                await _dbcontext.TourDetail.AddRangeAsync(result);
                await _dbcontext.SaveChangesAsync();
                return ("ScheduledTourRepository: Successfull added");
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("ScheduledTourRepository: Conflict Arises ");
            }
        }
        public async Task<IEnumerable> GetScheduledTourList()
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var q = (from td in _dbcontext.TourDetail
                         where td.IsCancelled == false
                         join pd in _dbcontext.Property on td.PropertyId equals pd.Id
                         join md in _dbcontext.Manager on td.ManagerId equals md.Id
                         orderby td.Id
                         select new
                         {
                             td.Id,
                             td.ManagerId,
                             td.ProspectName,
                             td.ProspectEmail,
                             td.ProspectPhone,
                             td.ProspectRemarks,
                             td.TourDate,
                             td.StartTime,
                             td.EndTime,
                             td.ManagerMeetingNotes,
                             td.CreatedBy,
                             td.CreatedDate,
                             td.ModifiedDate,
                             td.ModifiedBy,
                             td.ReAssignedBy,
                             td.ReAssignedDate,
                             td.RescheduledBy,
                             td.RescheduledDate,
                             td.ManagerCancelRemarks,
                             td.ProspectCancelRemarks,
                             td.IsCancelled,
                             td.CancelledBy,
                             td.CancelledDate,
                             td.IsDeleted,
                             td.DeletedDate,
                             pd.PropertyName,
                             md.FullName,
                             md.Email
                         }).Distinct().ToList();
                return q;
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("ScheduledTourRepository: Conflict Arises ");
            }
        }
        public List<ScheduledTourModel> GetScheduledTourListAll()
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                return _dbcontext.TourDetail.Where(x => x.IsCancelled == false).ToList();
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("ScheduledTourRepository: Conflict Arises ");
            }
        }
        public async Task<IEnumerable> GetScheduledTourById(long Id)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var q = (from td in _dbcontext.TourDetail
                         where td.Id == Id && td.IsCancelled == false
                         join pd in _dbcontext.Property on td.PropertyId equals pd.Id
                         join md in _dbcontext.Manager on td.ManagerId equals md.Id
                         orderby td.Id
                         select new
                         {
                             td.Id,
                             td.ManagerId,
                             td.ProspectName,
                             td.ProspectEmail,
                             td.ProspectPhone,
                             td.ProspectRemarks,
                             td.TourDate,
                             td.StartTime,
                             td.EndTime,
                             td.ManagerMeetingNotes,
                             td.CreatedBy,
                             td.CreatedDate,
                             td.ModifiedDate,
                             td.ModifiedBy,
                             td.ReAssignedBy,
                             td.ReAssignedDate,
                             td.RescheduledBy,
                             td.RescheduledDate,
                             td.ManagerCancelRemarks,
                             td.ProspectCancelRemarks,
                             td.IsCancelled,
                             td.CancelledBy,
                             td.CancelledDate,
                             td.IsDeleted,
                             td.DeletedDate,
                             pd.PropertyName,
                             md.FullName,
                             md.Email



                         }).Distinct().ToList();
                return q;

            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable> GetScheduledTourByPropetyId(long PropertyId)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var q = (from td in _dbcontext.TourDetail
                         where td.PropertyId == PropertyId && td.IsCancelled == false
                         join pd in _dbcontext.Property on td.PropertyId equals pd.Id
                         join md in _dbcontext.Manager on td.ManagerId equals md.Id
                         orderby td.Id
                         select new
                         {
                             td.Id,
                             td.ManagerId,
                             td.ProspectName,
                             td.ProspectEmail,
                             td.ProspectPhone,
                             td.ProspectRemarks,
                             td.TourDate,
                             td.StartTime,
                             td.EndTime,
                             td.ManagerMeetingNotes,
                             td.CreatedBy,
                             td.CreatedDate,
                             td.ModifiedDate,
                             td.ModifiedBy,
                             td.ReAssignedBy,
                             td.ReAssignedDate,
                             td.RescheduledBy,
                             td.RescheduledDate,
                             td.ManagerCancelRemarks,
                             td.ProspectCancelRemarks,
                             td.IsCancelled,
                             td.CancelledBy,
                             td.CancelledDate,
                             td.IsDeleted,
                             td.DeletedDate,
                             pd.PropertyName,
                             md.FullName,
                             md.Email



                         }).Distinct().ToList();
                return q;

            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                return null;
            }
        }

     
        public ScheduledTourModel ReScheduledTourByManager(long Id, ReScheduledTourModel reScheduledTourModel)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var result = _dbcontext.TourDetail.FirstOrDefault(x => x.Id == Id);
                if (result != null)
                {
                    result.StartTime = reScheduledTourModel.StartTime;
                    result.EndTime = reScheduledTourModel.EndTime;
                    result.ManagerMeetingNotes = reScheduledTourModel.ManagerMeetingNotes;
                    result.RescheduledDate = reScheduledTourModel.RescheduledDate;
                    result.RescheduledBy = reScheduledTourModel.RescheduledBy;

                }
                _dbcontext.SaveChanges();
                return (result);
            }
            catch (Exception ex )
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("ScheduledTourRepository: Conflict Arises ");
            }
        }
        public ScheduledTourModel ReScheduledTourByProspect(long Id, ReScheduledTourModelProspect reScheduled)
        {
            try
            {
                var result = _dbcontext.TourDetail.FirstOrDefault(x => x.Id == Id);
                if (result != null)
                {
                    if (result.ProspectEmail == reScheduled.ProspectEmail && result.ProspectName == reScheduled.ProspectName)
                    {
                        result.StartTime = reScheduled.StartTime;
                        result.EndTime = reScheduled.EndTime;
                        result.ProspectRemarks = reScheduled.ProspectRemarks;
                        result.RescheduledDate = reScheduled.RescheduledDate;
                        result.RescheduledBy = reScheduled.RescheduledBy;
                    }
                    else
                    {
                        return null;
                    }
                }
                _dbcontext.SaveChanges();
                return (result);
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("ScheduledTourRepository: Conflict Arises ");
            }
        }
        public ScheduledTourModel CancelScheduledTourByProspect(long Id, CancelScheduledTourProspectModel cancelScheduledTour)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var result = _dbcontext.TourDetail.Where(e => e.Id == Id).FirstOrDefault();

                if (result != null)
                {
                    if (result.IsCancelled == false && (result.ProspectEmail == cancelScheduledTour.ProspectEmail
                        && result.ProspectName == cancelScheduledTour.ProspectName))
                    {
                        result.IsCancelled = true;
                        result.ProspectCancelRemarks = cancelScheduledTour.ProspectCancelRemarks;
                        result.CancelledBy = cancelScheduledTour.CancelledBy;
                        result.CancelledDate = cancelScheduledTour.CancelledDate;
                        _dbcontext.SaveChanges();
                        return (result);
                    }
                    else { return null; }
                }
                throw new InvalidException("ScheduledTourRepository: InValid Id ");
            }
            catch (ConflictException ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("ScheduledTourRepository: Conflict Arises In Cancelling Tour ", ex);
            }
        }

        public ScheduledTourModel CancelScheduledTourByManager(long Id, CancelScheduledTourModel cancelScheduled)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var result = _dbcontext.TourDetail.Where(e => e.Id == Id).FirstOrDefault();
                if (result != null)
                {
                    if (result.IsCancelled == false)
                    {
                        result.IsCancelled = true;
                        result.ManagerCancelRemarks = cancelScheduled.ManagerCancelRemarks;
                        result.CancelledBy = "M";
                        result.CancelledDate = cancelScheduled.CancelledDate;
                        _dbcontext.SaveChanges();
                        return (result);
                    }
                    else { return null; }

                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new ConflictException("ScheduledTourRepository: Conflict Arises In Cancelling Tour ");
            }

        }

        public ScheduledTourModel ReAssignedManagers(long Id, ReassignedModel reassignedModel)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var response = _dbcontext.TourDetail.Where(e => e.Id == Id).FirstOrDefault();
                if (response != null)
                {

                    response.ManagerId = reassignedModel.ManagerId;
                    response.ReAssignedBy = reassignedModel.ManagerId;
                    response.ReAssignedDate = reassignedModel.ReAssignedDate;

                    _dbcontext.SaveChanges();
                    return (response);
                }
                else throw new InvalidException("ScheduledTourRepository: InValid Id");
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new InvalidException("ScheduledTourRepository: InValid Id");
            }

        }

        public async Task<IEnumerable> ManagersList()
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var q = (from pd in _dbcontext.Availablity
                         join od in _dbcontext.Manager on pd.ManagerId equals od.Id
                         orderby od.Id
                         select new
                         {
                             od.Id,
                             od.FullName
                         }).Distinct().ToList();
                return q;

            }

            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new HttpResponseException("ScheduledTourRepository: NotFound");
            }
        }


        public ManagerModel SetDefaultCalendar(long Id, string DefaultCalendar)
        {
            try
            {
                Logger.WriteLog("started", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name);
                var response = _dbcontext.Manager.Where(e => e.Id == Id).FirstOrDefault();
                if (response != null)
                {

                    response.IsDefault = true;
                    response.DefaultCalendar = DefaultCalendar;
                    _dbcontext.SaveChanges();
                    return (response);
                }
                else throw new InvalidException("ScheduledTourRepository: InValid Id");
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Error", MethodBase.GetCurrentMethod().ReflectedType.FullName + "." + MethodBase.GetCurrentMethod().Name, ex.Message);
                throw new InvalidException("ScheduledTourRepository: InValid Id");
            }

        }
    }
}













