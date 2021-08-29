using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ServiciosWeb.ServicioWFC2.Models;
using ServiciosWeb.Data.Models;

namespace ServiciosWeb.ServicioWFC2
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public Gestores GetGestor(int id)
        {
            var gestor = new Gestores();
            try
            {
                using (var db = new gestoresEntities())
                {
                    gestores_Bd gestor_db = db.gestores_Bd.Where(x => x.id == id).First();
                    gestor.id = gestor_db.id;
                    gestor.nombre = gestor_db.nombre;
                    gestor.lanzamiento = Convert.ToInt32(gestor_db.lanzamiento);
                    gestor.desarrollador = gestor_db.desarrollador;
                }
            }
            catch (Exception ex)
            {
                gestor = null;
            }
            return gestor;
        }

        public List<Gestores> GetGestores()
        {
            var lstGestores = new List<Gestores>();
            try
            {
                using (var db = new gestoresEntities())
                {
                    lstGestores = (from gestores in db.gestores_Bd
                                   select new Gestores
                                   {
                                       id = gestores.id,
                                       nombre = gestores.nombre,
                                       lanzamiento = Convert.ToInt32(gestores.lanzamiento),
                                       desarrollador = gestores.desarrollador
                                   }).ToList();

                }
            }
            catch (Exception ex)
            {
                lstGestores = null;
            }
            return lstGestores;
        }
    }
}
