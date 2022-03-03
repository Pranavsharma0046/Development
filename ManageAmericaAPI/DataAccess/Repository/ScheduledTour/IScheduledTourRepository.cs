using ManageAmericaAPI.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageAmericaAPI.DataAccess.Repository.ScheduledTour
{
    public interface IScheduledTourRepository
    {
        Task<IEnumerable> ScheduledTours(List<ScheduledTourModel> _scheduledTourModel);
        Task<IEnumerable> GetScheduledTourList();
        List<ScheduledTourModel> GetScheduledTourListAll();
        Task<IEnumerable> GetScheduledTourById(long Id);
        Task<IEnumerable> GetScheduledTourByPropetyId(long PropertyId);
        ScheduledTourModel ReScheduledTourByManager(long Id, ReScheduledTourModel reScheduledTourModel);
        ScheduledTourModel ReScheduledTourByProspect(long Id, ReScheduledTourModelProspect reScheduled);
        ScheduledTourModel CancelScheduledTourByProspect(long Id, CancelScheduledTourProspectModel cancelScheduledTour);
        ScheduledTourModel CancelScheduledTourByManager(long Id, CancelScheduledTourModel cancelScheduled);
        ScheduledTourModel ReAssignedManagers(long Id, ReassignedModel reassignedModel);
        Task<IEnumerable> ManagersList();
        ManagerModel SetDefaultCalendar(long Id, string DefaultCalendar);
    }
}
