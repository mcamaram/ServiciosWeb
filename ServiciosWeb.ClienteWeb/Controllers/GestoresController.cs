using Newtonsoft.Json;
using ServiciosWeb.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
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
        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Gestores gestores)
        {
            //Invocar servicio rest api
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:49815/");

            var request = clienteHttp.PostAsync("api/Gestores", gestores, new JsonMediaTypeFormatter()).Result;
            /*clienteHttp.PostAsync();
              clienteHttp.PutAsync();
              clienteHttp.DeleteAsync();*/
            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(result);
                if (correcto)
                {
                    return RedirectToAction("Index");
                }
                //dgvGestores.DataSource = listado;
                return View(gestores);
            }
            return View(gestores);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            //Invocar servicio rest api
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:49815/");

            var request = clienteHttp.GetAsync("api/Gestores/?id=" + id ).Result;
            //var request = clienteHttp.GetAsync("api/Gestores/?id=" + id + "&nombre=" + param2).Result;
            /*clienteHttp.PostAsync();
              clienteHttp.PutAsync();
              clienteHttp.DeleteAsync();*/
            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                var gestor = JsonConvert.DeserializeObject<Gestores>(result);
                return View(gestor);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Actualizar(Gestores gestores)
        {
            //Invocar servicio rest api
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:49815/");

            var request = clienteHttp.PutAsync("api/Gestores", gestores, new JsonMediaTypeFormatter()).Result;
            /*clienteHttp.PostAsync();
              clienteHttp.PutAsync();
              clienteHttp.DeleteAsync();*/
            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(result);
                if (correcto)
                {
                    return RedirectToAction("Index");
                }
                //dgvGestores.DataSource = listado;
                return View(gestores);
            }
            return View(gestores);
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            //Invocar servicio rest api
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:49815/");

            var request = clienteHttp.DeleteAsync("api/Gestores/?id=" + id).Result;
            //var request = clienteHttp.GetAsync("api/Gestores/?id=" + id + "&nombre=" + param2).Result;
            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                var correcto = JsonConvert.DeserializeObject<bool>(result);
                if (correcto)
                {
                    return RedirectToAction("Index");
                }
                //dgvGestores.DataSource = listado;
            }
            return View();
        }

        [HttpGet]
        public ActionResult Detalle(int id)
        {
            //Invocar servicio rest api
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://localhost:49815/");

            var request = clienteHttp.GetAsync("api/Gestores/?id=" + id).Result;
            //var request = clienteHttp.GetAsync("api/Gestores/?id=" + id + "&nombre=" + param2).Result;
            if (request.IsSuccessStatusCode)
            {
                var result = request.Content.ReadAsStringAsync().Result;
                var gestor = JsonConvert.DeserializeObject<Gestores>(result);
                return View(gestor);
            }
            return View();
        }
    }
}