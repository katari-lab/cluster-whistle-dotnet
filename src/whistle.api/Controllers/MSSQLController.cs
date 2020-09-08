using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Http;

namespace whistle.api.Controllers
{
    [ApiController]
    [Route("sql")]
    public class MSSQLController : ControllerBase
    {
        [HttpGet()]
        public IActionResult get()
        {
            return this.Ok(new { cs= "test" });
        }
        [HttpGet("connect")]
        public IActionResult Connect([FromQuery]string cs)
        {   
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(cs);             
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(sb.ConnectionString);
                con.Open(); 
                return this.Ok(new {
                    cs = cs
                });
            }
            catch(Exception ex){
                return this.StatusCode(StatusCodes.Status400BadRequest, new {
                    cs = cs,
                    e = ex.Message
                });
            }
            finally{
                con.Close();
            }         
        }
    }
}