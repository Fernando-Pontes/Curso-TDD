using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Agenda.Domain;
using System.Configuration;
using Dapper;
using System.Linq;

namespace Agenda.DAL
{
    public class Contatos
    {
        string _strCon;
       
        public Contatos()
        {
            _strCon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        }

        public void Adicionar(Contato contato)
        {
            using (var con = new SqlConnection(_strCon))
            {
                con.Execute("insert into Contato (id, nome) values (@Id,@Nome)",contato);
            }
        }

        public Contato Obter(Guid id)
        {
            Contato contato;
            using (var con = new SqlConnection(_strCon))
            {
                contato = con.QueryFirst<Contato>("select id, nome from Contato where Id = @Id", new { Id = id });
            }
            return contato;
        }

        public List<Contato> ObterTodos()
        {
            List<Contato> contatos = new List<Contato>();
            using (var con = new SqlConnection(_strCon))
            {

                contatos = con.Query<Contato>("select id, nome from Contato").ToList();              
            }

            return contatos;
        }
    }
}
