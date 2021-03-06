using ApiUsuarios.Data;
using ApiUsuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuarios
{
    public interface IUsuario
    {
        Task<IEnumerable<Get_Usuario>> lst_usuario();

        bool InsertarUsuario(Add_Usuario a);

        bool DelUsuario(int Usuario);
        Task<IEnumerable<Lst_TipoIdentificacion>> LstTipoIdentificacion();

        bool InsertarUsuIniciarsesionario(Iniciarsesion a);
    }
}
