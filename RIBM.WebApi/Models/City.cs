using System;
using System.Collections.Generic;

namespace RIBM.WebApi.Models
{
    public partial class City
    {
        public City()
        {
            ClientLocation = new HashSet<ClientLocation>();
            Employee = new HashSet<Employee>();
            Vendor = new HashSet<Vendor>();
        }

        public int Id { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public bool IsActive { get; set; }
        public int EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<ClientLocation> ClientLocation { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Vendor> Vendor { get; set; }
        public virtual Users EntryUser { get; set; }
        public virtual State State { get; set; }
        public virtual Users UpdateUser { get; set; }
    }
}
