using JD_BebidasProjeto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JD_BebidasProjeto.Controllers
{
    public class CategoriasController : Controller
    {

        BDJDBEBIDAS bd = new BDJDBEBIDAS();

        public object EntityStafe { get; private set; }

        // GET: Produto
        public ActionResult Index()
        {
            // select * from produto
            return View(bd.CATEGORIA.ToList());
        }
        // GET: Criar
        public ActionResult Criar()
        {
            return View();
        }
        public ActionResult Erro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(string descricao)
        {
            CATEGORIA novacategoria = new CATEGORIA();

            novacategoria.CATDESCRICAO = descricao;


            bd.CATEGORIA.Add(novacategoria);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Editar(int? id)
        {
            CATEGORIA catlocalizar = bd.CATEGORIA.ToList().Where(x => x.CATID == id).First();
            return View(catlocalizar);
        }

        [HttpPost]
        public ActionResult Editar(int? id, string descricao)
        {
            CATEGORIA catatualizar = bd.CATEGORIA.ToList().Where(x => x.CATID == id).First();
            catatualizar.CATDESCRICAO = descricao;


            bd.Entry(catatualizar).State = EntityState.Modified;

            bd.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult Deletar(int? id)
        {
            CATEGORIA catDeletar = bd.CATEGORIA.ToList().Where(x => x.CATID == id).First();
            return View(catDeletar);
        }

        [HttpPost]
        public ActionResult ConfirmeDelete(int? id)
        {
            CATEGORIA catDeletar = bd.CATEGORIA.ToList().Where(x => x.CATID == id).First();
            bd.CATEGORIA.Remove(catDeletar);
            try
            {
                bd.SaveChanges();
            }
            catch
            {
                return RedirectToAction("/Home/Erro");
            }





            return RedirectToAction("Index");
        }




    }
}