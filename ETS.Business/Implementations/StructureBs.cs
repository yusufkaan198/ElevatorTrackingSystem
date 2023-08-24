using AutoMapper;
using CommonTypesLayer.Utilities;
using ETS.Business.CustomExceptions;
using ETS.Business.Interfaces;
using ETS.DataAccess.Interfaces;
using ETS.Model.Dtos.Structure;
using ETS.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS.Business.Implementations
{
    public class StructureBs : IStructureBs
    {
        private readonly IStructureRepository _repo;
        private readonly IMapper _mapper;
        public StructureBs(IStructureRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        
        public async Task<ApiResponse<List<StructureGetDto>>> GetStructuresAsync()
        {
            var structures = await _repo.GetAllAsync();
            if (structures.Count > 0)
            {
                var structureList = _mapper.Map<List<StructureGetDto>>(structures);
                var response = ApiResponse<List<StructureGetDto>>.Success(200, structureList); 
                
                return response;
            }
            throw new NotFoundException("Şu an yapacak işiniz bulunmamakta.");
        }

        public async Task<ApiResponse<Structure>> InsertAsync(StructurePostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedecek bina bilgisi yok.");
            
            var structure = _mapper.Map<Structure>(dto);
            var insertedStructure = await _repo.InsertAsync(structure);

            return ApiResponse<Structure>.Success(201, insertedStructure);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(StructurePutDto dto)
        {
            if ( _repo.GetByIdAsync(dto.StructureID) == null)
                throw new BadRequestException("Güncellenek istediğiniz bina mevcut değil.");

            var structure = _mapper.Map<Structure>(dto);
            await _repo.UpdateAsync(structure);

            return ApiResponse<NoData>.Success(200);
        }

        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var structure = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(structure);

            return ApiResponse<NoData>.Success(200);
        }
    }
}
