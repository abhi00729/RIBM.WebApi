using System;
using System.Collections.Generic;

namespace RIBM.WebApi.Models
{
    public partial class ActivityPermission
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public int PermissionId { get; set; }
        public int EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        public Activity Activity { get; set; }
        public Users EntryUser { get; set; }
        public Permission Permission { get; set; }
        public Users UpdateUser { get; set; }
    }
}
