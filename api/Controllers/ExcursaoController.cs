using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using api.Classes;
using api.Config;
using api.DTOs;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/excursao")]
    public class ExcursaoController : ControllerBase
    {
        private readonly AppDBContext _context;
        private Classes.Excursao? excursao {get; set;}

        public ExcursaoController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var excursoes = _context.Excursoes.ToList()
                    .Select(ExcursaoMapper.ExcursaoToClasses);

                return Ok(excursoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var excursao = _context.Excursoes.Find(id);
                
                if(excursao == null) {
                    return NotFound();
                }

                return Ok(ExcursaoMapper.ExcursaoToClasses(excursao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("empresa/{id}")]
        public IActionResult GetByUser([FromRoute] int id)
        {
            try
            {
                var excursoes = _context.Excursoes.ToList()
                    .Select(ExcursaoMapper.ExcursaoToClasses)
                    .ToList()
                    .FindAll(e => e.excursao.empresa.id == id);

                if(excursoes.Count == 0) {
                    return NotFound();
                }

                return Ok(excursoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Models.Excursao excursao)
        {
            try
            {
                Models.Empresa? empresa = _context.Empresas.Find(excursao.empresa.id);
                
                if(empresa == null) {
                    return NotFound("Empresa não encontrada");
                }

                excursao.empresa = empresa;

                _context.Excursoes.Add(excursao);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("editar/{id}")]
        public IActionResult Edit([FromRoute] int id, [FromBody] ExcursaoEdit excursao)
        {
            try
            {
                var excursao_model = _context.Excursoes.Find(id);
                
                if(excursao_model == null) {
                    return NotFound();
                }

                this.excursao = ExcursaoMapper.ExcursaoToClasses(excursao_model);

                this.excursao.EditarExcursao(excursao);

                _context.Excursoes.Update(this.excursao.excursao);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var excursao = _context.Excursoes.Find(id);
                
                if(excursao == null) {
                    return NotFound();
                }

                _context.Excursoes.Remove(excursao);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}