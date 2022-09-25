public class ProdutoController : Controller
    {

        //BDAlmoxarifado bd = new BDAlmoxarifado();

        public object EntityStafe { get; private set; }

        // GET: Produto
        public ActionResult Index()
        {
            // select * from produto
            return View(bd.Produto.ToList());
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
        public ActionResult Criar(string descricao, string minimo,string maximo, string estoque)
        {
            Produto novoproduto = new Produto();

            novoproduto.ProDescricao=descricao;
            novoproduto.ProMinimo = Convert.ToInt32(minimo);
            novoproduto.ProMaximo = Convert.ToInt32(maximo);
            novoproduto.ProEstoque = Convert.ToInt32(estoque);

            bd.Produto.Add(novoproduto);
            bd.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Produto prolocalizar = bd.Produto.ToList().Where(x => x.ProID == id).First();
            return View(prolocalizar);
        }

        [HttpPost]
        public ActionResult Edit(int? id,string descricao, string minimo, string maximo, string estoque)
        {
            Produto proatualizar = bd.Produto.ToList().Where(x => x.ProID == id).First();
            proatualizar.ProDescricao = descricao;
            proatualizar.ProMinimo = Convert.ToInt32(minimo);
            proatualizar.ProMaximo = Convert.ToInt32(maximo);
            proatualizar.ProEstoque = Convert.ToInt32(estoque);

            bd.Entry(proatualizar).State = EntityState.Modified;

            bd.SaveChanges();
            return RedirectToAction("Index");
         
        }


        [HttpGet]
        public ActionResult Deletar(int? id)
        {
            Produto proDeletar = bd.Produto.ToList().Where(x => x.ProID == id).First();
            return View(proDeletar);
        }

        [HttpPost]
        public ActionResult ConfirmeDelete(int? id)
        {
            Produto proDeletar = bd.Produto.ToList().Where(x => x.ProID == id).First();
            bd.Produto.Remove(proDeletar);
            try
            {
                bd.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Erro");
            }


            

            
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Exibir(int? id)
        {

            Produto proExibir = bd.Produto.ToList().Where(x => x.ProID == id).First();
            return View(proExibir); 
        }

       
    }