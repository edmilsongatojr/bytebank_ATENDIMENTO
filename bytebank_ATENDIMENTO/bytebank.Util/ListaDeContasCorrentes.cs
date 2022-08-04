using bytebank.Modelos.Conta;

namespace bytebank_ATENDIMENTO.bytebank.Util
{
    public class ListaDeContasCorrentes
    {
        private ContaCorrente[] _itens = null;
        private int _proximaPosicao = 0;

        public ListaDeContasCorrentes(int tamanhoInicial=5)
        {
                _itens = new ContaCorrente[tamanhoInicial];
        }

        public void Adicionar(ContaCorrente item) 
        {
            //Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");
            VerificarCapacidade(_proximaPosicao + 1);
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }
        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }
            //Console.WriteLine("Aumentando a capacidade da lista!");
            ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];

            for (int i = 0; i < _itens.Length; i++)
            {
                novoArray[i] = _itens[i];
            }
            _itens = novoArray;
        }

        public void VerificarMaiorSaldo()
        {
            for (int i = 0; i < _itens.Length; i++)
            {
                int agencia = _itens[i].Numero_agencia;
                string conta = _itens[i].Conta;
                double saldo = _itens[i].Saldo;
                Console.WriteLine($"Indice: {i} Agencia: {agencia} Conta: {conta} Saldo: R$ {saldo}" );
            }
            Console.WriteLine("---------------------------------------------------------------------------");
            double[] listaSaldo = new double[_proximaPosicao];
            string[] listaConta = new string[_proximaPosicao];
            for (int i = 0; i < +_itens.Length; i++)
            {
                double saldo = _itens[i].Saldo;
                string conta = _itens[i].Conta;

                listaSaldo[i] = saldo;
                listaConta[i] = conta;
            }
            double[] saldoOrdenado = (double[])listaSaldo.Clone();
            Array.Sort(saldoOrdenado,listaConta);
            Console.WriteLine("---------------------------------------------------------------------------");

            Console.WriteLine($"A conta com o maior Saldo é a conta: {listaConta.Last()}, seu Saldo atual é de R$ {saldoOrdenado.Last()}");
     
        }
    }
}
