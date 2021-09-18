using System;

namespace AppBank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo {get; set; }
        private double Credito {get; set;}
        private string Nome {get; set; }
        
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome )
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }            

        public bool Sacar(double valorSaque) {
            // validação de saldo suficiente...
            if (this.Saldo - valorSaque < ( this.Credito * -1 )) {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            Console.WriteLine($"Conta.........: {this.Nome}");
            Console.WriteLine($"Saldo Anterior: {this.Saldo}");
            this.Saldo -= valorSaque;
            Console.WriteLine($"Valor Saque...: {valorSaque}");
            Console.WriteLine($"Saldo Atual...: {this.Saldo}");
            return true;
        }

        public void Depositar(double valorDeposito) {
            Console.WriteLine($"Conta.........: {this.Nome}");
            Console.WriteLine($"Saldo Anterior: {this.Saldo}");
            this.Saldo += valorDeposito;
            Console.WriteLine($"Valor Depósito: {valorDeposito}");
            Console.WriteLine($"Saldo Atual...: {this.Saldo}");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino) {
            if (this.Sacar(valorTransferencia)) {
                // Console.WriteLine($"Conta............: {this.Nome}");
                // Console.WriteLine($"Saldo Anterior...: {this.Saldo}");
                contaDestino.Depositar(valorTransferencia);
                // Console.WriteLine($"Valor Transferido: {valorTransferencia}");
                // Console.WriteLine($"Conta Destino....: {contaDestino.Nome}");
                // Console.WriteLine($"Saldo Atual......: {this.Saldo}");
            }
        }

        public override string ToString() {
            return "TipoConta: " + this.TipoConta + " | "             +
                   "Nome:  "     + this.Nome + " | " +
                   "Saldo: "     + this.Saldo + " | " +
                   "Crédito: "   + this.Credito;
        }

    }
}
