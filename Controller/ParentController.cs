using Microsoft.AspNetCore.Mvc;
using Pschool.API.DTOs.ParentDTO;
using Pschool.API.Helper;
using Pschool.API.Models;
using Pschool.API.Services;

namespace Pschool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly ParentService _service;
        private readonly ILogger<ParentsController> _logger;

        public ParentsController(ParentService service, ILogger<ParentsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Response>> GetParents()
        {
            string logId = Guid.NewGuid().ToString();
            _logger.LogInformation("[GetAllParents] RequestId: {logId}", logId);
            
            try
            {
                var result = await _service.GetAllParentsAsync(logId);
                return StatusCode(HttpStatusMapper.GetHttpStatusCode(result.ResponseCode), result);          
                    
                    }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[GetAllParents] Unexpected error occurred. RequestId: {logId}", logId);
                 return StatusCode(500, ResponseHelper.ServerError($"Request failed. Log ID: {logId}"));

            }
        }

        [HttpPost("GetById")]
        public async Task<ActionResult<Response>> GetParent(ParentidDTO id)
        {
            string logId = Guid.NewGuid().ToString();
            _logger.LogInformation("[GetParentsById] RequestId: {logId}", logId);
            try
            {
                var result = await _service.GetParentByIdAsync(id,logId);
                return StatusCode(HttpStatusMapper.GetHttpStatusCode(result.ResponseCode), result);
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex, "[GetParentsById] Unexpected error occurred. RequestId: {logId}", logId);
                return StatusCode(500, ResponseHelper.ServerError($"Request failed. Log ID: {logId}"));

            }
        }

        [HttpPost("CreateParent")]
        public async Task<ActionResult<Response>> CreateParent([FromBody] ParentsDTO parent)
        {
            string logId = Guid.NewGuid().ToString();
            _logger.LogInformation("[CreateParent] RequestId: {logId}", logId);
            try
            {
                var result = await _service.AddParentAsync(parent,logId);
                return StatusCode(HttpStatusMapper.GetHttpStatusCode(result.ResponseCode), result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[CreateParent] Unexpected error occurred: {logId}",logId);
                return StatusCode(500, ResponseHelper.ServerError($"Request failed. Log ID: {logId}"));

            }
        }

  
        [HttpPut("UpdateParent")]
        public async Task<ActionResult<Response>> UpdateParent( [FromBody] UpdateParentDTO parent)
        {
            string logId = Guid.NewGuid().ToString();
            _logger.LogInformation("[UpdateParent] RequestId: {logId}", logId);
            try
            {
               

                var result = await _service.UpdateParentAsync(parent,logId);
                return StatusCode(HttpStatusMapper.GetHttpStatusCode(result.ResponseCode), result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[UpdateParent] Unexpected error occurred. RequestId: {logId}", logId);
                return StatusCode(500, ResponseHelper.ServerError($"Request failed. Log ID: {logId}"));


            }
        }

    
        [HttpDelete("DeleteParent")]
        public async Task<ActionResult<Response>> DeleteParent(ParentidDTO id)
        {
            string logId = Guid.NewGuid().ToString();
            _logger.LogInformation("[DeleteParent] RequestId: {logId}", logId);
            try
            {
                var result = await _service.DeleteParentAsync(id);
                return StatusCode(HttpStatusMapper.GetHttpStatusCode(result.ResponseCode), result);
            }
            catch (Exception ex)
            {
               _logger.LogError(ex, "[DeleteParent] Unexpected error occurred. RequestId: {logId}", logId);
                return StatusCode(500, ResponseHelper.ServerError($"Request failed. Log ID: {logId}"));
            }
        }
    }
}
