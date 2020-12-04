using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using GraphQL_API.GraphQL;
using GraphQL_API.Entities;


namespace GraphQL_API.Controllers
{

  [Route("graphql")]
  [ApiController]
  public class GraphQLController : Controller
  {

        private readonly ISchema _schema;
        private readonly IDocumentExecuter _executer;
        public GraphQLController(ISchema schema, IDocumentExecuter executer)
        {
            _schema = schema;
            _executer = executer;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var result = await _executer.ExecuteAsync(_ =>
            {
                _.Schema = _schema; 
                return BadRequest();
            }
            return Ok(result.Data);
        }
    }
  }

