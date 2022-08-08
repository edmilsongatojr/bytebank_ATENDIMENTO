using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;
using bytebank_ATENDIMENTO.bytebank.Util;
using System.Collections;
using System.Xml.Linq;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

#region Exemplos Arrays em C#
//TestaArrayInt();
//TestaBuscarPalavra();

void TestaArrayInt()
{
    int[] idades = new int[5];

    idades[0] = 100;
    idades[1] = 40;
    idades[2] = 17;
    idades[3] = 21;
    idades[4] = 18;

    Console.WriteLine($"Tamanho ARRAY: {idades.Length}");

    int acumulador = 0;


    for (int i = 0; i < idades.Length; i++)
    {
        int idade = idades[i];
        Console.WriteLine($"Indice [{i}] = {idade} ");
        acumulador += idade;
    }

    int media = acumulador / idades.Length;
    Console.WriteLine($"Media de idades = {media}");
}

void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];


    for (int i = 0; i < arrayDePalavras.Length; i++)
    {
        Console.Write($"Digite {i + 1}ª Palavra:");
        arrayDePalavras[i] = Console.ReadLine();
    }

    Console.Write("Digite palavra a ser encontrada:");
    var busca = Console.ReadLine();

    foreach (string palavra in arrayDePalavras)
    {

        if (palavra.Equals(busca))
        {
            Console.WriteLine($"Palavra Encontrada: {busca}");
            break;
        }

    }
}

Array amostra = Array.CreateInstance(typeof(double), 5);

amostra.SetValue(5.9, 0);
amostra.SetValue(1.8, 1);
amostra.SetValue(7.1, 2);
amostra.SetValue(10, 3);
amostra.SetValue(2.35, 4);

//[5,9] [1,8] [7,1] [10] [6,9]

//TestaMediana(amostra);

void TestaMediana(Array array)
{

    if ((array == null) || (array.Length == 0))
    {
        Console.WriteLine($"Array para cálculo da mediana está vazio ou nulo");
    }

    double[] numerosOrdenados = (double[])array.Clone();
    Array.Sort(numerosOrdenados);

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;

    double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] : (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2;

    Console.WriteLine($"Com base na amostra a mediana = {mediana}");
}

//TestaArrayDeContasCorrentes();

void TestaArrayDeContasCorrentes()
{
    //int[] valores = new int[] { 1, 2, 3, 5 };

    ListaDeContasCorrentes listaDeContas = new();
    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
    listaDeContas.Adicionar(new ContaCorrente(874, "4456668-B"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-D"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-E"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-F"));

}

//TestaArraydeContasCorrentesComSaldo();

void TestaArraydeContasCorrentesComSaldo()
{
    ListaDeContasCorrentes listaDeContas = new();
    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A", 5900.30));
    listaDeContas.Adicionar(new ContaCorrente(874, "4456668-B", 700.12));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C", 1300.99));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-D", 2365.00));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-E", 935));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-F", 1365.45));
    ContaCorrente contaJoao = new ContaCorrente(354, "659452-G", 356);
    listaDeContas.Adicionar(contaJoao);

    //Desafio: método que retorna a conta com maior saldo: INICIO
    //listaDeContas.VerificarMaiorSaldo();
    //Desafio: método que retorna a conta com maior saldo: FIM


    //listaDeContas.ExibirLista();
    //Console.WriteLine();
    //listaDeContas.Remover(contaJoao);
    //Console.WriteLine();
    //listaDeContas.ExibirLista();


    for (int i = 0; i < listaDeContas.Tamanho; i++)
    {
        ContaCorrente conta = listaDeContas[i];
        Console.WriteLine($"Indice: [{i}] | Conta: {conta.Numero_agencia}/{conta.Conta}");
    }

}

#endregion

List<ContaCorrente> _listaDecContas = new List<ContaCorrente>()
{
    new ContaCorrente(74, "5679787-A"){Saldo=524},
    new ContaCorrente(87, "4456668-B"){Saldo=8211},
    new ContaCorrente(84, "7781438-C"){Saldo=34512},
    new ContaCorrente(874, "7781438-D"){Saldo=75},
    new ContaCorrente(8, "7781438-E"){Saldo=423},
    new ContaCorrente(4, "7781438-F"){Saldo=7523}
};

AtendimentoCliente();

