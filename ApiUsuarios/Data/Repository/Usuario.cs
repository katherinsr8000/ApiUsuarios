using ApiUsuarios.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuarios.Data
{
    public class Usuario : BaseRepository, IUsuario
    {

        public Usuario(string CnnString) : base(CnnString)
        {
        }
        public async Task<IEnumerable<Get_Usuario>> lst_usuario()
        {
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    return await db.QueryAsync<Get_Usuario>("Usuario.Get_Usuario", commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public bool InsertarUsuario(Add_Usuario a)
        {

            IDbCommand dbTransation;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Nombre", a.Nombre);
            parameters.Add("@Apellido", a.Apellido);
            parameters.Add("@IdTipoIdentificacion", Convert.ToInt32( a.IdTipoIdentificacion));
            parameters.Add("@Numeroidentificacion", a.Numeroidentificacion);
            parameters.Add("@Contrasena", a.Contrasena);
            parameters.Add("@CorreoElectronico", a.CorreoElectronico);

            using (IDbConnection db = GetConnection())
            {
                db.Open();

                try
                {
                    db.ExecuteScalar("Usuario.Add_Usuario",
                        commandType: CommandType.StoredProcedure,
                        param: parameters);
                    db.Close();
                    return true;
                }
                catch (Exception e)
                {
                    db.Close();
                    return false;
                    throw e;
                }
            }
        }
        public bool DelUsuario(int Usuario)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@IdUsuario", Usuario);

                using (IDbConnection db = GetConnection())
                {
                    db.Open();

                    try
                    {
                        db.ExecuteScalar("Usuario.Del_Usuario", commandType: CommandType.StoredProcedure, param: parameters);
                        db.Close();
                        return true;
                    }
                    catch (Exception e)
                    {
                        db.Close();
                        return false;
                        throw e;
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public async Task<IEnumerable<Lst_TipoIdentificacion>> LstTipoIdentificacion()
        {
            try
            {
                using (IDbConnection db = GetConnection())
                {
                    return await db.QueryAsync<Lst_TipoIdentificacion>("Usuario.Lst_TipoIdentificacion", commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public bool EditaUsuario ( string Numeroidentificacion ,  Upd_Usuario a)
        {

            IDbCommand dbTransation;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Numeroidentificacion", Numeroidentificacion);
            parameters.Add("@Nombre", a.Nombre);
            parameters.Add("@Apellido", a.Apellido);
            parameters.Add("@IdTipoIdentificacion", Convert.ToInt32(a.IdTipoIdentificacion));
            parameters.Add("@Contrasena", a.Contrasena);
            parameters.Add("@CorreoElectronico", a.CorreoElectronico);


            using (IDbConnection db = GetConnection())
            {
                db.Open();

                try
                {
                    string result = null;
                    object value = db.ExecuteScalar("Usuario.Upd_Usuario",
                        commandType: CommandType.StoredProcedure,
                        param: parameters);

                    return true;
                    db.Close();
                }
                catch (Exception e)
                {
                    db.Close();
                    return false;
                    throw e;
                }
            }
        }

        public bool InsertarUsuIniciarsesionario( Iniciarsesion a)
        {

            IDbCommand dbTransation;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@user", a.user);
            parameters.Add("@pass", a.pass);

            using (IDbConnection db = GetConnection())
            {
                db.Open();

                try
                {
                    string result = null;
                    object value = db.ExecuteScalar("Usuario.Iniciarsesion",
                        commandType: CommandType.StoredProcedure,
                        param: parameters);

                    if (value != null)
                    {
                        result = value.ToString();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    db.Close();
                }
                catch (Exception e)
                {
                    db.Close();
                    return false;
                    throw e;
                }
            }
        }

    }
}
