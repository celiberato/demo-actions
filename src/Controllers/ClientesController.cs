using Microsoft.AspNetCore.Mvc;

namespace CadCli.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{

    private static List<Cliente> dados = new List<Cliente> {

        new Cliente{Id=1, Nome= "Fabiano Nalin", Idade = 43, Sexo = "Masculino"},
        new Cliente{Id=2, Nome= "Priscila Mitui", Idade = 44, Sexo = "Feminino"},
        new Cliente{Id=3, Nome= "Raphael Akyu", Idade = 23, Sexo = "Masculino"},
        new Cliente {Id=4, Nome= "Nair Goes", Idade = 83, Sexo = "Feminino"},
    };

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(dados);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var cliente = dados.FirstOrDefault(x => x.Id == id);
        if (cliente is null) return NotFound();

        return Ok(cliente);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Cliente model)
    {
        var id = dados.LastOrDefault().Id + 1;
        model.Id = id;
        dados.Add(model);
        return Ok(model);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Cliente model)
    {
        var cliente = dados.FirstOrDefault(x => x.Id == id);
        cliente.Nome = model.Nome;
        cliente.Idade = model.Idade;
        cliente.Sexo = model.Sexo;
        return NoContent();
    }
}

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Sexo { get; set; }
}
