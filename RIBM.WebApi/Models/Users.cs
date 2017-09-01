using System;
using System.Collections.Generic;

namespace RIBM.WebApi.Models
{
    public partial class Users
    {
        public Users()
        {
            ActivityEntryUser = new HashSet<Activity>();
            ActivityPermissionEntryUser = new HashSet<ActivityPermission>();
            ActivityPermissionUpdateUser = new HashSet<ActivityPermission>();
            ActivityUpdateUser = new HashSet<Activity>();
            CityEntryUser = new HashSet<City>();
            CityUpdateUser = new HashSet<City>();
            ClientEntryUser = new HashSet<Client>();
            ClientLocationEntryUser = new HashSet<ClientLocation>();
            ClientLocationUpdateUser = new HashSet<ClientLocation>();
            ClientUpdateUser = new HashSet<Client>();
            EmployeeEntryUser = new HashSet<Employee>();
            EmployeeUpdateUser = new HashSet<Employee>();
            InverseUpdateUser = new HashSet<Users>();
            MachineAssignmentEntryUser = new HashSet<MachineAssignment>();
            MachineAssignmentUpdateUser = new HashSet<MachineAssignment>();
            MachineEntryUser = new HashSet<Machine>();
            MachineStatusEntryUser = new HashSet<MachineStatus>();
            MachineStatusUpdateUser = new HashSet<MachineStatus>();
            MachineTypeEntryUser = new HashSet<MachineType>();
            MachineTypeUpdateUser = new HashSet<MachineType>();
            MachineUpdateUser = new HashSet<Machine>();
            ModuleEntryUser = new HashSet<Module>();
            ModuleUpdateUser = new HashSet<Module>();
            PermissionEntryUser = new HashSet<Permission>();
            PermissionTypeEntryUser = new HashSet<PermissionType>();
            PermissionTypeUpdateUser = new HashSet<PermissionType>();
            PermissionUpdateUser = new HashSet<Permission>();
            RoleEntryUser = new HashSet<Role>();
            RolePermissionEntryUser = new HashSet<RolePermission>();
            RolePermissionUpdateUser = new HashSet<RolePermission>();
            RoleUpdateUser = new HashSet<Role>();
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

        public Users UpdateUser { get; set; }
        public ICollection<Activity> ActivityEntryUser { get; set; }
        public ICollection<ActivityPermission> ActivityPermissionEntryUser { get; set; }
        public ICollection<ActivityPermission> ActivityPermissionUpdateUser { get; set; }
        public ICollection<Activity> ActivityUpdateUser { get; set; }
        public ICollection<City> CityEntryUser { get; set; }
        public ICollection<City> CityUpdateUser { get; set; }
        public ICollection<Client> ClientEntryUser { get; set; }
        public ICollection<ClientLocation> ClientLocationEntryUser { get; set; }
        public ICollection<ClientLocation> ClientLocationUpdateUser { get; set; }
        public ICollection<Client> ClientUpdateUser { get; set; }
        public ICollection<Employee> EmployeeEntryUser { get; set; }
        public ICollection<Employee> EmployeeUpdateUser { get; set; }
        public ICollection<Users> InverseUpdateUser { get; set; }
        public ICollection<MachineAssignment> MachineAssignmentEntryUser { get; set; }
        public ICollection<MachineAssignment> MachineAssignmentUpdateUser { get; set; }
        public ICollection<Machine> MachineEntryUser { get; set; }
        public ICollection<MachineStatus> MachineStatusEntryUser { get; set; }
        public ICollection<MachineStatus> MachineStatusUpdateUser { get; set; }
        public ICollection<MachineType> MachineTypeEntryUser { get; set; }
        public ICollection<MachineType> MachineTypeUpdateUser { get; set; }
        public ICollection<Machine> MachineUpdateUser { get; set; }
        public ICollection<Module> ModuleEntryUser { get; set; }
        public ICollection<Module> ModuleUpdateUser { get; set; }
        public ICollection<Permission> PermissionEntryUser { get; set; }
        public ICollection<PermissionType> PermissionTypeEntryUser { get; set; }
        public ICollection<PermissionType> PermissionTypeUpdateUser { get; set; }
        public ICollection<Permission> PermissionUpdateUser { get; set; }
        public ICollection<Role> RoleEntryUser { get; set; }
        public ICollection<RolePermission> RolePermissionEntryUser { get; set; }
        public ICollection<RolePermission> RolePermissionUpdateUser { get; set; }
        public ICollection<Role> RoleUpdateUser { get; set; }
        public ICollection<State> StateEntryUser { get; set; }
        public ICollection<State> StateUpdateUser { get; set; }
        public ICollection<UserPermission> UserPermissionEntryUser { get; set; }
        public ICollection<UserPermission> UserPermissionUpdateUser { get; set; }
        public ICollection<UserPermission> UserPermissionUser { get; set; }
        public ICollection<UserRole> UserRoleEntryUser { get; set; }
        public ICollection<UserRole> UserRoleUpdateUser { get; set; }
        public ICollection<UserRole> UserRoleUser { get; set; }
        public ICollection<Vendor> VendorEntryUser { get; set; }
        public ICollection<Vendor> VendorUpdateUser { get; set; }
    }
}
