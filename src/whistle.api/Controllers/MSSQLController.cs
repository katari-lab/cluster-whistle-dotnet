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
            
            SqlConnection con = null;
            try
            {
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(cs);             
                con = new SqlConnection(sb.ConnectionString);
                con.Open(); 
                return this.Ok(new {
                    cs = cs
                });
            }            
            finally{
                if (con != null){
                    con.Close();
                }                
            }         
        }
    }
}