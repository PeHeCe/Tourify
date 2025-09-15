using api.Config;
using api.Mappers;
using api.Models;
using api.Utils;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
	[ApiController]
	[Route("api/estabelecimento")]
	public class EstabelecimentoController : ControllerBase
	{
		private readonly AppDBContext _context;
		private Classes.Estabelecimento? estabelecimento {  get; set; }

		public EstabelecimentoController(AppDBContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			try
			{
				var estabelecimentos = _context.Estabelecimentos.ToList().Select(EstabelecimentoMapper.EstabelecimentoToClasses);

				return Ok(estabelecimentos);

			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet("buscar/{busca}")]
		public IActionResult GetEstabelecimento(string busca)
		{
			try
			{
				var estabelecimentos = _context.Estabelecimentos.Where(e => e.nome.ToLower().Contains(busca.ToLower())).ToList().Select(EstabelecimentoMapper.EstabelecimentoToClasses);

				return Ok(estabelecimentos);

			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPost]
		public IActionResult Create([FromBody] Estabelecimento estabelecimento)
		{
			try
			{
				var usuarioExistente = _context.Estabelecimentos.FirstOrDefault(u => u.nome == estabelecimento.nome);

				if (usuarioExistente != null)
				{
					return BadRequest("Estabelecimento já existente");
				}

				_context.Estabelecimentos.Add(estabelecimento);
				_context.SaveChanges();

				return Ok();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
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
