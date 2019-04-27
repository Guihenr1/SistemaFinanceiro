using System;
using static System.Console;

namespace SistemaFinanceiro
{
    class Program
    {
        static void Main(string[] args)
        {
            int opc;

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
                            WriteLine("Listar");
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

            ReadLine();
        }
    }
}
