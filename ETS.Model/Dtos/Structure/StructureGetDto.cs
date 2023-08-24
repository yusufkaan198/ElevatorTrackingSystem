using Ah.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS.Model.Dtos.Structure
{
    public class StructureGetDto : IDto
    {
        public int StructureID { get; set; }
        public string structureName { get; set; }
        public string structureAddress { get; set; }
        public string? managerName { get; set; }
        public string? managerPhone { get; set; }
        public DateTime? lastMaintenanceDate { get; set; }
        public int? debtInfo { get; set; }
        public string? elevatorInfo { get; set; }
    }
}
