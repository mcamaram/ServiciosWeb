using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiciosWeb.ServicioWFC2.Models
{
    [DataContract]
    public class Gestores
    {
        [DataMember(Order = 0)]
        public int id { get; set; }
        [DataMember(Order = 1)]
        public string nombre { get; set; }
        [DataMember(Order = 2)]
        public int lanzamiento { get; set; }
        [DataMember(Order = 3)]
        public string desarrollador { get; set; }
    }
}