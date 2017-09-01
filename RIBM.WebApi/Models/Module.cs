using System;
using System.Collections.Generic;

namespace RIBM.WebApi.Models
{
    public partial class Module
    {
        public Module()
        {
            Activity = new HashSet<Activity>();
        }

        public int Id { get; set; }
        public string ModuleName { get; set; }
        public bool IsActive { get; set; }
        public int EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Users EntryUser { get; set; }
        public Users UpdateUser { get; set; }
        public ICollection<Activity> Activity { get; set; }
    }
}
