using System;
using System.Collections.Generic;

namespace RIBM.WebApi.Models
{
    public partial class PermissionType
    {
        public PermissionType()
        {
            RolePermission = new HashSet<RolePermission>();
            UserPermission = new HashSet<UserPermission>();
        }

        public int Id { get; set; }
        public string PermissionTypeName { get; set; }
        public bool IsActive { get; set; }
        public int EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Users EntryUser { get; set; }
        public Users UpdateUser { get; set; }
        public ICollection<RolePermission> RolePermission { get; set; }
        public ICollection<UserPermission> UserPermission { get; set; }
    }
}
