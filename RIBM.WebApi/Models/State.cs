using System;
using System.Collections.Generic;

namespace RIBM.WebApi.Models
{
    public partial class State
    {
        public State()
        {
            City = new HashSet<City>();
            ClientLocation = new HashSet<ClientLocation>();
            Employee = new HashSet<Employee>();
            Vendor = new HashSet<Vendor>();
        }

        public int Id { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }
        public int EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Users EntryUser { get; set; }
        public Users UpdateUser { get; set; }
        public ICollection<City> City { get; set; }
        public ICollection<ClientLocation> ClientLocation { get; set; }
        public ICollection<Employee> Employee { get; set; }
        public ICollection<Vendor> Vendor { get; set; }
    }
}
