﻿using System;
using System.Data.SqlClient;
using CategoriaModel = Modelo.Categoria;

namespace Persistencia
{
    public class CategoriaDAL
    {
        private SqlConnection conn;

        public CategoriaDAL(SqlConnection conn)
        {
            this.conn = conn;
        }

        public CategoriaModel GetCategoria(int id)
        {
            CategoriaModel categoria = new CategoriaModel();
            var command = new SqlCommand("select id, nome from categorias where id = @id", this.conn);
            command.Parameters.AddWithValue("@id", id);
            this.conn.Open();

            using (SqlDataReader rd = command.ExecuteReader())
            {
                rd.Read();
                categoria.Id = Convert.ToInt32(rd["id"].ToString());
                categoria.Nome = rd["nome"].ToString();
            }

            this.conn.Close();
            return categoria;
        }
    }
}
