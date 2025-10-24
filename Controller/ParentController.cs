using Microsoft.AspNetCore.Mvc;
using Pschool.API.DTOs.ParentDTO;
using Pschool.API.Models;
using Pschool.API.Services;

namespace Pschool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly ParentService _service;

        public ParentsController(ParentService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Response>> GetParents()
        {
            try
            {
                var result = await _service.GetAllParentsAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response
                {
                    ResponseCode = "99",
                    ResponseDescription = $"An error occurred while fetching parents: {ex.Message}"
                });
            }
        }

        [HttpPost("GetById")]
        public async Task<ActionResult<Response>> GetParent(ParentidDTO id)
        {
            try
            {
                var result = await _service.GetParentByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response
                {
                    ResponseCode = "99",
                    ResponseDescription = $"An error occurred while fetching the parent: {ex.Message}"
                });
            }
        }

        [HttpPost("CreateParent")]
        public async Task<ActionResult<Response>> CreateParent([FromBody] ParentsDTO parent)
        {
            try
            {
                var result = await _service.AddParentAsync(parent);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response
                {
                    ResponseCode = "99",
                    ResponseDescription = $"An error occurred while creating the parent: {ex.Message}"
                });
            }
        }

  
        [HttpPut("UpdateParent")]
        public async Task<ActionResult<Response>> UpdateParent( [FromBody] UpdateParentDTO parent)
        {
            try
            {
               

                var result = await _service.UpdateParentAsync(parent);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response
                {
                    ResponseCode = "99",
                    ResponseDescription = $"An error occurred while updating the parent: {ex.Message}"
                });
            }
        }

    
        [HttpDelete("DeleteParent")]
        public async Task<ActionResult<Response>> DeleteParent(ParentidDTO id)
        {
            try
            {
                var result = await _service.DeleteParentAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response
                {
                    ResponseCode = "99",
                    ResponseDescription = $"An error occurred while deleting the parent: {ex.Message}"
                });
            }
        }
    }
}
