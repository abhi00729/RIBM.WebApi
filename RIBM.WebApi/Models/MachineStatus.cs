using System;
using System.Collections.Generic;

namespace RIBM.WebApi.Models
{
    public partial class MachineStatus
    {
        public MachineStatus()
        {
            MachineAssignment = new HashSet<MachineAssignment>();
        }

        public int Id { get; set; }
        public string MachineStatusName { get; set; }
        public bool IsActive { get; set; }
        public int EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Users EntryUser { get; set; }
        public Users UpdateUser { get; set; }
        public ICollection<MachineAssignment> MachineAssignment { get; set; }
    }
}
