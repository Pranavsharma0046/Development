using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManageAmericaAPI.Models
{
    public class AvailablityModel
    {
        public AvailablityModel()
        {
            Reccurences = new HashSet<Reccurence>();
        }

        [Key]
        public long Id { get; set; }

        public DateTime Date { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToTime { get; set; }
        public DateTime FromTime { get; set; }
        public bool IsReccurence { get; set; }
        public bool IsDeleted { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// ForeignKey
        /// </summary>

        public long ManagerId { get; set; }
        public long PropertyId { get; set; }
        public virtual ICollection<Reccurence> Reccurences { get; set; }
    }

    public class GetAvailablityModel
    {

        public long ManagerId { get; set; }
        public long PropertyId { get; set; }
        public DateTime Date { get; set; }
        public GetAvailablityModel()
        {
            availablityModels = new HashSet<AvailablityModel>();
        }

        public virtual ICollection<AvailablityModel> availablityModels { get; set; }
    }



    public class AvailablityUpdateModel
    {
        public AvailablityUpdateModel()
        {
            Reccurences = new List<ReccurenceUpdateModel>();
        }
        public DateTime ToDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime Date { get; set; }
        public DateTime ToTime { get; set; }
        public DateTime FromTime { get; set; }
        public bool IsReccurence { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long ManagerId { get; set; }
        public virtual ICollection<ReccurenceUpdateModel> Reccurences { get; set; }
    }



    public class AvailablityDeleteModel
    {
        public DateTime? DeletedDate { get; set; }
        public long ManagerId { get; set; }
        public ICollection<ReccurenceDeleteModel> Reccurences { get; set; }

    }


    public class SetAvailablity
    {
        public long ManagerId { get; set; }
        public long PropertyId { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<AvailablityModel> availablity { get; set; }
        public SetAvailablity()
        {
            availablity = new HashSet<AvailablityModel>();
        }


    }
}