void AtendimentoCliente()
{
    try
    {
        char opcao = '0';
        while (opcao != '6')
        {
            Console.Clear();
            Console.WriteLine("=======================================================");
            Console.WriteLine("===                  Atendimento                    ===");
            Console.WriteLine("===                                                 ===");
            Console.WriteLine("=== 1 - Cadastrar Nova Conta                        ===");
            Console.WriteLine("=== 2 - Listar Contas                               ===");
            Console.WriteLine("=== 3 - Remover Conta                               ===");
            Console.WriteLine("=== 4 - Ordenar Contas                              ===");
            Console.WriteLine("=== 5 - Pesquisar Conta                             ===");
            Console.WriteLine("=== 6 - Sair do Sistema                             ===");
            Console.WriteLine("===                                                 ===");
            Console.WriteLine("=======================================================");
            Console.WriteLine("\n\n");
            Console.Write("Selecione a opção desejada: ");
            try
            {
                opcao = Console.ReadLine()[0];
            }
            catch (Exception exececao)
            {
                throw new ByteBankException(exececao.Message);  
            }
            switch (opcao)
            {
                case '1':
                    CadastrarConta();
                    break;
                case '2':
                    ListarContas();
                    break;
                case '3':  RemoverContas();
                    break;
                case '4': OrdenarContas();
                    break;
                case '5': PesquisarConta();
                    break;
                case '6':
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Opcao não implementada. Selecione as opção de 1 à 6!");
                    break;
            }
        }
    }
    catch (ByteBankException excecao)
    {
        Console.WriteLine($"{excecao.Message}");
    }
    
}


void CadastrarConta()
{
    Console.Clear();
    Console.WriteLine("=======================================================");
    Console.WriteLine("===              CADASTRO DE CLIENTES               ===");
    Console.WriteLine("===                                                 ===");
    Console.WriteLine("===            Informe os dados da conta            ===");
    Console.WriteLine("=======================================================");
    Console.Write("Agencia: ");
    int numeroAgencia = int.Parse(Console.ReadLine());
    Console.Write("Conta: ");
    string numeroConta = Console.ReadLine();

    ContaCorrente conta = new ContaCorrente(numeroAgencia, numeroConta);

    Console.Write("Saldo Inicial: ");
    conta.Saldo = double.Parse(Console.ReadLine());
    Console.Write("Titular: ");
    conta.Titular.Nome = Console.ReadLine();
    Console.Write("CPF: ");
    conta.Titular.Cpf = Console.ReadLine();
    Console.Write("Profissão: ");
    conta.Titular.Profissao = Console.ReadLine();
    _listaDecContas.Add(conta);

    Console.WriteLine("Conta cadastrada com sucesso!");
    Console.ReadKey();
}

void ListarContas()
{
    Console.Clear();
    Console.WriteLine("=======================================================");
    Console.WriteLine("===                 LISTA DE CONTAS                 ===");
    Console.WriteLine("=======================================================");
    Console.WriteLine("\n");
    if (_listaDecContas.Count <= 0)
    {
        Console.WriteLine("ATENÇÃO! | Não existe nenhuma conta cadastrada para ser listada!");
        Console.ReadKey();
        return;
    }
    foreach (ContaCorrente item in _listaDecContas)
    {
        Console.WriteLine("=======================================================");
        Console.WriteLine("===                 Dados da Conta                  ===");
        Console.WriteLine($"Número da Conta:  {item.Conta}");
        Console.WriteLine($"Saldo da Conta:  {item.Saldo}");
        Console.WriteLine($"Titutar da Conta: {item.Titular.Nome}");
        Console.WriteLine($"CPF do Titular:   {item.Titular.Cpf}");
        Console.WriteLine($"Profissão do Titular:   {item.Titular.Profissao}");
        Console.WriteLine("=======================================================");
        Console.WriteLine("\n");
        Console.ReadKey();
    }
}

void RemoverContas()
{
    Console.Clear();
    Console.WriteLine("=======================================================");
    Console.WriteLine("===                 REMOVER  CONTAS                 ===");
    Console.WriteLine("=======================================================");
    Console.WriteLine("\n");
    Console.Write("Informe o número da Conta: ");
    string numeroConta = Console.ReadLine();
    ContaCorrente conta = null;
    foreach (var item in _listaDecContas)
    {
        if (item.Conta.Equals(numeroConta))
        {
            conta = item;
        }
    }

    if (conta!=null)
    {
        _listaDecContas.Remove(conta);
        Console.WriteLine($"A conta \n {conta} \n foi removida com sucesso!");
    }
    else
    {
        Console.WriteLine($"A conta \n {conta} \n não foi encontrada para remoção!!");
    }
    Console.ReadKey();
}

void OrdenarContas()
{
    _listaDecContas.Sort();
    Console.WriteLine("... A lista de contas foi ordenada com sucesso!...");
    Console.ReadKey();
}

void PesquisarConta()
{
   
}
