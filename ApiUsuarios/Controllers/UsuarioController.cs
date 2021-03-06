using ApiUsuarios.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuario al;
        
        public UsuarioController (IUsuario al)
        {
            this.al = al;
        }

        [HttpGet]
        [Route("GetUsuario")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await al.lst_usuario());
            }

            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        [HttpPost]
        [Route("AddUsuario")]
        public IActionResult Post([FromBody] Add_Usuario a)
        {
            try
            {
                return Ok(al.InsertarUsuario(a));

            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }
        }
        [HttpDelete]
        [Route("ElimUsuario")]

        public IActionResult Eliminarusuario(int idUsuario)
        {
            try
            {
                return Ok(al.DelUsuario(idUsuario));

            }
            catch (Exception e)
            {

                return StatusCode(500, e);
            }
        }
        [HttpGet]
        [Route("LstTipoIden")]
        public async Task<IActionResult> LstTipoIdentificacion()
        {
            try
            {
                return Ok(await al.LstTipoIdentificacion());
            }

            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        [HttpPut("{numeroidentificacion}")]
        public IActionResult Put(string Numeroidentificacion, [FromBody] Upd_Usuario a)
        {
            try
            {
                return Ok(al.EditaUsuario(Numeroidentificacion, a));

            }
            catch (Exception e)
            {

                return StatusCode (500 , e);
            }
        }

        [HttpPost]
        [Route("iniciarSesion")]
        public IActionResult Iniciarsesion([FromBody] Iniciarsesion a)
        {
            try
            {
                return Ok(al.InsertarUsuIniciarsesionario(a));

            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

       
    }
}
