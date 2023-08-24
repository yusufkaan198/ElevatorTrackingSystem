using CommonTypesLayer.DataAccess.Implementations.EF;
using ETS.DataAccess.EF.Context;
using ETS.DataAccess.Interfaces;
using ETS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS.DataAccess.EF.Repositories
{
    public class StructureRepository : BaseRepository<Structure, ElevatorContext>, IStructureRepository
    {
        public async Task<Structure> GetByIdAsync(int structureId)
        {
            return await GetAsync(str => str.StructureID == structureId);
        }
    }
}
