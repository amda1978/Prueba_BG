using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNetCore.JsonPatch;
using PruebaBG1.Models;

namespace PruebaBG1.Controllers
{
    public class ProductoController : ApiController
    {
        private ModelData db = new ModelData();

        // GET: api/Producto
        public IQueryable<Producto> GetProducto()
        {
            return db.Producto.OrderBy(P => P.price);
        }

        // GET: api/Producto/5
        [ResponseType(typeof(Producto))]
        public IHttpActionResult GetProducto(int id)
        {
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        // PUT: api/Producto/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProducto(int id, Producto producto)
        {
            return BadRequest("ESTE METODO NO ESTÁ DISPONIBLE...");
            
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != producto.Id)
            //{
            //    return BadRequest();
            //}

            //db.Entry(producto).State = EntityState.Modified;

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ProductoExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Producto
        [ResponseType(typeof(Producto))]
        public IHttpActionResult PostProducto(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            producto.isPublished = "False";
            db.Producto.Add(producto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = producto.Id }, producto);
        }

        // Patch: api/Producto
        //[HttpPatch("{id}")]
        //public IHttpActionResult Patch(Guid id,[FromBody] JsonPatchDocument<Producto> ProductoPatch)
        //{ 
        //}

        // DELETE: api/Producto/5
        [ResponseType(typeof(Producto))]
        public IHttpActionResult DeleteProducto(int id)
        {
            return Unauthorized();
            //Producto producto = db.Producto.Find(id);
            //if (producto == null)
            //{
            //    return NotFound();
            //}

            //db.Producto.Remove(producto);
            //db.SaveChanges();

            //return Ok(producto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductoExists(int id)
        {
            return db.Producto.Count(e => e.Id == id) > 0;
        }
    }
}