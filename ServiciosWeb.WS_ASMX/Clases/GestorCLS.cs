using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosWeb.WS_ASMX.Clases
{
    public class GestorCLS
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Lanzamiento { get; set; }
        public string Desarrollador { get; set; }
    }
}