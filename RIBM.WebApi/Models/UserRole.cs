using System;
using System.Collections.Generic;

namespace RIBM.WebApi.Models
{
    public partial class UserRole
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public int EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Users EntryUser { get; set; }
        public virtual Role Role { get; set; }
        public virtual Users UpdateUser { get; set; }
        public virtual Users User { get; set; }
    }
}
