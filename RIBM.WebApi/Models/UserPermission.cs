﻿using System;
using System.Collections.Generic;

namespace RIBM.WebApi.Models
{
    public partial class UserPermission
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ActivityId { get; set; }
        public int PermissionId { get; set; }
        public int PermissionTypeId { get; set; }
        public int EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual Users EntryUser { get; set; }
        public virtual Permission Permission { get; set; }
        public virtual PermissionType PermissionType { get; set; }
        public virtual Users UpdateUser { get; set; }
        public virtual Users User { get; set; }
    }
}