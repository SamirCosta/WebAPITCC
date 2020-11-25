using System;
using System.Collections;
using System.Web.Http;
using WebAPITCC.Models;

namespace WebAPITCC.Controllers
{
    public class ProductController : ApiController
    {

        Produto produto = new Produto();
        Produto_pedido produto_Pedido = new Produto_pedido();

        [HttpGet]
        [ActionName("getAll")]
        public IEnumerable getAll()
        {
            return produto.SelecionaProduto();
        }
        public Boolean Post([FromBody] Produto_pedido produtoPed)
        {
            if (produtoPed == null)
            {
                return false;
            }

            produto_Pedido.InsertProdPed(produtoPed);
            return true;
        }

    }
}
