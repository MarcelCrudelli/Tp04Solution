using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tp04WebAPI.Data;
using Tp04WebAPI.Models;
using CalculadoraDesconto; // Utilizando a nossa DLL

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos() =>
        await _context.Produtos.ToListAsync();

    [HttpPost]
    public async Task<ActionResult<Produto>> PostProduto(Produto produto)
    {
        // Usando a funcionalidade da DLL para validar o preço
        if (!ValidadorPreco.ValidarPrecoMinimo(produto.Preco))
        {
            return BadRequest("O preço do produto deve ser maior do que zero (Validado por DLL).");
        }

        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProdutos), new { id = produto.Id }, produto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduto(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);
        if (produto == null) return NotFound();

        _context.Produtos.Remove(produto);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}