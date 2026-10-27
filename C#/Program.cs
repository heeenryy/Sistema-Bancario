// 1. O computador recebe os dados iniciais
using Microsoft.VisualBasic;

double valorDoSaque = 150.00;
bool caixaLigado = true;
bool segloop = true;
string comando3 = "";
bool usuarioLogado = false; // Variável para controlar se o usuário está logado ou não 
bool terloop = false;
bool quarloop = true;
string s_or_n = "";

// classe Cliente

Cliente clienteAtual = new Cliente();

// 2. Aqui começa a sua lógica de decisão!
while (caixaLigado)
{
    if (usuarioLogado == false) 
    {
        Console.WriteLine("Aperte Enter para iniciar");
        comando3 = Console.ReadLine();
        if (comando3 != "")
        {
            terloop = true;
            while (terloop)
            {
                Console.WriteLine("Comando invalido. Por favor, digite Enter para iniciar.");
                comando3 = Console.ReadLine();
                if (comando3 == "")
                {
                    terloop = false;

                }
            }
        }
    }


    if (comando3 == "") 
    {
       ProcessarSaque(clienteAtual, valorDoSaque, ref caixaLigado, ref s_or_n, ref segloop, ref quarloop, ref usuarioLogado);
    }
    else
    {
        Console.WriteLine("Comando inválido. Por favor, digite Enter para iniciar.");
    }
    while (segloop) { 
    Console.WriteLine("Digite 'sair' para encerrar o saque, 'e' para visualizar o extrato ou pressione enter para fazer outro saque.");

    string comando = Console.ReadLine();
        if (comando.ToLower() == "sair")
        {
            caixaLigado = false;
            segloop = false;
        }
        else if (comando == "") {
            segloop = false;
            usuarioLogado = true; // Define que o usuário está logado para permitir outro saque
            quarloop = true;

        }
        else if (comando.ToLower() == "e")
        {
            foreach (string nome in clienteAtual.extrato)
            {
                Console.WriteLine(nome);

            }
            Console.WriteLine("Digite 'sair' para encerrar o saque, ou pressione enter para fazer outro saque.");

            string comando2 = Console.ReadLine();

            if (comando2.ToLower() == "sair")
            {
                caixaLigado = false;
                segloop = false;
            }
            else if (comando2 == "")
            {
                segloop = false;
                usuarioLogado = true; // Define que o usuário está logado para permitir outro saque
                quarloop = true;

            }

        }

    }
}
Console.WriteLine("Obrigado por utilizar os serviços do HenryBenck!");



static void ProcessarSaque(Cliente cliente, double valorDoSaque, ref bool caixaLigado, ref string s_or_n, ref bool segloop, ref bool quarloop, ref bool usuarioLogado)
{

    if (valorDoSaque <= 0)
    {
        Console.WriteLine("Valor do saque invalido. O valor tem que ser maior que 0.");
    }
    else if (valorDoSaque > cliente.saldoNaConta)
    {
        Console.WriteLine("Saldo insuficiente.Por favor, digite 'Sair' ou saque outro valor.");
        string otrcomando = Console.ReadLine();
        if (otrcomando.ToLower() == "sair")
        {
            caixaLigado = false;
        }
    }
    else
    {
        // Se não caiu nos erros acima, o saque é válido!
        cliente.saldoNaConta -= valorDoSaque;
        cliente.extrato.Add($"Saque realizado no valor de ${valorDoSaque}. Saldo atual ate o momento desse saque é de: ${cliente.saldoNaConta}");

        Console.WriteLine("Saque realizado com sucesso!");
        Console.WriteLine($"Seu saldo agora é de ${cliente.saldoNaConta}");
        Console.WriteLine("Deseja fazer outro saque? (s/n)");
        s_or_n = Console.ReadLine();
        if (s_or_n.ToLower() == "s")
        {
            caixaLigado = true;
            quarloop = true;
            segloop = false;
            usuarioLogado = true; // Define que o usuário está logado para permitir outro saque
        }

        else if (string.IsNullOrWhiteSpace(s_or_n))
        {
            bool msg = true;
            quarloop = true;
            while (quarloop) // loop principal 
            {
                if (msg || string.IsNullOrWhiteSpace(s_or_n))
                {
                    Console.WriteLine("Você não digitou nada. Por favor, digite 's' para sim ou 'n' para não.");
                    s_or_n = Console.ReadLine();
                }

                else if (double.TryParse(s_or_n, out _))
                {
                    Console.WriteLine("Comando inválido.");
                    s_or_n = Console.ReadLine();
                }

                if (s_or_n.ToLower() == "s")
                {
                    quarloop = false;
                    segloop = false;
                    usuarioLogado = true;
                }

                else if (s_or_n.ToLower() == "n")
                {
                    quarloop = false;
                    segloop = true;
                }


                else if (s_or_n != "" || s_or_n == null)
                {
                    Console.WriteLine("Comando inválido. Por favor, digite 's' para sim ou 'n' para não.");
                    s_or_n = Console.ReadLine();
                    if (s_or_n.ToLower() == "s")
                    {
                        quarloop = false;
                        segloop = false;
                        usuarioLogado = true;
                    }
                    else if (s_or_n.ToLower() == "n")
                    {
                        quarloop = false;
                        segloop = true;
                    }
                    else if (s_or_n.ToLower() != "s" || s_or_n.ToLower() != "n")
                    {
                        msg = false;
                    }
                }

            }


        }
        else if (s_or_n.ToLower() == "n")
        {
            segloop = true;
        }

    }
    
}
class Cliente 
{
    public double saldoNaConta = 9999.00;
    public List<string> extrato = new List<string>();
}

// verifica bug 
// consertar espaco largura zero

/* atividade para proxima vez. Implementar no loop interno o valor true na variavel: usuario. E no topo do loop externo por a verificação de usuário logado (true) ou não (false) */