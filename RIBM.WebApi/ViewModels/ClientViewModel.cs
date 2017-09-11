using System;
using System.Collections.Generic;

namespace RIBM.WebApi.Models
{
    public class ClientViewModel
    {
        public ClientViewModel()
        {
            ClientLocation = new List<ClientLocationViewModel>();
            MachineAssignment = new HashSet<MachineAssignment>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
        public int EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Users EntryUser { get; set; }
        public Users UpdateUser { get; set; }
        public ICollection<ClientLocationViewModel> ClientLocation { get; set; }
        public ICollection<MachineAssignment> MachineAssignment { get; set; }
    }
}
