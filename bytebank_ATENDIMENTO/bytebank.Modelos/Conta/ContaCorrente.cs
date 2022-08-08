﻿namespace bytebank.Modelos.Conta
{
	public class ContaCorrente : IComparable<ContaCorrente>
	{
		private int _numero_agencia;

		private string _conta;

		private double saldo;
        private string v;

        public Cliente Titular { get; set; }

		public string Nome_Agencia { get; set; }

		public int Numero_agencia
		{
			get
			{
				return _numero_agencia;
			}
			set
			{
				if (value > 0)
				{
					_numero_agencia = value;
				}
			}
		}

		public string Conta
		{
			get
			{
				return _conta;
			}
			set
			{
				if (value != null)
				{
					_conta = value;
				}
			}
		}

		public double Saldo
		{
			get
			{
				return saldo;
			}
			set
			{
				if (!(value < 0.0))
				{
					saldo = value;
				}
			}
		}

		public static int TotalDeContasCriadas { get; set; }

		public bool Sacar(double valor)
		{
			if (saldo < valor)
			{
				return false;
			}
			if (valor < 0.0)
			{
				return false;
			}
			saldo -= valor;
			return true;
		}

		public void Depositar(double valor)
		{
			if (!(valor < 0.0))
			{
				saldo += valor;
			}
		}

		public bool Transferir(double valor, ContaCorrente destino)
		{
			if (saldo < valor)
			{
				return false;
			}
			if (valor < 0.0)
			{
				return false;
			}
			saldo -= valor;
			destino.saldo += valor;
			return true;
		}

		public ContaCorrente(int numero_agencia)
		{
			Numero_agencia = numero_agencia;
			Conta = Guid.NewGuid().ToString().Substring(0, 8);
			Titular = new Cliente();
			TotalDeContasCriadas++;
		}

		public ContaCorrente(int numero_agencia, string conta) : this(numero_agencia) 
        {
			Numero_agencia = numero_agencia;
			Conta = conta;
			Titular = new Cliente();
			TotalDeContasCriadas++;
		
	    }

		public ContaCorrente(int numero_agencia, string conta, double saldo)
		{
			Numero_agencia = numero_agencia;
			Conta = conta;
			Saldo = saldo;
		}
		public override string ToString()
		{

			return $" === DADOS DA CONTA === \n" +
				   $"Número da Conta : {this.Conta} \n" +
				   $"Titular da Conta: {this.Titular.Nome} \n" +
				   $"CPF do Titular  : {this.Titular.Cpf} \n" +
				   $"Profissão do Titular: { this.Titular.Profissao}";
		}

		//O ? ABAIXO SIGNIFICA QUE PODE RECEBER UM OBJETO NULL
        public int CompareTo(ContaCorrente? outro)
        {
			if (outro == null)
			{
				return 1;	
            }
            else
            {
				return this.Numero_agencia.CompareTo(outro.Numero_agencia);
            }
        }
    }

}