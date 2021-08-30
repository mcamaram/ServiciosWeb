using ServiciosWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiciosWeb.WebApi.Controllers
{
    public class GestoresController : ApiController
    {
        /// <summary>
        /// Metodo para obtener todos los gestores de base de datos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<gestores_Bd> Get()
        {
            using(var db = new gestoresEntities())
            {
                var listado = db.gestores_Bd.ToList();
                return listado;
            }  
        }
        /// <summary>
        /// Metodo para obtener un unico gestor por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public gestores_Bd GetById(int id)
        {
            using (var db = new gestoresEntities())
            {
                var gestor = db.gestores_Bd.FirstOrDefault(x => x.id == id);
                return gestor;
            }
        }
        /// <summary>
        /// Metodo para insertar un registro en la tabla gestores
        /// </summary>
        /// <param name="gestores"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Post(gestores_Bd gestores)
        {
            bool rpta = false;
            try
            {
                using(var db = new gestoresEntities())
                {
                    db.gestores_Bd.Add(gestores);
                    rpta = db.SaveChanges() > 0;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rpta;
        }
        /// <summary>
        /// Metdodo para actualizar los datos de la tabla gestores
        /// </summary>
        /// <param name="gestores"></param>
        /// <returns></returns>
        [HttpPut]
        public bool Put(gestores_Bd gestores)
        {
            bool rpta = false;
            try
            {
                using(var db = new gestoresEntities())
                {
                    var gestorupdate = db.gestores_Bd.FirstOrDefault(x => x.id == gestores.id);
                    gestorupdate.id = gestores.id;
                    gestorupdate.nombre = gestores.nombre;
                    gestorupdate.lanzamiento = gestores.lanzamiento;
                    gestorupdate.desarrollador = gestores.desarrollador;
                    rpta = db.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rpta;
        }
        /// <summary>
        /// Metodo para eliminar un registro de la tabla
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using(var db = new gestoresEntities())
                {
                    var gestordelete = db.gestores_Bd.FirstOrDefault(x => x.id == id);
                    db.gestores_Bd.Remove(gestordelete);
                    rpta = db.SaveChanges() > 0;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rpta;
        }
    }
}
