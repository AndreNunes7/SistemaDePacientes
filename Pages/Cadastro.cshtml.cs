using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

public class CadastroModel : PageModel
{
    
    
    private GerenciadorPacientes gerenciador;

    public List<Pacientes> Pacientes { get; set; }

    public CadastroModel()
    {
        gerenciador = new GerenciadorPacientes();
        Pacientes = gerenciador.ObterTodosPacientes();
    }

    public void OnGet()
    {
        Pacientes = gerenciador.ObterTodosPacientes();
    }





    public IActionResult OnPost(int chave, string nomeDoMedico, DateTime dataInternacao, string telefoneContato)
    {
        if (ModelState.IsValid)
        {
            var novoPaciente = new Pacientes
            {
                Chave = chave,
                NomeDoMedico = nomeDoMedico,
                DataInternacao = dataInternacao,
                TelefoneContato = telefoneContato
            };

            gerenciador.AdicionarPaciente(novoPaciente);
            return RedirectToPage();
        }

        return Page();
    }



    public IActionResult OnGetBuscar(int chave)
    {
        var paciente = gerenciador.BuscarPaciente(chave);
        if (paciente != null)
        {
            return new JsonResult(new { success = true, paciente });
        }

        return new JsonResult(new { success = false, message = "Paciente não encontrado." });
    }




    public IActionResult OnPostDelete([FromBody] DeleteRequest request)
    {
        if (request == null || request.chave == 0)
        {
            return new JsonResult(new { success = false, message = "Chave inválida." });
        }

        var paciente = gerenciador.BuscarPaciente(request.chave);
        if (paciente != null)
        {
            gerenciador.RemoverPaciente(paciente);
            return new JsonResult(new { success = true, message = "Paciente deletado com sucesso." });
        }

        return new JsonResult(new { success = false, message = "Paciente não encontrado." });
    }




    public IActionResult OnGetTodosPacientes()
    {
        var todosPacientes = gerenciador.ObterTodosPacientes();
        return new JsonResult(new { success = true, pacientes = todosPacientes });
    }






    public IActionResult OnPostEditar([FromBody] Pacientes pacienteEditado)
    {
        if (pacienteEditado == null || pacienteEditado.Chave == 0)
        {
            return new JsonResult(new { success = false, message = "Dados inválidos." });
        }

        try
        {
            gerenciador.EditarPaciente(pacienteEditado);
            return new JsonResult(new { success = true, message = "Paciente editado com sucesso." });
        }
        catch (Exception ex)
        {
            return new JsonResult(new { success = false, message = ex.Message });
        }
    }




    public class DeleteRequest
    {
        public int chave { get; set; }
    }
}