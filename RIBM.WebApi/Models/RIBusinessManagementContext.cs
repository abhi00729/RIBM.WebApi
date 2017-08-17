using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RIBM.WebApi.Models
{
    public partial class RIBusinessManagementContext : DbContext
    {
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<ActivityPermission> ActivityPermission { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientLocation> ClientLocation { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Machine> Machine { get; set; }
        public virtual DbSet<MachineAssignment> MachineAssignment { get; set; }
        public virtual DbSet<MachineStatus> MachineStatus { get; set; }
        public virtual DbSet<MachineType> MachineType { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<PermissionType> PermissionType { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<UserPermission> UserPermission { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        
        public RIBusinessManagementContext(DbContextOptions<RIBusinessManagementContext> options)
            :base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.ActivityName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ActivityUrl).HasColumnType("varchar(500)");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.ImagePath).HasColumnType("varchar(100)");

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.EntryUser)
                    .WithMany(p => p.ActivityEntryUser)
                    .HasForeignKey(d => d.EntryUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Activity_EntryUserId_Users_Id");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Activity_ModuleId_Module_Id");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.ActivityUpdateUser)
                    .HasForeignKey(d => d.UpdateUserId)
                    .HasConstraintName("FK_Activity_UpdateUserId_Users_Id");
            });

            modelBuilder.Entity<ActivityPermission>(entity =>
            {
                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityPermission)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ActivityPermission_ActivityId_Activity_Id");

                entity.HasOne(d => d.EntryUser)
                    .WithMany(p => p.ActivityPermissionEntryUser)
                    .HasForeignKey(d => d.EntryUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ActivityPermission_EntryUserId_Users_Id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.ActivityPermission)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ActivityPermission_PermissionId_Permission_Id");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.ActivityPermissionUpdateUser)
                    .HasForeignKey(d => d.UpdateUserId)
                    .HasConstraintName("FK_ActivityPermission_UpdateUserId_Users_Id");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.EntryUser)
                    .WithMany(p => p.CityEntryUser)
                    .HasForeignKey(d => d.EntryUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_City_EntryUserId_Users_Id");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_City_StateId_State_Id");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.CityUpdateUser)
                    .HasForeignKey(d => d.UpdateUserId)
                    .HasConstraintName("FK_City_UpdateUserId_Users_Id");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.EmailAddress).HasColumnType("varchar(250)");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasColumnType("varchar(13)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.EntryUser)
                    .WithMany(p => p.ClientEntryUser)
                    .HasForeignKey(d => d.EntryUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Client_EntryUserId_Users_Id");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.ClientUpdateUser)
                    .HasForeignKey(d => d.UpdateUserId)
                    .HasConstraintName("FK_Client_UpdateUserId_Users_Id");
            });

            modelBuilder.Entity<ClientLocation>(entity =>
            {
                entity.Property(e => e.Address).HasColumnType("varchar(500)");

                entity.Property(e => e.ContactPersonName)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.EmailAddress).HasColumnType("varchar(250)");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.IsBillingAddress).HasDefaultValueSql("0");

                entity.Property(e => e.IsPrimary).HasDefaultValueSql("0");

                entity.Property(e => e.MobileNo).HasColumnType("varchar(13)");

                entity.Property(e => e.PinCode).HasColumnType("varchar(10)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.ClientLocation)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_ClientLocation_CityId_City_Id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientLocation)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ClientLocation_ClientId_Client_Id");

                entity.HasOne(d => d.EntryUser)
                    .WithMany(p => p.ClientLocationEntryUser)
                    .HasForeignKey(d => d.EntryUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ClientLocation_EntryUserId_Users_Id");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.ClientLocation)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_ClientLocation_StateId_State_Id");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.ClientLocationUpdateUser)
                    .HasForeignKey(d => d.UpdateUserId)
                    .HasConstraintName("FK_ClientLocation_UpdateUserId_Users_Id");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Address).HasColumnType("varchar(500)");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailAddress).HasColumnType("varchar(100)");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasColumnType("varchar(13)");

                entity.Property(e => e.PinCode).HasColumnType("varchar(10)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Employee_CityId_City_Id");

                entity.HasOne(d => d.EntryUser)
                    .WithMany(p => p.EmployeeEntryUser)
                    .HasForeignKey(d => d.EntryUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Employee_EntryUserId_Users_Id");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_Employee_StateId_State_Id");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.EmployeeUpdateUser)
                    .HasForeignKey(d => d.UpdateUserId)
                    .HasConstraintName("FK_Employee_UpdateUserId_Users_Id");
            });

            modelBuilder.Entity<Machine>(entity =>
            {
                entity.Property(e => e.AirFilterNumber).HasColumnType("varchar(100)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Descrip).HasColumnType("varchar(100)");

                entity.Property(e => e.DieselFilterNumber).HasColumnType("varchar(100)");

                entity.Property(e => e.EngineMotorNumber).HasColumnType("varchar(100)");

                entity.Property(e => e.EngineSerialNumber).HasColumnType("varchar(100)");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.HeadgasKitNotch).HasColumnType("varchar(100)");

                entity.Property(e => e.HydrolicFilterNumber).HasColumnType("varchar(100)");

                entity.Property(e => e.InsuranceDetails).HasColumnType("varchar(500)");

                entity.Property(e => e.InsuranceEndDate).HasColumnType("datetime");

                entity.Property(e => e.InsuranceStartDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.MachineSerialNo).HasColumnType("varchar(100)");

                entity.Property(e => e.Model).HasColumnType("varchar(100)");

                entity.Property(e => e.OilFilterNumber).HasColumnType("varchar(100)");

                entity.Property(e => e.StarterMotarTeeth).HasColumnType("varchar(100)");

                entity.Property(e => e.TyreNumber).HasColumnType("varchar(100)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.EntryUser)
                    .WithMany(p => p.MachineEntryUser)
                    .HasForeignKey(d => d.EntryUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Machine_EntryUserId_Users_Id");

                entity.HasOne(d => d.MachineType)
                    .WithMany(p => p.Machine)
                    .HasForeignKey(d => d.MachineTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Machine_MachineTypeId_MachineType_Id");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.MachineUpdateUser)
                    .HasForeignKey(d => d.UpdateUserId)
                    .HasConstraintName("FK_Machine_UpdateUserId_Users_Id");
            });

            modelBuilder.Entity<MachineAssignment>(entity =>
            {
                entity.Property(e => e.BaseCharges).HasColumnType("numeric");

                entity.Property(e => e.ContractEndDate).HasColumnType("datetime");

                entity.Property(e => e.ContractStartDate).HasColumnType("datetime");

                entity.Property(e => e.DeMobilizationCharges).HasColumnType("numeric");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.ExtraOperatorRequiredCharges).HasColumnType("numeric");

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.LoadingUnloadingCharges).HasColumnType("numeric");

                entity.Property(e => e.MobilizationCharges).HasColumnType("numeric");

                entity.Property(e => e.Notes).HasColumnType("varchar(500)");

                entity.Property(e => e.OvertimeCharges).HasColumnType("numeric");

                entity.Property(e => e.OvertimeChargesPerHour).HasColumnType("numeric");

                entity.Property(e => e.PaymentTerms)
                    .IsRequired()
                    .HasColumnType("char(1)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.MachineAssignment)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MachineAssignment_ClientId_Client_Id");

                entity.HasOne(d => d.ClientLocation)
                    .WithMany(p => p.MachineAssignment)
                    .HasForeignKey(d => d.ClientLocationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MachineAssignment_ClientLocationId_ClientLocation_Id");

                entity.HasOne(d => d.EntryUser)
                    .WithMany(p => p.MachineAssignmentEntryUser)
                    .HasForeignKey(d => d.EntryUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MachineAssignment_EntryUserId_Users_Id");

                entity.HasOne(d => d.Machine)
                    .WithMany(p => p.MachineAssignment)
                    .HasForeignKey(d => d.MachineId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MachineAssignment_MachineId_Machine_Id");

                entity.HasOne(d => d.MachineStatus)
                    .WithMany(p => p.MachineAssignment)
                    .HasForeignKey(d => d.MachineStatusId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MachineAssignment_MachineStatusId_MachineStatus_Id");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.MachineAssignmentUpdateUser)
                    .HasForeignKey(d => d.UpdateUserId)
                    .HasConstraintName("FK_MachineAssignment_UpdateUserId_Users_Id");
            });

            modelBuilder.Entity<MachineStatus>(entity =>
            {
                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.MachineStatusName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.EntryUser)
                    .WithMany(p => p.MachineStatusEntryUser)
                    .HasForeignKey(d => d.EntryUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MachineStatus_EntryUserId_Users_Id");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.MachineStatusUpdateUser)
                    .HasForeignKey(d => d.UpdateUserId)
                    .HasConstraintName("FK_MachineStatus_UpdateUserId_Users_Id");
            });

            modelBuilder.Entity<MachineType>(entity =>
            {
                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.MachineTypeName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.EntryUser)
                    .WithMany(p => p.MachineTypeEntryUser)
                    .HasForeignKey(d => d.EntryUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MachineType_EntryUserId_Users_Id");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.MachineTypeUpdateUser)
                    .HasForeignKey(d => d.UpdateUserId)
                    .HasConstraintName("FK_MachineType_UpdateUserId_Users_Id");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.EntryUser)
                    .WithMany(p => p.ModuleEntryUser)
                    .HasForeignKey(d => d.EntryUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Module_EntryUserId_Users_Id");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.ModuleUpdateUser)
                    .HasForeignKey(d => d.UpdateUserId)
                    .HasConstraintName("FK_Module_UpdateUserId_Users_Id");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.PermissionName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.EntryUser)
                    .WithMany(p => p.PermissionEntryUser)
                    .HasForeignKey(d => d.EntryUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Permission_EntryUserId_Users_Id");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.PermissionUpdateUser)
                    .HasForeignKey(d => d.UpdateUserId)
                    .HasConstraintName("FK_Permission_UpdateUserId_Users_Id");
            });

            modelBuilder.Entity<PermissionType>(entity =>
            {
                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.PermissionTypeName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.EntryUser)
                    .WithMany(p => p.PermissionTypeEntryUser)
                    .HasForeignKey(d => d.EntryUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PermissionType_EntryUserId_Users_Id");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.PermissionTypeUpdateUser)
                    .HasForeignKey(d => d.UpdateUserId)
                    .HasConstraintName("FK_PermissionType_UpdateUserId_Users_Id");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.EntryUser)
                    .WithMany(p => p.RoleEntryUser)
                    .HasForeignKey(d => d.EntryUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Role_EntryUserId_Users_Id");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.RoleUpdateUser)
                    .HasForeignKey(d => d.UpdateUserId)
                    .HasConstraintName("FK_Role_UpdateUserId_Users_Id");
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RolePermission_ActivityId_Activity_Id");

                entity.HasOne(d => d.EntryUser)
                    .WithMany(p => p.RolePermissionEntryUser)
                    .HasForeignKey(d => d.EntryUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RolePermission_EntryUserId_Users_Id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RolePermission_PermissionId_Permission_Id");

                entity.HasOne(d => d.PermissionType)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.PermissionTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RolePermission_PermissionTypeId_PermissionType_Id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_RolePermission_RoleId_Role_Id");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.RolePermissionUpdateUser)
                    .HasForeignKey(d => d.UpdateUserId)
                    .HasConstraintName("FK_RolePermission_UpdateUserId_Users_Id");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.EntryUser)
                    .WithMany(p => p.StateEntryUser)
                    .HasForeignKey(d => d.EntryUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_State_EntryUserId_Users_Id");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.StateUpdateUser)
                    .HasForeignKey(d => d.UpdateUserId)
                    .HasConstraintName("FK_State_UpdateUserId_Users_Id");
            });

            modelBuilder.Entity<UserPermission>(entity =>
            {
                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.UserPermission)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserPermission_ActivityId_Activity_Id");

                entity.HasOne(d => d.EntryUser)
                    .WithMany(p => p.UserPermissionEntryUser)
                    .HasForeignKey(d => d.EntryUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserPermission_EntryUserId_Users_Id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.UserPermission)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserPermission_PermissionId_Permission_Id");

                entity.HasOne(d => d.PermissionType)
                    .WithMany(p => p.UserPermission)
                    .HasForeignKey(d => d.PermissionTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserPermission_PermissionTypeId_PermissionType_Id");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.UserPermissionUpdateUser)
                    .HasForeignKey(d => d.UpdateUserId)
                    .HasConstraintName("FK_UserPermission_UpdateUserId_Users_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPermissionUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserPermission_UserId_User_Id");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.EntryUser)
                    .WithMany(p => p.UserRoleEntryUser)
                    .HasForeignKey(d => d.EntryUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserRole_EntryUserId_Users_Id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserRole_RoleId_Role_Id");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.UserRoleUpdateUser)
                    .HasForeignKey(d => d.UpdateUserId)
                    .HasConstraintName("FK_UserRole_UpdateUserId_Users_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoleUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserRole_UserId_Users_Id");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.InverseUpdateUser)
                    .HasForeignKey(d => d.UpdateUserId)
                    .HasConstraintName("FK_Users_UpdateUserId_Users_Id");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.Property(e => e.Address).HasColumnType("varchar(500)");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.EmailAddress).HasColumnType("varchar(250)");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.IsActive).HasDefaultValueSql("1");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.MobileNo)
                    .IsRequired()
                    .HasColumnType("varchar(13)");

                entity.Property(e => e.PinCode).HasColumnType("varchar(10)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Vendor)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Vendor_CityId_City_Id");

                entity.HasOne(d => d.EntryUser)
                    .WithMany(p => p.VendorEntryUser)
                    .HasForeignKey(d => d.EntryUserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Vendor_EntryUserId_Users_Id");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Vendor)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_Vendor_StateId_State_Id");

                entity.HasOne(d => d.UpdateUser)
                    .WithMany(p => p.VendorUpdateUser)
                    .HasForeignKey(d => d.UpdateUserId)
                    .HasConstraintName("FK_Vendor_UpdateUserId_Users_Id");
            });
        }
    }
}