using ManageAmericaAPI.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManageAmericaAPI.Models
{
    public class ScheduledTourModel
    {
        

        [Key]
        public long Id { get; set; }

        [Required]
        public string ProspectName { get; set; }
        [Required]
        public string ProspectEmail { get; set; }
        [Required]
        public string ProspectPhone { get; set; }
        public string ProspectRemarks { get; set; }
        public DateTime TourDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ManagerMeetingNotes { get; set; }
        public bool IsCancelled { get; set; } = false;
        public string? CancelledBy { get; set; }
        public Nullable<DateTime> CancelledDate { get; set; }
        public string? ProspectCancelRemarks { get; set; }
        public string? ManagerCancelRemarks { get; set; }
        public long? ReAssignedBy { get; set; }
        public Nullable<DateTime> ReAssignedDate { get; set; }
        public long? RescheduledBy { get; set; }
        public Nullable<DateTime> RescheduledDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<long> DeletedBy { get; set; }
        public Nullable<DateTime> DeletedDate { get; set; }

        /// <summary>
        /// ForeignKey
        /// </summary>

        [ForeignKey("ManagerId")]
        public  Nullable<long> ManagerId { get; set; }
        [ForeignKey("PropertyId")]
        public  long PropertyId { get; set; }
      
    }


    public class ReScheduledTourModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ManagerMeetingNotes { get; set; }
        public long? RescheduledBy { get; set; }
        public Nullable<DateTime> RescheduledDate { get; set; }
    }


    public class ReScheduledTourModelProspect
    {
        [Required]
        public string ProspectName { get; set; }
        [Required]
        public string ProspectEmail { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ProspectRemarks { get; set; }
        public long? RescheduledBy { get; set; }
        public Nullable<DateTime> RescheduledDate { get; set; }
    }


    public class ReassignedModel
    {
        [ForeignKey("ManagerId")]
        public long ManagerId { get; set; }
        public long? ReAssignedBy { get; set; }
        public Nullable<DateTime> ReAssignedDate { get; set; }
    }
    public class CancelScheduledTourModel
    {
     
        public string? CancelledBy { get; set; }
        public Nullable<DateTime> CancelledDate { get; set; }
        public string? ManagerCancelRemarks { get; set; }
    }
    public class CancelScheduledTourProspectModel
    {
        public string ProspectName { get; set; }
        
        public string ProspectEmail { get; set; }
        public bool IsCancelled { get; set; } = false;
        public string? CancelledBy { get; set; }
        public Nullable<DateTime> CancelledDate { get; set; }
        public string? ProspectCancelRemarks { get; set; }
    }
}

