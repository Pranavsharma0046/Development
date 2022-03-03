using System;
using System.ComponentModel.DataAnnotations;

namespace ManageAmericaAPI.Models
{
    public class ManagerModel
    {

        [Key]
        public long Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string FullName
        {
            get { return string.Format("{0} {1} {2}", FirstName, MiddleName, LastName); }
        }

        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool? IsDefault { get; set; }
        public string DefaultCalendar { get; set; }
    }

}
