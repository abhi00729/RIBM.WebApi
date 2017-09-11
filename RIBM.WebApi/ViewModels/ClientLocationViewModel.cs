using System;
using System.Collections.Generic;

namespace RIBM.WebApi.Models
{
    public class ClientLocationViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ContactPersonName { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string PinCode { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsBillingAddress { get; set; }
        public bool IsActive { get; set; }
        public int EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
    }
}
