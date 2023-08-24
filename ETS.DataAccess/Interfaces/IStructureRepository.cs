using CommonTypesLayer.DataAccess.Interfaces;
using CommonTypesLayer.Utilities;
using ETS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS.DataAccess.Interfaces
{
    public interface IStructureRepository : IBaseRepository<Structure>
    {
        Task<Structure> GetByIdAsync(int structureId);
    }
}
