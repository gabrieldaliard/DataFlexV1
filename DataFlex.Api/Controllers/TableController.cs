using DataFlex.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Versioning;


namespace DataFlex.Api.Controllers
{

    //[Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class TableController : Controller
    {
        private readonly ITableRepository _tableRepository;
        
        public TableController(ITableRepository TableRepository)
        {
            _tableRepository = TableRepository;
        }

        // GET: TableControllers
        protected ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        [Route("Api/GetAllTables")]        
        public IActionResult GetAllTables()
        {
            try
            {
                return Ok(_tableRepository.GetAllTables());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [Route("Api/GetTableByName/{name}")]
        [HttpGet]
        public IActionResult GetTableByName(string name)
        {
            return Ok(_tableRepository.GetTableByName(name));
        }

        //[HttpGet("{id}")]
        [HttpGet]
        [MapToApiVersion("2.0")]
        [Route("Api/GetTableById/{id:int}")]        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public IActionResult GetTableById(int id)
        {
            if (id < 0) {
                return BadRequest("Id debe ser mayor a 0.");
            }
            try
            {
                var table = _tableRepository.GetTableById(id);
                if (table == null) {
                    return NotFound();
                }
                else
                {
                    return Ok(table);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }


    }
}
