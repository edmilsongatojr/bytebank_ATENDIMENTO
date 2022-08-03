Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

TestaArrayInt();

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

