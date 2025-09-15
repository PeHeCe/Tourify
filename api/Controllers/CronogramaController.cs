using api.Classes;
using api.Config;
using api.DTOs;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using System.Runtime.InteropServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace api.Controllers
{
	[ApiController]
	[Route("api/cronograma")]
	public class CronogramaController : ControllerBase
	{
		private readonly AppDBContext _context;
		private Classes.Cronograma? cronograma { get; set; }

		public CronogramaController(AppDBContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			try
			{
				var cronogramas = _context.Cronogramas.ToList().Select(CronogramaMapper.CronogramaToClasses);

				return Ok(cronogramas);

			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet("publicos")]
		public IActionResult GetCronogramasPublicos()
		{
			try
			{
				var result = new List<dynamic>();

				var cronogramas = _context.Cronogramas.Where(c => c.publico).ToList().Select(CronogramaMapper.CronogramaToClasses);

				string selectEstabelecimentos = """
						select e.nome from EstabelecimentoCronogramas ec 
						join Estabelecimentos e on e.id = ec.estabelecimentoid
						where cronogramaid = @p0
					""";

				foreach (var c in cronogramas)
				{
					dynamic cronoXEstab = new ExpandoObject();

					cronoXEstab.cronograma = c.cronograma;

					var resultEstabelecimentos = _context.Database.SqlQueryRaw<string>(selectEstabelecimentos, c.cronograma.id);

					cronoXEstab.estabelecimentos = resultEstabelecimentos;

					result.Add(cronoXEstab);
				}

				return Ok(result);

			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet("{idUsuario}")]
		public IActionResult GetCronogramasByIdUsuario(int idUsuario)
		{
			try
			{
				string sql = "SELECT c.*, uc.papel AS papel_usuario " +
			"FROM UsuariosCronogramas uc " +
			"JOIN Cronogramas c ON c.id = uc.Cronogramaid " +
			"WHERE usuarioid = @p0";

				//var result = _context.Set<ListaCronogramasDTO>().FromSqlRaw(sql, idUsuario).ToList();
				var result = _context.Database.SqlQueryRaw<ListaCronogramasDTO>(sql, idUsuario);

				var r = result.ToList();

				if (result == null || !result.Any())
				{
					return NotFound("Nenhum cronograma encontrado para este usuário.");
				}


				return Ok(result);

			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet("dados/{idCronograma}")]
		public IActionResult GetCronogramaEstabelecimentos(int idCronograma)
		{
			var crono = _context.Cronogramas.Find(idCronograma);

			string selectEstabelecimentos = """
					select ec.id, e.id as idEstabelecimento, e.nome, ec.horario, e.endereco, e.imagem from EstabelecimentoCronogramas ec 
					join Estabelecimentos e on e.id = ec.estabelecimentoid
					where cronogramaid = @p0
				"""
			;

			var resultEstabelecimentos = _context.Database.SqlQueryRaw<DadosEstabelecimentosCronogramaDTO>(selectEstabelecimentos, crono.id);

			object retorno = new { cronograma = crono, estabelecimentos = resultEstabelecimentos };

			return Ok(retorno);
		}

		[HttpPost("manual/{idUsuario}")]
		public IActionResult Create([FromBody] Models.Cronograma crono, int idUsuario)
		{
			try
			{
				Console.WriteLine(idUsuario);
				_context.Cronogramas.Add(crono);
				_context.SaveChanges();

				string insertUsuarioCronograma = "insert into UsuariosCronogramas (papel, usuarioid, Cronogramaid) values ('Proprietário', @p0, @p1)";
				_context.Database.ExecuteSqlRaw(insertUsuarioCronograma, idUsuario, crono.id);

				return Ok(crono.id);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return Ok(new { retorno = e.Message });
			}
		}

		[HttpPost("automatico/{idUsuario}")]
		public IActionResult CreateAutomatico([FromBody] Models.Cronograma crono, int idUsuario)
		{
			try
			{
				int quantidadeEstabelecimentos = new Random().Next(4, 6);
				TimeSpan duracaoPorEstabelecimento = (crono.hora_fim - crono.hora_inicio) / quantidadeEstabelecimentos;

				Console.WriteLine(idUsuario);
				_context.Cronogramas.Add(crono);
				_context.SaveChanges();

				string insertUsuarioCronograma = "insert into UsuariosCronogramas (papel, usuarioid, Cronogramaid) values ('Proprietário', @p0, @p1)";
				_context.Database.ExecuteSqlRaw(insertUsuarioCronograma, idUsuario, crono.id);

				// Implementar insert de 4 estabelecimentos x cronograma, cada um de um tipo
				string selectEstabelecimentos = """
							WITH tipos_selecionados AS (
								SELECT id
								FROM TiposEstabelecimentos te
								where EXISTS (select 1 from Estabelecimentos e where e.tipo_estabelecimento_id = te.id)
								ORDER BY RANDOM()
								LIMIT @p0
							), estabelecimentos_ordenados as ( 
								SELECT
									*,
									ROW_NUMBER() OVER (
										PARTITION BY tipo_estabelecimento_id
										ORDER BY RANDOM()
									) AS rn
								FROM Estabelecimentos
								WHERE tipo_estabelecimento_id IN (SELECT id FROM tipos_selecionados)
								and nivel_preco <= @p1
							)
							SELECT
								id, nome, endereco, cnpj, telefone_contato, horario_abertura, horario_fechamento, nivel_preco, descricao, site, tipo_estabelecimento_id, imagem
							FROM estabelecimentos_ordenados
							WHERE rn = 1
							order by RANDOM()
					""";

				var result = _context.Estabelecimentos.FromSqlRaw<Models.Estabelecimento>(selectEstabelecimentos, quantidadeEstabelecimentos, crono.custo_maximo).ToList();
				Console.WriteLine(result.Count);
				string insertEstabelecimentoCronograma = """
						insert into EstabelecimentoCronogramas (estabelecimentoid, cronogramaid, horario) values (@p0, @p1, @p2)
					""";

				int indice = 0;
				foreach (Models.Estabelecimento e in result)
				{
					TimeSpan horarioEstabelecimento = crono.hora_inicio.ToTimeSpan() + (duracaoPorEstabelecimento * indice);
					Console.WriteLine(horarioEstabelecimento);
					//Console.WriteLine(e.id);
					_context.Database.ExecuteSqlRaw(insertEstabelecimentoCronograma, e.id, crono.id, horarioEstabelecimento);
					indice++;
				}

				return Ok(crono.id);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return Ok(new { retorno = e.Message });
			}
		}

		[HttpGet("adicionar_estabelecimento/{idCronograma}/{idEstabelecimento}")]
		public IActionResult AddEstabelecimento(int idCronograma, int idEstabelecimento)
		{
			try
			{
				string selectEstabelecimentoAnterior = """
						select horario from EstabelecimentoCronogramas where cronogramaid = @p0 order by horario desc limit 1
					""";

				var result = _context.Database.SqlQueryRaw<TimeOnly>(selectEstabelecimentoAnterior, idCronograma).ToList();

				if (!result.Any())
				{
					string selectCronograma = """
						select hora_inicio from Cronogramas where id = @p0
					""";

					result = _context.Database.SqlQueryRaw<TimeOnly>(selectCronograma, idCronograma).ToList();
				}

				TimeSpan horarioNovoEstabelecimento = result.First().ToTimeSpan() + TimeSpan.FromHours(1);

				string insertEstabelecimentoXCronograma = """
						insert into EstabelecimentoCronogramas (estabelecimentoid, cronogramaid, horario) values (@p0, @p1, @p2)
					""";

				_context.Database.ExecuteSqlRaw(insertEstabelecimentoXCronograma, idEstabelecimento, idCronograma, horarioNovoEstabelecimento);

				return Ok(horarioNovoEstabelecimento);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return Ok(new { retorno = e.Message });
			}
		}

		[HttpGet("remover_estabelecimento/{idCronogramaEstabelecimento}")]
		public IActionResult RemoveEstabelecimento(int idCronogramaEstabelecimento)
		{
			try
			{
				string deleteEstabelecimento = """
						delete from EstabelecimentoCronogramas where id = @p0
					""";

				_context.Database.ExecuteSqlRaw(deleteEstabelecimento, idCronogramaEstabelecimento);

				return Ok();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return Ok(new { retorno = e.Message });
			}
		}
	}
}	