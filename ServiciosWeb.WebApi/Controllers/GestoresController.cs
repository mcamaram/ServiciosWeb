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
    }
}
