using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using Web_API.Models;

namespace Web_API.Controllers
{
    /*
    A classe WebApiConfig pode requerer alterações adicionais para adicionar uma rota para esse controlador. Misture essas declarações no método Register da classe WebApiConfig conforme aplicável. Note que URLs OData diferenciam maiúsculas e minúsculas.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using Web_API.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Modelo_Pedido>("Modelo_Pedido");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class Modelo_PedidoController : ODataController
    {
        private Web_APIContext db = new Web_APIContext();

        // GET: odata/Modelo_Pedido
        [EnableQuery]
        public IQueryable<Modelo_Pedido> GetModelo_Pedido()
        {
            return db.Modelo_Pedido;
        }

        // GET: odata/Modelo_Pedido(5)
        [EnableQuery]
        public SingleResult<Modelo_Pedido> GetModelo_Pedido([FromODataUri] int key)
        {
            return SingleResult.Create(db.Modelo_Pedido.Where(modelo_Pedido => modelo_Pedido.IdPedido == key));
        }

        // PUT: odata/Modelo_Pedido(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Modelo_Pedido> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Modelo_Pedido modelo_Pedido = db.Modelo_Pedido.Find(key);
            if (modelo_Pedido == null)
            {
                return NotFound();
            }

            patch.Put(modelo_Pedido);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Modelo_PedidoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(modelo_Pedido);
        }

        // POST: odata/Modelo_Pedido
        public IHttpActionResult Post(Modelo_Pedido modelo_Pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Modelo_Pedido.Add(modelo_Pedido);
            db.SaveChanges();

            return Created(modelo_Pedido);
        }

        // PATCH: odata/Modelo_Pedido(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Modelo_Pedido> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Modelo_Pedido modelo_Pedido = db.Modelo_Pedido.Find(key);
            if (modelo_Pedido == null)
            {
                return NotFound();
            }

            patch.Patch(modelo_Pedido);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Modelo_PedidoExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(modelo_Pedido);
        }

        // DELETE: odata/Modelo_Pedido(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Modelo_Pedido modelo_Pedido = db.Modelo_Pedido.Find(key);
            if (modelo_Pedido == null)
            {
                return NotFound();
            }

            db.Modelo_Pedido.Remove(modelo_Pedido);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Modelo_PedidoExists(int key)
        {
            return db.Modelo_Pedido.Count(e => e.IdPedido == key) > 0;
        }
    }
}
