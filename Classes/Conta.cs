using System;

namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        public double Saldo { get; set; }
        public double LimiteCredito { get; set; }
        public string NomeCliente { get; set; }


        public Conta(TipoConta tipoConta, double saldo, double limiteCredito, string nomeCliente)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.LimiteCredito = limiteCredito;
            this.NomeCliente = nomeCliente;
        }

        public bool Sacar(double valorSaque)
        {
            if (valorSaque > (this.Saldo + this.LimiteCredito))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine($"Saldo atual da conta de {this.NomeCliente} é de R$ {this.Saldo}");
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine($"Saldo atual da conta de {this.NomeCliente} é de R$ {this.Saldo}");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            return $"TipoConta: {this.TipoConta} | Cliente: {this.NomeCliente} | Saldo: R$ {this.Saldo} | Limite de Crédito: R$ {this.LimiteCredito}";
        }

    }
}