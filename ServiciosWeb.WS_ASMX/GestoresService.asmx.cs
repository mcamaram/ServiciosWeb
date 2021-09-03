using ServiciosWeb.Data.Models;
using ServiciosWeb.WS_ASMX.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServiciosWeb.WS_ASMX
{
    /// <summary>
    /// Descripción breve de GestoresService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class GestoresService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<GestorCLS> GetAllGestores()
        {
            var lstgestores = new List<GestorCLS>();
            try
            {
                using (var db = new gestoresEntities())
                {
                    lstgestores = (from gestores in db.gestores_Bd
                                   select new GestorCLS
                                   {
                                       Id = gestores.id,
                                       Nombre = gestores.nombre,
                                       Lanzamiento = gestores.lanzamiento,
                                       Desarrollador = gestores.desarrollador
                                   }).ToList();
                }
            }
            catch(Exception ex)
            {
                lstgestores = null;
            }
            return lstgestores;
        }

        [WebMethod]
        public GestorCLS GetGestor(int id)
        {
            var objGestor = new GestorCLS();
            try
            {
                using (var db = new gestoresEntities())
                {
                    var gestor = db.gestores_Bd.FirstOrDefault(x => x.id == id);
                    objGestor.Id = gestor.id;
                    objGestor.Nombre = gestor.nombre;
                    objGestor.Lanzamiento = gestor.lanzamiento;
                    objGestor.Desarrollador = gestor.desarrollador;
                }
            }
            catch(Exception ex)
            {
                objGestor = null;
            }
            return objGestor;
        }

        [WebMethod]
        public bool Post(GestorCLS gestores)
        {
            bool rpta = false;
            try
            {
                using (var db = new gestoresEntities())
                {
                    gestores_Bd gestoresdb = new gestores_Bd();
                    gestoresdb.nombre = gestores.Nombre;
                    gestoresdb.lanzamiento = gestores.Lanzamiento;
                    gestoresdb.desarrollador = gestores.Desarrollador;
                    db.gestores_Bd.Add(gestoresdb);
                    rpta = db.SaveChanges() > 0;
                }
            }
            catch(Exception ex)
            {
                rpta = false;
                throw new Exception(ex.Message);
            }
            return rpta;
        }

        [WebMethod]
        public bool Put(GestorCLS gestores)
        {
            bool rpta = false;
            try
            {
                using (var db = new gestoresEntities())
                {
                    gestores_Bd objgestoresDB = db.gestores_Bd.Where(x => x.id == gestores.Id).First();
                    objgestoresDB.id = gestores.Id;
                    objgestoresDB.nombre = gestores.Nombre;
                    objgestoresDB.lanzamiento = gestores.Lanzamiento;
                    objgestoresDB.desarrollador = gestores.Desarrollador;
                    rpta = db.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                rpta = false;
                throw new Exception(ex.Message);
            }
            return rpta;
        }

        [WebMethod]
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {
                using (var db = new gestoresEntities())
                {
                    gestores_Bd objgestoresDB = db.gestores_Bd.Where(x => x.id == id).First();
                    db.gestores_Bd.Remove(objgestoresDB);
                    rpta = db.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                rpta = false;
                throw new Exception(ex.Message);
            }
            return rpta;
        }

    }
}
