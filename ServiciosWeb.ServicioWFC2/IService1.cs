using ServiciosWeb.ServicioWFC2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiciosWeb.ServicioWFC2
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        Gestores GetGestor(int id);
        [OperationContract]
        List<Gestores> GetGestores();
        [OperationContract]
        bool Post(Gestores gestores);
        [OperationContract]
        bool Put(Gestores gestor);
        [OperationContract]
        bool Delete(int id);

        // TODO: agregue aquí sus operaciones de servicio
    }


 
}
