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
                            Title = "NOVA CONTA - CONTROLE FINANCEIRO SON";
                            Uteis.MontaHeader("CADASTRANDO UMA NOVA CONTA");

                            Clear();

                            Write("Informe uma descrição para a conta: ");
                            string descricao = ReadLine();

                            Write("Informe o valor: ");
                            double valor = Convert.ToDouble(ReadLine());

                            Write("Informe o tipo(R para receber P para pagar): ");
                            char tipo = Convert.ToChar(ReadLine());

                            Write("Informe a data de vencimento: ");
                            DateTime dataVencimento = DateTime.Parse(ReadLine());

                            Write("Selecione uma categoria pelo ID: \n");
                            p.categorias = p.categoria.ListarTodos();
                            table = new ConsoleTable("ID", "Nome");

                            foreach (var c in p.categorias)
                            {
                                table.AddRow(c.Id, c.Nome);
                            }
                            table.Write();

                            Write("Categoria: ");
                            int cat_id = Convert.ToInt32(ReadLine());
                            Categoria categoria_cadastro = p.categoria.GetCategoria(cat_id);

                            Conta conta = new Conta()
                            {
                                Descricao = descricao,
                                Valor = valor,
                                Tipo = tipo,
                                DataVencimento = dataVencimento,
                                Categoria = categoria_cadastro
                            };

                            p.conta.Salvar(conta);

                            BackgroundColor = ConsoleColor.DarkGreen;
                            ForegroundColor = ConsoleColor.White;
                            Uteis.MontaHeader("CONTA CADASTRADA", '+');
                            ResetColor();

                            ReadLine();
                            Clear();

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
