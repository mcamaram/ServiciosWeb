using ServiciosWeb.Data.Models;
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
        public List<gestores_Bd> GetAllGestores()
        {
            using(var db = new gestoresEntities())
            {
                var listado = db.gestores_Bd.ToList();
                return listado;
            }
        }

        [WebMethod]
        public gestores_Bd GetGestor(int id)
        {
            using (var db = new gestoresEntities())
            {
                var gestor = db.gestores_Bd.FirstOrDefault(x => x.id == id);
                return gestor;
            }
        }
    }
}
