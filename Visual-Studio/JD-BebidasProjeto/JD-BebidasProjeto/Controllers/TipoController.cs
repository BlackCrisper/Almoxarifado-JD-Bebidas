using JD_BebidasProjeto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JD_BebidasProjeto.Controllers
{
    public class TipoController : Controller
    {

        BDJDBEBIDAS bd = new BDJDBEBIDAS();

        public object EntityStafe { get; private set; }

        // GET: Produto
        public ActionResult Index()
        {
            // select * from produto
            return View(bd.TIPO.ToList());
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
            TIPO novotipo = new TIPO();

            novotipo.TIPNOME = descricao;


            bd.TIPO.Add(novotipo);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Editar(int? id)
        {
            TIPO tipolocalizar = bd.TIPO.ToList().Where(x => x.TIPID == id).First();
            return View(tipolocalizar);
        }

        [HttpPost]
        public ActionResult Editar(int? id, string descricao)
        {
            TIPO tipoatualizar = bd.TIPO.ToList().Where(x => x.TIPID == id).First();
            tipoatualizar.TIPNOME = descricao;


            bd.Entry(tipoatualizar).State = EntityState.Modified;

            bd.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult Deletar(int? id)
        {
            TIPO tipoDeletar = bd.TIPO.ToList().Where(x => x.TIPID == id).First();
            return View(tipoDeletar);
        }

        [HttpPost]
        public ActionResult ConfirmeDelete(int? id)
        {
            TIPO tipoDeletar = bd.TIPO.ToList().Where(x => x.TIPID == id).First();
            bd.TIPO.Remove(tipoDeletar);
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