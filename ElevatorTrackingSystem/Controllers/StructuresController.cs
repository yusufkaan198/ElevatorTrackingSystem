using ETS.Business.Interfaces;
using ETS.WebApi.Controllers;
using CommonTypesLayer.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ETS.Model.Dtos.Structure;

namespace ETS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StructuresController : BaseController
    {
        private readonly IStructureBs _structureBs;

        public StructuresController(IStructureBs structureBs)
        {
            _structureBs = structureBs;
        }

        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<StructureGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<StructureGetDto>>))]
        #endregion

        [HttpGet]
        public async Task<IActionResult> GetStructuresAsync()
        {
            var response = await _structureBs.GetStructuresAsync();

            return SendResponse(response);
        }

        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<StructureGetDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<StructureGetDto>))]
        #endregion

        [HttpPost]
        public async Task<IActionResult> SaveNewStructureAsync([FromBody] StructurePostDto dto)
        {
            var response = await _structureBs.InsertAsync(dto);

            return SendResponse(response);
        }

        #region Swagger
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateStructureAsync([FromBody] StructurePutDto dto)
        {
            var response = await _structureBs.UpdateAsync(dto);
            return SendResponse(response);
        }

        #region Swagger
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StructureGetDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        #endregion
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStructureAsync([FromRoute] int id)
        {
            var response = await _structureBs.DeleteAsync(id);
            return SendResponse(response);
        }
    }
}
