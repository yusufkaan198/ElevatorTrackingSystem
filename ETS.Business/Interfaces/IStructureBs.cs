using CommonTypesLayer.Utilities;
using ETS.Model.Dtos.Structure;
using ETS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS.Business.Interfaces
{
    public interface IStructureBs
    {
        Task<ApiResponse<List<StructureGetDto>>> GetStructuresAsync();
        Task<ApiResponse<Structure>> InsertAsync(StructurePostDto structure); 
        Task<ApiResponse<NoData>> UpdateAsync(StructurePutDto structure);
        Task<ApiResponse<NoData>> DeleteAsync(int id);

    }
}
