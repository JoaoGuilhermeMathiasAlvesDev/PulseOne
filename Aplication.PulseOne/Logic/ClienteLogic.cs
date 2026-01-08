using Aplication.PulseOne.Models.Cliente;
using Dominio.PulseOne.Entiteis;
using System.Text.RegularExpressions;

public static class ClienteLogic
{
    // Ajustado: agora valida corretamente se está vazio
    public static void ValidarNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome é obrigatório.");
    }

    public static void ValidarEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentNullException("O e-mail é obrigatório.");

        var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        if (!emailRegex.IsMatch(email))
            throw new Exception("O formato do e-mail é inválido.");
    }

    public static void ValidarTelefone(string telefone)
    {
        if (string.IsNullOrWhiteSpace(telefone))
            throw new Exception("O telefone é obrigatório.");

        var telefoneRegex = new Regex(@"^\(?\d{2}\)?\s?9?\d{4}-?\d{4}$");
        if (!telefoneRegex.IsMatch(telefone))
            throw new Exception("O formato do telefone é inválido. Use (XX) 9XXXX-XXXX.");
    }

    private static void ValidarDadosCompletos(string nome, string email, string telefone)
    {
        ValidarNome(nome);
        ValidarEmail(email);
        ValidarTelefone(telefone);
    }

    public static Cliente AdicionarDados(AdicionarCliente model)
    {
        if (model is null) throw new ArgumentNullException(nameof(model));

        ValidarDadosCompletos(model.Nome, model.Email, model.NumeroTelefone);

        return new Cliente(model.Nome, model.Email, model.NumeroTelefone);
    }

    public static void Atualizar(Cliente clienteExistente, AtualizarCliente model)
    {
        ValidarDadosCompletos(model.Nome, model.Email, model.NumeroTelefone);
        if (model.NumeroTelefone != clienteExistente.NumeroTelefone ||
            model.Nome != clienteExistente.Nome ||
            model.Email != clienteExistente.Email)
        {
            clienteExistente.DefinirCliente(model.Nome, model.Email, model.NumeroTelefone);
        }
    }

    public static ClienteModel MapearParaModel(Cliente c)
    {
        if (c is null) return null;

        return new ClienteModel
        {
            Id = c.Id,
            Nome = c.Nome,
            Email = c.Email,
            NumeroTelefone = c.NumeroTelefone,
        };
    }
}