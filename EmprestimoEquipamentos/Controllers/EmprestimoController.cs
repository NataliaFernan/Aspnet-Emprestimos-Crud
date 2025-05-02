using EmprestimoEquipamentos.Data;
using EmprestimoEquipamentos.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoEquipamentos.Controllers
{
    public class EmprestimoController : Controller
    {

        readonly private AplicationDbContext _db;


        public EmprestimoController(AplicationDbContext db)
        {
             _db = db;
        }

        public IActionResult Index()
        {

            IEnumerable<EmprestimoModel> emprestimos = _db.Emprestimos;


            return View(emprestimos);
        }

        [HttpGet]
        public IActionResult Cadastrar() { 
        
            return View();
        
        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimoModel emprestimo)
        {
            if (ModelState.IsValid) { 
            
                _db.Emprestimos.Add(emprestimo);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

                return RedirectToAction("Index");
            
            }
            return View();

        }

        [HttpGet]
        public IActionResult Editar(int? id) 
        {

            if (id == null || id == 0) 
            { 
            return NotFound();
            
            }

            EmprestimoModel emprestimo =  _db.Emprestimos.FirstOrDefault(x => x.Id == id);


            if (emprestimo == null) 
            {

                return NotFound();
            
            }



            return View(emprestimo);
        
        }

        [HttpPost]
        public IActionResult Editar(EmprestimoModel emprestimo) 
        {

            if (ModelState.IsValid) 
            { 
            
            _db.Emprestimos.Update(emprestimo);
            _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro editado com sucesso!";

                return RedirectToAction("Index");
            
            }
            return View(emprestimo);
        
        
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();

            }

            EmprestimoModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);

            if(emprestimo == null)
            {  
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Excluir(EmprestimoModel emprestimo) 
        {
            if (emprestimo == null) 
            {
                return NotFound();
            
            }

            _db.Emprestimos.Remove(emprestimo);
            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Exclusão realizada com sucesso!";

            return RedirectToAction("Index");
        
        }
    }
}
