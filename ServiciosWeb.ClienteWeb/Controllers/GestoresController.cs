using Newtonsoft.Json;
using ServiciosWeb.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ServiciosWeb.ClienteWeb.Controllers
{
    public class GestoresController : Controller
    {
        // GET: Gestores
        public ActionResult Index()
        {
            //Invocar servicio rest api
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:49815/");

            var request = clienteHttp.GetAsync("api/Gestores").Result;
            /*clienteHttp.PostAsync();
              clienteHttp.PutAsync();
              clienteHttp.DeleteAsync();*/
            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Gestores>>(result);
                //dgvGestores.DataSource = listado;
                return View(listado);
            }
            return View();
        }
    }
}