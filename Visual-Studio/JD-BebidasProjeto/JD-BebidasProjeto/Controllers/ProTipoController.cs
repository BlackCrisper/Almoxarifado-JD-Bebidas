using JD_BebidasProjeto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JD_BebidasProjeto.Controllers
{
    public class ProTipoController : Controller
    {
        // GET: ProTipo

        BDJDBEBIDAS bd = new BDJDBEBIDAS();
        public ActionResult Index()
        {
            return View(bd.PROTIPO.ToList());
        }

        [HttpGet]
        public ActionResult Criar()
        {
            ViewBag.listaTipo = bd.TIPO.ToList();
            ViewBag.listaProduto = bd.PRODUTO.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Criar(int produto, int tipo, string maximo, string minimo,string estoque, HttpPostedFileBase imagem)
        {
            PROTIPO novoproduto = new PROTIPO();

            novoproduto.PROID = produto;
            novoproduto.TIPID = tipo;
            novoproduto.PTMAXIMO = Convert.ToInt32(maximo);
            novoproduto.PTMINIMO = Convert.ToInt32(minimo);
            novoproduto.PTESTOQUE = Convert.ToInt32(estoque);
            using (var memoryStream = new MemoryStream())
            {
                imagem.InputStream.CopyTo(memoryStream);
                novoproduto.PTIMAGEM = memoryStream.ToArray();
            }

            bd.PROTIPO.Add(novoproduto);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Editar(int? id)
        {
            ViewBag.listaTipo = bd.TIPO.ToList();
            ViewBag.listaProduto = bd.PRODUTO.ToList();
            PROTIPO prolocalizar = bd.PROTIPO.ToList().Where(x => x.PTID == id).First();
            return View(prolocalizar);
        }

        [HttpPost]
        public ActionResult Editar(int? id, int produto, int tipo, string maximo, string minimo, string estoque)
        {
            PROTIPO proatualizar = bd.PROTIPO.ToList().Where(x => x.PTID == id).First();
            proatualizar.PROID = produto;
            proatualizar.TIPID = tipo;
            proatualizar.PTMAXIMO = Convert.ToInt32(maximo);
            proatualizar.PTMINIMO = Convert.ToInt32(minimo);
            proatualizar.PTESTOQUE = Convert.ToInt32(estoque);


            bd.Entry(proatualizar).State = EntityState.Modified;

            bd.SaveChanges();
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult Deletar(int? id)
        {
            PROTIPO proDeletar = bd.PROTIPO.ToList().Where(x => x.PTID == id).First();
            return View(proDeletar);
        }

        [HttpPost]
        public ActionResult ConfirmeDelete(int? id)
        {
            PROTIPO proDeletar = bd.PROTIPO.ToList().Where(x => x.PTID == id).First();
            bd.PROTIPO.Remove(proDeletar);
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