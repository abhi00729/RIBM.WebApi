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

        public Users EntryUser { get; set; }
        public Role Role { get; set; }
        public Users UpdateUser { get; set; }
        public Users User { get; set; }
    }
}
