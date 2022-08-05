using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Util;
using System.Xml.Linq;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

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
        Console.Write($"Digite {i+1}ª Palavra:");
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



Array amostra = Array.CreateInstance(typeof(double),5);

amostra.SetValue(5.9,0);
amostra.SetValue(1.8,1);
amostra.SetValue(7.1,2);
amostra.SetValue(10,3);
amostra.SetValue(2.35,4);

//[5,9] [1,8] [7,1] [10] [6,9]

//TestaMediana(amostra);

void TestaMediana(Array array)
{

    if ((array == null) || (array.Length==0))
    {
        Console.WriteLine($"Array para cálculo da mediana está vazio ou nulo");    
    }

    double[] numerosOrdenados = (double [])array.Clone();
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

TestaArraydeContasCorrentesComSaldo();

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
