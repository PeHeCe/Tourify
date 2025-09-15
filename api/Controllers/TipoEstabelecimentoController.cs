using api.Config;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
	[ApiController]
	[Route("api/tipo_estabelecimento")]
	public class TipoEstabelecimentoController : ControllerBase
	{
		private readonly AppDBContext _context;
		private Classes.Estabelecimento? estabelecimento { get; set; }

		public TipoEstabelecimentoController(AppDBContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			try
			{
				var tipoEstabelecimentos = _context.TiposEstabelecimentos.ToList();

				return Ok(tipoEstabelecimentos);

			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPost]
		public IActionResult Create([FromBody] TipoEstabelecimento tipo)
		{
			try
			{
				var tipoExistente = _context.TiposEstabelecimentos.FirstOrDefault(u => u.nome == tipo.nome);

				if (tipoExistente != null)
				{
					return BadRequest("Tipo de estabelecimento já existente");
				}

				_context.TiposEstabelecimentos.Add(tipo);
				_context.SaveChanges();

				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetById([FromRoute] int id)
		{
			try
			{
				var estabelecimento = _context.Estabelecimentos.Find(id);

				if (estabelecimento == null)
				{
					return NotFound();
				}

				return Ok(estabelecimento);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}
