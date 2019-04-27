using System;

namespace Db
{
    public class Conexao
    {
        private static readonly string server = "DESKTOP-22IAHQV\\SQLEXPRESS";
        private static readonly string database = "SoN_Financeiro";

        public static string GetStringConnection() => $"Server={server};Database={database};";
    }
}
