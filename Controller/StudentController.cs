using System;
using Microsoft.AspNetCore.Mvc;
using Pschool.API.DTOs.ParentDTO;
using Pschool.API.DTOs.StudentDTO;
using Pschool.API.Models;
using Pschool.API.Services;

namespace Pschool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _service;

        public StudentsController(StudentService service)
        {
            _service = service;
        }

        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<Response>> GetStudents()
        {
            try
            {
                var resp = await _service.GetAllAsync();
                return Ok(resp);
            }
            catch (Exception ex)
            {
                var error = new Response
                {
                    UniqueID = Guid.NewGuid().ToString(),
                    ResponseCode = "500",
                    ResponseDescription = ex.Message,
                    ResponseObject = null
                };
                return StatusCode(500, error);
            }
        }

        [HttpPost("GetByParentId")]
        public async Task<ActionResult<Response>> GetByParent(ParentidDTO request)
        {
            try
            {
                var resp = await _service.GetByParentAsync(request);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                var error = new Response
                {
                    UniqueID = Guid.NewGuid().ToString(),
                    ResponseCode = "500",
                    ResponseDescription = ex.Message,
                    ResponseObject = null
                };
                return StatusCode(500, error);
            }
        }

        [HttpPost("GetStudentsById")]
        public async Task<ActionResult<Response>> GetStudent(StudentsIdDTO request)
        {
            try
            {
                var resp = await _service.GetByIdAsync(request);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                var error = new Response
                {
                    UniqueID = Guid.NewGuid().ToString(),
                    ResponseCode = "500",
                    ResponseDescription = ex.Message,
                    ResponseObject = null
                };
                return StatusCode(500, error);
            }
        }

        [HttpPost("CreateStudents")]
        public async Task<ActionResult<Response>> CreateStudent(StudentsDTO student)
        {
            try
            {
                var resp = await _service.AddAsync(student);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                var error = new Response
                {
                    UniqueID = Guid.NewGuid().ToString(),
                    ResponseCode = "500",
                    ResponseDescription = ex.Message,
                    ResponseObject = null
                };
                return StatusCode(500, error);
            }
        }

        [HttpPut("UpdateStudent")]
        public async Task<ActionResult<Response>> UpdateStudent(UpdStudentsDTO student)
        {
            

            try
            {
                var resp = await _service.UpdateAsync(student);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                var error = new Response
                {
                    UniqueID = Guid.NewGuid().ToString(),
                    ResponseCode = "500",
                    ResponseDescription = ex.Message,
                    ResponseObject = null
                };
                return StatusCode(500, error);
            }
        }

        [HttpDelete("DeleteStudent")]
        public async Task<ActionResult<Response>> DeleteStudent(StudentsIdDTO request)
        {
            try
            {
                var resp = await _service.DeleteAsync(request);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                var error = new Response
                {
                    UniqueID = Guid.NewGuid().ToString(),
                    ResponseCode = "500",
                    ResponseDescription = ex.Message,
                    ResponseObject = null
                };
                return StatusCode(500, error);
            }
        }
    }
}
