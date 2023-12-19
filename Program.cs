// See https://aka.ms/new-console-template for more information

using Hotel.Models;
using System.Text;
using static System.Int32;

Console.OutputEncoding = Encoding.UTF8;

int opcao = 0;
List<Pessoa> hospedes = new List<Pessoa>();
List<Suite> suites = new List<Suite>();
List<Reserva> reservas = new List<Reserva>();

while (opcao != 7)
{
    Console.WriteLine("***____Sistema de Hotel____***");
    Console.WriteLine("***____Escolha uma opção___***");
    Console.WriteLine("*** 1 - Cadastrar Hóspedes ***");
    Console.WriteLine("*** 2 - Listar Hóspedes    ***");
    Console.WriteLine("*** 3 - Cadastrar Suite    ***");
    Console.WriteLine("*** 4 - Listar Suites      ***");
    Console.WriteLine("*** 5 - Fazer Reserva      ***");
    Console.WriteLine("*** 6 - Listar Reservas    ***");
    Console.WriteLine("*** 7 - Sair do Sistema    ***");
    opcao = Parse(Console.ReadLine());
    Console.WriteLine("");
    switch (opcao)
    {
        case 1:
            Console.WriteLine("Quantos hóspedes deseja cadastrar?");
            int quantidade = Parse(Console.ReadLine());
            for (int i = 0; i < quantidade; i++)
            {
                Console.WriteLine("Digite o nome do hóspede: ");
                string nome = Console.ReadLine();
                Console.WriteLine("Digite o sobrenome do hóspede: ");
                string sobrenome = Console.ReadLine();
                Pessoa p = new Pessoa(nome: nome, sobrenome: sobrenome);
                hospedes.Add(p);
            }
            Console.ReadKey();
            break;
        case 2:
            Console.WriteLine("*** Hóspedes Cadastrados ***");
            foreach (var item in hospedes)
            {
                Console.WriteLine($"Nome: {item.NomeCompleto}");
            }
            Console.ReadKey();
            break;
        case 3:
            Console.WriteLine("Digite o tipo do suíte: ");
            string tipo = Console.ReadLine();
            Console.WriteLine("Digite a capacidade: ");
            int capacidade = Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor da diária: ");
            decimal valorDiaria = Decimal.Parse(Console.ReadLine());
            Suite s = new Suite(tipo, capacidade, valorDiaria);
            suites.Add(s);
            Console.ReadKey();
            break;
        case 4:
            Console.WriteLine("*** Suítes Cadastradas ***");
            foreach (var suite in suites)
            {
                Console.WriteLine($"Tipo: {suite.TipoSuite} | Capacidade: {suite.Capacidade} | Valor Diária: R$ {suite.ValorDiaria}");
            }
            Console.ReadKey();
            break;
        case 5:
            Console.WriteLine("*** Fazer Reserva ***");
            Console.WriteLine("Quantos hóspede para reserva?");
            int quantidadeHospedeReserva = Parse(Console.ReadLine());
            List<Pessoa> hospedesParaReserva = new List<Pessoa>();

            try
            {
                Console.WriteLine("Digite os nomes dos hóspedes que estão cadastrados!");
                for (int i = 0; i < quantidadeHospedeReserva; i++)
                {
                    Console.WriteLine("Nome Completo: ");
                    string nomeCompleto = Console.ReadLine();

                    Pessoa pessoaFounded = hospedes.Find(p => p.NomeCompleto == nomeCompleto.ToUpper());

                    if (pessoaFounded == null) throw new Exception("Não existe hóspede cadastrado !!!");
                    else
                        hospedesParaReserva.Add(pessoaFounded);
                }
                Console.WriteLine("Agora escolha a suíte");
                foreach (var suite in suites)
                {
                    Console.WriteLine($"Tipo: {suite.TipoSuite} | Capacidade: {suite.Capacidade} | Valor Diária: R$ {suite.ValorDiaria}");
                }
                Console.WriteLine("Digite o tipo da suíte: ");
                string tipoSuiteParaReserva = Console.ReadLine();
                Suite suiteFounded = suites.Find(s => s.TipoSuite.ToUpper() == tipoSuiteParaReserva.ToUpper());

                if (suiteFounded == null) throw new Exception("Não existe súite cadastrada !!!");
                else
                {
                    Console.WriteLine("Digite quantos dias de reserva: ");
                    int quantidadeDiasReserva = Parse(Console.ReadLine());
                    Reserva reserva = new Reserva(quantidadeDiasReserva);
                    reserva.CadastrarSuite(suiteFounded);
                    reserva.CadastrarHospedes(hospedesParaReserva);
                    reservas.Add(reserva);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            Console.ReadKey();
            break;
        case 6:
            foreach (var res in reservas)
            {
                Console.WriteLine($"Hóspedes: {res.ObterQuantidadeHospedes()} | Dias: {res.DiasReservados} | Valor da Diária: R${res.CalcularValorDiaria()}");
            }
            break;
        default:
            break;
    }
}



