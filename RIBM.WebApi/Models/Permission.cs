using System;
using System.Collections.Generic;

namespace RIBM.WebApi.Models
{
    public partial class Permission
    {
        public Permission()
        {
            ActivityPermission = new HashSet<ActivityPermission>();
            RolePermission = new HashSet<RolePermission>();
            UserPermission = new HashSet<UserPermission>();
        }

        public int Id { get; set; }
        public string PermissionName { get; set; }
        public bool IsActive { get; set; }
        public int EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<ActivityPermission> ActivityPermission { get; set; }
        public virtual ICollection<RolePermission> RolePermission { get; set; }
        public virtual ICollection<UserPermission> UserPermission { get; set; }
        public virtual Users EntryUser { get; set; }
        public virtual Users UpdateUser { get; set; }
    }
}
