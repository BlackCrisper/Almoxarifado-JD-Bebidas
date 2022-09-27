using JD_BebidasProjeto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JD_BebidasProjeto.Controllers
{
    public class ProdutoController : Controller
    {

        BDJDBEBIDAS bd = new BDJDBEBIDAS();

        public object EntityStafe { get; private set; }

        // GET: Produto
        public ActionResult Index()
        {
            // select * from produto
            return View(bd.PRODUTO.ToList());
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
            PRODUTO novoproduto = new PRODUTO();

            novoproduto.PRODESCRICAO = descricao;
       

            bd.PRODUTO.Add(novoproduto);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Editar(int? id)
        {
            PRODUTO prolocalizar = bd.PRODUTO.ToList().Where(x => x.PROID == id).First();
            return View(prolocalizar);
        }

        [HttpPost]
        public ActionResult Editar(int? id, string descricao)
        {
            PRODUTO proatualizar = bd.PRODUTO.ToList().Where(x => x.PROID == id).First();
            proatualizar.PRODESCRICAO = descricao;


            bd.Entry(proatualizar).State = EntityState.Modified;

            bd.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult Deletar(int? id)
        {
            PRODUTO proDeletar = bd.PRODUTO.ToList().Where(x => x.PROID == id).First();
            return View(proDeletar);
        }

        [HttpPost]
        public ActionResult ConfirmeDelete(int? id)
        {
            PRODUTO proDeletar = bd.PRODUTO.ToList().Where(x => x.PROID == id).First();
            bd.PRODUTO.Remove(proDeletar);
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