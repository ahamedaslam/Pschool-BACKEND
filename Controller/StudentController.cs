using System;
using Microsoft.AspNetCore.Mvc;
using Pschool.API.DTOs.ParentDTO;
using Pschool.API.DTOs.StudentDTO;
using Pschool.API.Helper;
using Pschool.API.Models;
using Pschool.API.Services;

namespace Pschool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _service;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(StudentService service, ILogger<StudentsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<Response>> GetStudents()
        {
            string logId = Guid.NewGuid().ToString();
            _logger.LogInformation("[GetAllStudents] RequestId: {logId}", logId);
            try
            {
                var resp = await _service.GetAllAsync(logId);
                return StatusCode(HttpStatusMapper.GetHttpStatusCode(resp.ResponseCode), resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[GetAllStudents] Unexpected error occurred. RequestId: {logId}", logId);
                return StatusCode(500, ResponseHelper.ServerError($"Request failed. Log ID: {logId}"));

            }
        }

        [HttpPost("GetByParentId")]
        public async Task<ActionResult<Response>> GetByParent(ParentidDTO request)
        {
            string logId = Guid.NewGuid().ToString();
            _logger.LogInformation("[GetParentById] RequestId: {logId}", logId);

            try
            {
                var resp = await _service.GetByParentAsync(request,logId);
                return StatusCode(HttpStatusMapper.GetHttpStatusCode(resp.ResponseCode), resp);
            }
            catch (Exception ex)
            {
               _logger.LogError(ex, "[GetParentById] Unexpected error occurred. RequestId: {logId}", logId);
                return StatusCode(500, ResponseHelper.ServerError($"Request failed. Log ID: {logId}"));
            }
        }

        [HttpPost("GetStudentsById")]
        public async Task<ActionResult<Response>> GetStudent(StudentsIdDTO request)
        {
            string logId = Guid.NewGuid().ToString();
            _logger.LogInformation("[GetStudentsById] RequestId: {logId}", logId);
            try
            {
                var resp = await _service.GetByIdAsync(request,logId);
                return StatusCode(HttpStatusMapper.GetHttpStatusCode(resp.ResponseCode), resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[GetStudentById] Unexpected error occurred. LogId: {logId}",logId);
                return StatusCode(500, ResponseHelper.ServerError($"Request failed. Log ID: {logId}"));

            }
        }

        [HttpPost("CreateStudents")]
        public async Task<ActionResult<Response>> CreateStudent(AddStudentDTO student)
        {
            string logId = Guid.NewGuid().ToString();
            _logger.LogInformation("[CreateStudents] RequestId: {logId}", logId);

            try
            {
                var resp = await _service.AddAsync(student,logId);
                return StatusCode(HttpStatusMapper.GetHttpStatusCode(resp.ResponseCode), resp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[CreateStudents] Unexpected error occurred. RequestId: {logId}", logId);
                return StatusCode(500, ResponseHelper.ServerError($"Request failed. Log ID: {logId}"));
            }
        }

        [HttpPut("UpdateStudent")]
        public async Task<ActionResult<Response>> UpdateStudent(StudentsDTO student)
        {
            string logId = Guid.NewGuid().ToString();
            _logger.LogInformation("[UpdateStudent] RequestId: {logId}", logId);

            try
            {
                var resp = await _service.UpdateAsync(student,logId);
                return StatusCode(HttpStatusMapper.GetHttpStatusCode(resp.ResponseCode), resp);
            }
            catch (Exception ex)
            {
              
                _logger.LogError(ex, "[UpdateStudent] Unexpected error occurred. RequestId: {logId}", logId);
                return StatusCode(500, ResponseHelper.ServerError($"Request failed. Log ID: {logId}"));
            }
        }

        [HttpDelete("DeleteStudent/{id}")]
        public async Task<ActionResult<Response>> DeleteStudent(int  id)
        {
            string logId = Guid.NewGuid().ToString();
            _logger.LogInformation("[DeleteStudent] RequestId: {logId}", logId);

            try
            {
                var resp = await _service.DeleteAsync(id,logId);
                return StatusCode(HttpStatusMapper.GetHttpStatusCode(resp.ResponseCode), resp);
            }
            catch (Exception ex)
            {
               _logger.LogError(ex, "[DeleteStudent] Unexpected error occurred. RequestId: {logId}", logId);
                return StatusCode(500, ResponseHelper.ServerError($"Request failed. Log ID: {logId}"));
            }
        }
    }
}
