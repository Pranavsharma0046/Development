using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManageAmericaAPI.Models
{
    public class PropertyModel
    {
       
       
        [Key]
        public long Id { get; set; }
        [Required]
        public string PropertyName { get; set; }
         public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ZipCode { get; set; }

        public bool IsDeleted { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }     
       
    }
}
