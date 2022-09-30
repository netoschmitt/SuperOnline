using System.Threading.Tasks;
using SuperOnline.Data;
using SuperOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;

namespace SuperOnline.Pages.ClienteCRUD
{
    [Authorize(Policy = "isAdmin")]
    public class IncluirModel : PageModel
    {

        [BindProperty]
        public Cliente Cliente { get; set; }

        private readonly SuperOnlineContext _context;

        public IncluirModel(SuperOnlineContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var cliente = new Cliente();
            cliente.Endereco = new Endereco();
            //novos clientes sempre iniciam com essa situação
            cliente.Situacao = Cliente.SituacaoCliente.Cadastrado;

            if (await TryUpdateModelAsync(cliente, Cliente.GetType(), nameof(Cliente)))
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Listar");
            }
            
            return Page();
        }

    }
}