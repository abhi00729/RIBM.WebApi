using System;
using System.Collections.Generic;

namespace RIBM.WebApi.Models
{
    public partial class Users
    {
        public Users()
        {
            ActivityEntryUser = new HashSet<Activity>();
            ActivityUpdateUser = new HashSet<Activity>();
            ActivityPermissionEntryUser = new HashSet<ActivityPermission>();
            ActivityPermissionUpdateUser = new HashSet<ActivityPermission>();
            CityEntryUser = new HashSet<City>();
            CityUpdateUser = new HashSet<City>();
            ClientEntryUser = new HashSet<Client>();
            ClientUpdateUser = new HashSet<Client>();
            ClientLocationEntryUser = new HashSet<ClientLocation>();
            ClientLocationUpdateUser = new HashSet<ClientLocation>();
            EmployeeEntryUser = new HashSet<Employee>();
            EmployeeUpdateUser = new HashSet<Employee>();
            MachineEntryUser = new HashSet<Machine>();
            MachineUpdateUser = new HashSet<Machine>();
            MachineAssignmentEntryUser = new HashSet<MachineAssignment>();
            MachineAssignmentUpdateUser = new HashSet<MachineAssignment>();
            MachineStatusEntryUser = new HashSet<MachineStatus>();
            MachineStatusUpdateUser = new HashSet<MachineStatus>();
            MachineTypeEntryUser = new HashSet<MachineType>();
            MachineTypeUpdateUser = new HashSet<MachineType>();
            ModuleEntryUser = new HashSet<Module>();
            ModuleUpdateUser = new HashSet<Module>();
            PermissionEntryUser = new HashSet<Permission>();
            PermissionUpdateUser = new HashSet<Permission>();
            PermissionTypeEntryUser = new HashSet<PermissionType>();
            PermissionTypeUpdateUser = new HashSet<PermissionType>();
            RoleEntryUser = new HashSet<Role>();
            RoleUpdateUser = new HashSet<Role>();
            RolePermissionEntryUser = new HashSet<RolePermission>();
            RolePermissionUpdateUser = new HashSet<RolePermission>();
            StateEntryUser = new HashSet<State>();
            StateUpdateUser = new HashSet<State>();
            UserPermissionEntryUser = new HashSet<UserPermission>();
            UserPermissionUpdateUser = new HashSet<UserPermission>();
            UserPermissionUser = new HashSet<UserPermission>();
            UserRoleEntryUser = new HashSet<UserRole>();
            UserRoleUpdateUser = new HashSet<UserRole>();
            UserRoleUser = new HashSet<UserRole>();
            VendorEntryUser = new HashSet<Vendor>();
            VendorUpdateUser = new HashSet<Vendor>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? EmployeeId { get; set; }
        public bool IsActive { get; set; }
        public int EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<Activity> ActivityEntryUser { get; set; }
        public virtual ICollection<Activity> ActivityUpdateUser { get; set; }
        public virtual ICollection<ActivityPermission> ActivityPermissionEntryUser { get; set; }
        public virtual ICollection<ActivityPermission> ActivityPermissionUpdateUser { get; set; }
        public virtual ICollection<City> CityEntryUser { get; set; }
        public virtual ICollection<City> CityUpdateUser { get; set; }
        public virtual ICollection<Client> ClientEntryUser { get; set; }
        public virtual ICollection<Client> ClientUpdateUser { get; set; }
        public virtual ICollection<ClientLocation> ClientLocationEntryUser { get; set; }
        public virtual ICollection<ClientLocation> ClientLocationUpdateUser { get; set; }
        public virtual ICollection<Employee> EmployeeEntryUser { get; set; }
        public virtual ICollection<Employee> EmployeeUpdateUser { get; set; }
        public virtual ICollection<Machine> MachineEntryUser { get; set; }
        public virtual ICollection<Machine> MachineUpdateUser { get; set; }
        public virtual ICollection<MachineAssignment> MachineAssignmentEntryUser { get; set; }
        public virtual ICollection<MachineAssignment> MachineAssignmentUpdateUser { get; set; }
        public virtual ICollection<MachineStatus> MachineStatusEntryUser { get; set; }
        public virtual ICollection<MachineStatus> MachineStatusUpdateUser { get; set; }
        public virtual ICollection<MachineType> MachineTypeEntryUser { get; set; }
        public virtual ICollection<MachineType> MachineTypeUpdateUser { get; set; }
        public virtual ICollection<Module> ModuleEntryUser { get; set; }
        public virtual ICollection<Module> ModuleUpdateUser { get; set; }
        public virtual ICollection<Permission> PermissionEntryUser { get; set; }
        public virtual ICollection<Permission> PermissionUpdateUser { get; set; }
        public virtual ICollection<PermissionType> PermissionTypeEntryUser { get; set; }
        public virtual ICollection<PermissionType> PermissionTypeUpdateUser { get; set; }
        public virtual ICollection<Role> RoleEntryUser { get; set; }
        public virtual ICollection<Role> RoleUpdateUser { get; set; }
        public virtual ICollection<RolePermission> RolePermissionEntryUser { get; set; }
        public virtual ICollection<RolePermission> RolePermissionUpdateUser { get; set; }
        public virtual ICollection<State> StateEntryUser { get; set; }
        public virtual ICollection<State> StateUpdateUser { get; set; }
        public virtual ICollection<UserPermission> UserPermissionEntryUser { get; set; }
        public virtual ICollection<UserPermission> UserPermissionUpdateUser { get; set; }
        public virtual ICollection<UserPermission> UserPermissionUser { get; set; }
        public virtual ICollection<UserRole> UserRoleEntryUser { get; set; }
        public virtual ICollection<UserRole> UserRoleUpdateUser { get; set; }
        public virtual ICollection<UserRole> UserRoleUser { get; set; }
        public virtual ICollection<Vendor> VendorEntryUser { get; set; }
        public virtual ICollection<Vendor> VendorUpdateUser { get; set; }
        public virtual Users UpdateUser { get; set; }
        public virtual ICollection<Users> InverseUpdateUser { get; set; }
    }
}
