string escolha;

do
{
    Console.WriteLine("");
    Console.WriteLine("Validador Inteligente de Dados");
    Console.WriteLine(@"Escolha uma das opções abaixo:
1 - Validar CPF
2 - Validar IP
3 - Validar Senha
0 - Sair");

    escolha = Console.ReadLine();

    switch (escolha)
    {
        case "1":
            ValidadorCPF();
            break;
        case "2":
            ValidadorIP();
            break;
        case "3":
            ValidadorSenha();
            break;
        case "0":
            Console.WriteLine("Saindo...");
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }

} while (escolha != "0");


void ValidadorCPF()
{
    Console.WriteLine("");
    Console.Write("Digite o número do CPF: ");
    string cpf = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(cpf))
    {
        Console.WriteLine("Entrada inválida!");
        return;
    }

    string cpfRe = cpf.Replace(".", "").Replace("-", "");

    if (cpfRe.Length == 11)
    {
        Console.WriteLine("CPF válido!");
    }
    else
    {
        Console.WriteLine("CPF inválido!");
    }
}

void ValidadorIP()
{
    Console.WriteLine("");
    Console.WriteLine("Exemplo de IP: 192.168.0.1");
    Console.Write("Digite um IP: ");

    string ip = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(ip))
    {
        Console.WriteLine("Entrada inválida!");
        return;
    }

    string[] partes = ip.Split(".");

    if (partes.Length != 4)
    {
        Console.WriteLine("IP inválido!");
        return;
    }

    foreach (string parte in partes)
    {
        if (!int.TryParse(parte, out int numero) || numero < 0 || numero > 255)
        {
            Console.WriteLine("IP inválido!");
            return;
        }

        // bloqueia valores tipo 01, 002
        if (parte.Length > 1 && parte.StartsWith("0"))
        {
            Console.WriteLine("IP inválido!");
            return;
        }
    }

    Console.WriteLine("IP válido!");
}

void ValidadorSenha()
{
    Console.WriteLine("");
    Console.WriteLine(@"Regras da senha:
- Mínimo 9 caracteres
- Deve conter número
- Deve conter caractere especial");

    Console.Write("Digite sua senha: ");
    string senha = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(senha))
    {
        Console.WriteLine("Entrada inválida!");
        return;
    }

    bool temNumero = false;
    bool temEspecial = false;

    foreach (char c in senha)
    {
        if (char.IsDigit(c))
            temNumero = true;

        if (!char.IsLetterOrDigit(c))
            temEspecial = true;
    }

    if (senha.Length >= 9 && temNumero && temEspecial)
    {
        Console.WriteLine("Senha válida!");
    }
    else
    {
        Console.WriteLine("Senha inválida!");
    }
}