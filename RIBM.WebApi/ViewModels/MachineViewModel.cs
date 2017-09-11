using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RIBM.WebApi.ViewModels
{
    public class MachineViewModel
    {
        public int Id { get; set; }
        public int MachineTypeId { get; set; }
        public string Code { get; set; }
        public string Descrip { get; set; }
        public string Model { get; set; }
        public string MachineSerialNo { get; set; }
        public int? ManufactureYear { get; set; }
        public string EngineSerialNumber { get; set; }
        public string EngineMotorNumber { get; set; }
        public string TyreNumber { get; set; }
        public string StarterMotarTeeth { get; set; }
        public string HeadgasKitNotch { get; set; }
        public string DieselFilterNumber { get; set; }
        public string OilFilterNumber { get; set; }
        public string HydrolicFilterNumber { get; set; }
        public string AirFilterNumber { get; set; }
        public string InsuranceDetails { get; set; }
        public DateTime? InsuranceStartDate { get; set; }
        public DateTime? InsuranceEndDate { get; set; }
        public bool IsActive { get; set; }
        public int EntryUserId { get; set; }
        public DateTime EntryDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string MachineTypeName { get; set; }
    }
}
