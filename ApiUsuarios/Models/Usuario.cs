using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuarios.Models
{
    public class Get_Usuario
    {

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string IdTipoIdentificacion { get; set; }
        public string Numeroidentificacion { get; set; }
        public string CorreoElectronico { get; set; }
    }

    public class Add_Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string IdTipoIdentificacion { get; set; }
        public string Numeroidentificacion { get; set; }
        public string Contrasena { get; set; }
        public string CorreoElectronico { get; set; }
    }
    public class Upd_Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string IdTipoIdentificacion { get; set; }
        public string Numeroidentificacion { get; set; }
        public string Contrasena { get; set; }
        public string CorreoElectronico { get; set; }
    }

    public class Lst_TipoIdentificacion
    {
        public string IdIdentificacion { get; set; }
        public string Descripcion { get; set; }
    }
    public class Iniciarsesion
    {
        public string user { get; set; }
        public string pass { get; set; }
        public string ingreso { get; set; }
    }

}
