using Microsoft.AspNetCore.Mvc;

namespace FuncionarioMVC;

public class FuncionariosController : Controller
{
    private readonly FuncionarioService _funcionarioService;

    public FuncionariosController()
    {
        _funcionarioService = new FuncionarioService();
    }

    public IActionResult Index()
    {
        var funcionarios = _funcionarioService.Listar();


        return View(funcionarios);
    }

    public IActionResult Editar(int id)
    {
        Funcionario funcionario = _funcionarioService.BuscarParaEditar(id);

        return View("Cadastrar",funcionario);
    }
    
    public IActionResult Cadastrar()
    {
        return View("Cadastrar");
    }

    
    [HttpPost]
    public IActionResult Salvar(Funcionario funcionario) 
    {
        _funcionarioService.Salvar(funcionario);
        
        return RedirectToAction("Index");
    }

    public IActionResult Excluir(int id)
    {
        _funcionarioService.Excluir(id);

        return RedirectToAction("Index");
    }
}