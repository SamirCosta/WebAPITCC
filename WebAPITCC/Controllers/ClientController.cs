using System;
using System.Collections;
using System.Web.Http;
using WebAPITCC.Models;

namespace WebAPITCC.Controllers
{
    public class ClientController : ApiController
    {
        Cliente cliente = new Cliente(); 

        // GET api/values/
        [HttpGet]
        [ActionName("getCli")]
        public Cliente Get(int id)
        {
            return cliente.SelecionaComIdCli(id);
        }

        [HttpGet]
        [ActionName("getAll")]
        public IEnumerable getAll()
        {
            return cliente.SelecionaCliente();
        }

        [HttpGet]
        [ActionName("validateLogin")]
        public Cliente validateLogin(string user, string pass)
        {
            return cliente.SelecionaClienteUser(user, pass);
        }

        [HttpGet]
        [ActionName("validateRegisterByEmail")]
        public Cliente validateRegisterByEmail(string email)
        {
            return cliente.ValidaLogin(email);
        }

        // POST api/values
        public Boolean Post([FromBody] Cliente mCliente)
        {
            if(mCliente == null)
            {
                return false;
            }

            try
            {
                cliente.InsertCliente(mCliente);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
           
            return true;
        }

        // PUT api/values/5
        [HttpPut]
        [ActionName("updateClient")]
        public Boolean Put([FromBody] Cliente item)
        {
            if (item == null)
            {
                return false;
            }

            cliente.UpdateCliente(item);

            return true;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
