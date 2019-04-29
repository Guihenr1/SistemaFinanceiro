using Modelo;
using Persistencia;
using System;
using System.Collections.Generic;
using static System.Console;
using System.Data.SqlClient;
using ConsoleTables;

namespace SistemaFinanceiro
{
    class Program
    {
        private List<Conta> contas;
        private List<Categoria> categorias;

        private ContaDAL conta;
        private CategoriaDAL categoria;

        public Program()
        {
            string strConn = Db.Conexao.GetStringConnection();
            this.conta = new ContaDAL(new SqlConnection(strConn));
            this.categoria = new CategoriaDAL(new SqlConnection(strConn));
        }

        static void Main(string[] args)
        {
            int opc;

            Program p = new Program();

            do
            {
                Title = "CONTROLE FINANCEIRO";
                Uteis.MontaMenu();
                opc = Convert.ToInt32(ReadLine());

                if(!(opc >= 1 && opc <= 6))
                {
                    Clear();
                    BackgroundColor = ConsoleColor.Red;
                    ForegroundColor = ConsoleColor.White;
                    Uteis.MontaHeader("INFORME UMA OPÇÃO VÁLIDA", 'X');
                    ResetColor();
                }
                else
                {
                    switch (opc)
                    {
                        case 1:
                            Title = "LISTAGEM DE CONTAS - CONTROLE FINANCEIRO SON";
                            Uteis.MontaHeader("LISTAGEM DE CONTAS");

                            p.contas = p.conta.ListarTodos();
                            ConsoleTable table = new ConsoleTable("ID", "Descrição", "Tipo", "Valor");

                            foreach(var c in p.contas)
                            {
                                table.AddRow(c.Id, c.Descricao, c.Tipo.Equals('R') ? "Receber" : "Pagar", String.Format("{0:c}", c.Valor));
                            }
                            table.Write();
                            ReadLine();
                            Clear();

                            break;
                        case 2:
                            WriteLine("Cadastrar");
                            break;
                        case 3:
                            WriteLine("Editar");
                            break;
                        case 4:
                            WriteLine("Excluir");
                            break;
                        case 5:
                            WriteLine("Relatório");
                            break;
                    }
                }

            } while (opc != 6);
        }
    }
}
