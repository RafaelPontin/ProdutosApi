using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApi.Model;
using UsuariosApi.Repositories;

namespace UsuariosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioRepository _UsuarioRepository;

        public UsuarioController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }


        [AcceptVerbs("POST")]
        [Route("Add")]
        [ProducesResponseType(StatusCodes.Status502BadGateway)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddUsuario(Usuario Usuario)
        {
            if (Usuario == null) return BadRequest();
            try
            {
                _UsuarioRepository.Add(Usuario);
            }
            catch (Exception)
            {
                return NoContent();
            }
            return Ok(Usuario);
        }


        [AcceptVerbs("PUT")]
        [Route("Update")]
        public IActionResult UpdateUsuario(Usuario Usuario)
        {
            try
            {
                _UsuarioRepository.Update(Usuario);
            }
            catch (Exception e)
            {
                return NoContent();
            }

            return Ok(Usuario);
        }



        [AcceptVerbs("DELETE")]
        [Route("delete")]
        public IActionResult DeleteUsuario(Usuario Usuario)
        {
            try
            {
                _UsuarioRepository.Remove(Usuario);
            }
            catch (Exception e)
            {
                return NoContent();
            }

            return Ok(Usuario);
        }


        [AcceptVerbs("GET")]
        [Route("{id}")]
        public IActionResult Find(int id)
        {
            Usuario Usuario = _UsuarioRepository.Find(id);
            return Ok(Usuario);
        }



        [AcceptVerbs("GET")]
        public IActionResult FindAll()
        {
            List<Usuario> Usuarios = (List<Usuario>)_UsuarioRepository.GetAll();
            return Ok(Usuarios);
        }
    }
}