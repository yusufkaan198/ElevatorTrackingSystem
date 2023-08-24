using Ah.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS.Model.Dtos.Structure
{
    public class StructurePutDto : IDto
    {
        public int StructureID { get; set; }
        public string StructureName { get; set; }
        public string StructureAddress { get; set; }
        public string? ManagerName { get; set; }
        public string? ManagerPhone { get; set; }
        public DateTime? LastMaintenanceDate { get; set; }
        public int? DebtInfo { get; set; }
        public string? ElevatorInfo { get; set; }
    }
}
