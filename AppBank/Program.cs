using System;
using System.Collections.Generic;

namespace AppBank
{ 
    class Program
    {

        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {

            Conta minhaConta = new Conta(TipoConta.PessoaFisica, 0, 0, "Jorge Rosivan");

            Console.WriteLine( minhaConta.ToString() );
            
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X") {
                switch (opcaoUsuario) {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
                 
            }

        }

        private static string ObterOpcaoUsuario() {
            Console.WriteLine();
            Console.WriteLine("┌─────────────────────────────┐");
            Console.WriteLine("│        ** APPBANK **        │");
            Console.WriteLine("├─────────────────────────────┤");
            Console.WriteLine("│     Escolha sua opção:      │");
            Console.WriteLine("│                             │");
            Console.WriteLine("│ 1 - Listar Contas           │");
            Console.WriteLine("│ 2 - Inserir Nova Conta      │");
            Console.WriteLine("│ 3 - Transferir              │");
            Console.WriteLine("│ 4 - Sacar                   │");
            Console.WriteLine("│ 5 - Depositar               │");
            Console.WriteLine("│ C - Limpar Tela             │");
            Console.WriteLine("│ X - Sair                    │");
            Console.WriteLine("└─────────────────────────────┘");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        // Inserir conta....
        private static void InserirConta() {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 = Pessoa Física, 2 = Pessoa Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            if ( (entradaTipoConta != 1) & (entradaTipoConta != 2) ) {
                Console.WriteLine("Dado incorreto!");
                return;
            }

            Console.WriteLine("Digite o nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta( tipoConta: (TipoConta)entradaTipoConta,
                                         saldo: entradaSaldo,
                                         credito: entradaCredito,
                                         nome: entradaNome );

            listContas.Add(novaConta);

        }

        // Inserir conta....
        private static void ListarContas() {
            Console.WriteLine("LISTA CONTAS");
            if (listContas.Count == 0) {
                Console.WriteLine("Nenhuma conta cadastrada!");
                return;
            }
            for (int i = 0; i < listContas.Count; i++) {
                Conta conta = listContas[i];
                Console.WriteLine($"#{i} - {conta}");  // toString...
            }

        }

        // Sacar...
        private static void Sacar() {
            Console.WriteLine("SACAR:");
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            if (indiceConta >= listContas.Count) {
                Console.WriteLine("Número da conta inválida!");
                return;
            }

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSacar = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSacar);
        }

        // Transferir...
        private static void Transferir() {
            Console.WriteLine("TRANSFERIR");
            Console.WriteLine("Digite o número da conta de Origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            if (indiceContaOrigem >= listContas.Count) {
                Console.WriteLine("Número da conta Origem inválida!");
                return;
            }

            Console.WriteLine("Digite o número da conta de Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            if ( indiceContaOrigem == indiceContaDestino | indiceContaDestino >= listContas.Count) {
                Console.WriteLine("Número da conta Destino inválida!");
                return;
            }

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);

        }

        // Depositar...
        private static void Depositar() {
            Console.WriteLine("DEPOSITAR");
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            if (indiceConta >= listContas.Count) {
                Console.WriteLine("Número da conta inválida!");
                return;
            }

            Console.WriteLine("Digite o valor a ser depostitado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

    }

}
