using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApi.DataBase;
using ProdutosApi.Model;
using ProdutosApi.Repositories;

namespace ProdutosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private ProdutoRepository _produtoRepository;

        public ProdutoController()
        {
            _produtoRepository = new ProdutoRepository();
        }


        [AcceptVerbs("POST")]
        [Route("Add")]
        [ProducesResponseType(StatusCodes.Status502BadGateway)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddProduto(Produto produto)
        {
            if (produto == null) return BadRequest();
            try
            {
                _produtoRepository.Add(produto);
            }
            catch (Exception)
            {
                return NoContent();
            }
            return Ok(produto);
        }


        [AcceptVerbs("PUT")]
        [Route("Update")]
        public IActionResult UpdateProduto(Produto produto)
        {
            try
            {
                _produtoRepository.Update(produto);
            }
            catch(Exception e)
            {
                return NoContent();
            }

            return Ok(produto);
        }



        [AcceptVerbs("DELETE")]
        [Route("delete")]
        public IActionResult DeleteProduto(Produto produto)
        {
            try
            {
                _produtoRepository.Remove(produto);
            }
            catch (Exception e)
            {
                return NoContent();
            }

            return Ok(produto);
        }


        [AcceptVerbs("GET")]
        [Route("{id}")]
        public IActionResult Find(int id)
        {
            Produto produto = _produtoRepository.Find(id);
            if (produto == null) return StatusCode(500);
            return Ok(produto);
        }



       [AcceptVerbs("GET")]
       public IActionResult FindAll()
       {
            List<Produto> produtos = (List<Produto>) _produtoRepository.GetAll();
            return Ok(produtos);
       }


    }
}