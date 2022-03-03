using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ManageAmericaAPI.Models

{
    public class Reccurence
    {

        [Key]
        public long Id { get; set; }

        public DateTime Date { get; set; }
        public DateTime ToTime { get; set; }
        public DateTime FromTime { get; set; }

        public bool IsDeleted { get; set; }=false;
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Foreign Key
        /// </summary>
        [ForeignKey("AvailablityId")]
        public long AvailablityId { get; set; }

        public virtual AvailablityModel Availablity{ get; set; }

        public static implicit operator Reccurence(List<Reccurence> v)
        {
            throw new NotImplementedException();
        }
    }
    public class ReccurenceUpdateModel
    {
        public DateTime Date { get; set; }
        public DateTime ToTime { get; set; }
        public DateTime FromTime { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class ReccurenceDeleteModel 
    {
        public bool IsDeleted { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        
    }


    public class SetReccurence
    {

        [Key]
        public long Id { get; set; }

        public DateTime Date { get; set; }
        public DateTime ToTime { get; set; }
        public DateTime FromTime { get; set; }

        public bool IsDeleted { get; set; } = false;
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Foreign Key
        /// </summary>
        [ForeignKey("AvailablityId")]
        public long AvailablityId { get; set; }

      public AvailablityModel Availablity { get; set; }

    }
}
