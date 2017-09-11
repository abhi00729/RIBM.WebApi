using System;
using System.Collections.Generic;

namespace RIBM.WebApi.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string PinCode { get; set; }
        public string AadharCardNumber { get; set; }
        public string LicenceNumber { get; set; }
        public DateTime? LicenceExpiryDate { get; set; }
        public string LicenceType { get; set; }
        public string Esicnumber { get; set; }
        public string Epfnumber { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? LeavingDate { get; set; }
        public string Location { get; set; }
        public bool IsActive { get; set; }
        public int EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
    }
}
