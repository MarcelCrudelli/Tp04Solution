namespace CalculadoraDesconto;

public static class ValidadorPreco
{
    public static bool ValidarPrecoMinimo(decimal preco)
    {
        // Exemplo de regra da DLL: o preço deve ser maior que zero
        return preco > 0;
    }
}