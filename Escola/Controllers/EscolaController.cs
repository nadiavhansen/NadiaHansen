using Escola.Entidades;
using Escola.Service;
using Escola.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;

namespace Escola.Controllers
{
    [ApiController]
    [Route("escola")]
    public class EscolaController : ControllerBase
    {
        private readonly IEscolaService _escolaService;

        public EscolaController(IEscolaService escolaService)
        {
            _escolaService = escolaService;
        }

        [HttpPost]
        [Route("salvarGabarito")]
        public HttpStatusCode SalvarGabarito([FromBody]Gabarito gabarito)
        {
            var retorno = _escolaService.SalvarGabarito(gabarito);

            if (retorno)
            {
                return HttpStatusCode.OK;
            }

            return HttpStatusCode.BadRequest;
        }

        [HttpPost]
        [Route("salvarAluno")]
        public HttpStatusCode SalvarAluno([FromBody] CartaoRepsotaAluno aluno)
        {
            var retorno = _escolaService.SalvarAluno(aluno);

            if (retorno)
            {
                return HttpStatusCode.OK;
            }

            return HttpStatusCode.BadRequest;
        }

        [HttpGet]
        [Route("buscarNota/{matricula:int}")]
        public AlunoViewModel BuscarAluno(int matricula)
        {
            var retorno = _escolaService.RetonarMedia(matricula);
            return retorno;
        }
       
        [HttpGet]
        [Route("buscarAlunosAprovados")]
        public List<AlunoViewModel> BuscarAlunosAprovados()
        {
            var retorno = _escolaService.BuscarAlunosAprovados();

            return retorno;
        }
    }
}
