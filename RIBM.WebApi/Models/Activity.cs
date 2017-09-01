using System;
using System.Collections.Generic;

namespace RIBM.WebApi.Models
{
    public partial class Activity
    {
        public Activity()
        {
            ActivityPermission = new HashSet<ActivityPermission>();
            RolePermission = new HashSet<RolePermission>();
            UserPermission = new HashSet<UserPermission>();
        }

        public int Id { get; set; }
        public string ActivityName { get; set; }
        public int ModuleId { get; set; }
        public string ActivityUrl { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }
        public int EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Users EntryUser { get; set; }
        public Module Module { get; set; }
        public Users UpdateUser { get; set; }
        public ICollection<ActivityPermission> ActivityPermission { get; set; }
        public ICollection<RolePermission> RolePermission { get; set; }
        public ICollection<UserPermission> UserPermission { get; set; }
    }
}
