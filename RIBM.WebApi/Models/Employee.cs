using System;
using System.Collections.Generic;

namespace RIBM.WebApi.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string PinCode { get; set; }
        public bool IsActive { get; set; }
        public int EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual City City { get; set; }
        public virtual Users EntryUser { get; set; }
        public virtual State State { get; set; }
        public virtual Users UpdateUser { get; set; }
    }
}
