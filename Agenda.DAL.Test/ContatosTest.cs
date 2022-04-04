using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Agenda.Domain;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTest : BaseTest
    {

        Contatos _contatos;

        [SetUp]
        public void SetUp()
        {
            _contatos = new Contatos();
        }

        //Incluir Contato
        [Test]
        public void AdicionarContatoTest()
        {
            //Monta
            var contato = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Marcos"
            };

            //Executa
            _contatos.Adicionar(contato);
            //Verifica
            Assert.True(true);
        }
        
        //Obter Contato
        [Test]
        public void ObterContatoTest()
        {
            //Monta
            var contato = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Neuza"
            };
            //Executa
            _contatos.Adicionar(contato);
            Contato contatoResultado = _contatos.Obter(contato.Id);
            //Verifica
            Assert.AreEqual(contato.Id, contatoResultado.Id);
            Assert.AreEqual(contato.Nome, contatoResultado.Nome);
        }

        [Test]
        public void ObterTodosTest()
        {
            var contato1 = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Josefina"
            };
            var contato2 = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Aristides"
            };

            _contatos.Adicionar(contato1);
            _contatos.Adicionar(contato2);
            var lstContatos = _contatos.ObterTodos();
            var contatoResultado = lstContatos.Where(o => o.Id == contato1.Id).FirstOrDefault();

            Assert.IsTrue(lstContatos.Count > 1);
            Assert.AreEqual(contato1.Id, contatoResultado.Id);
            Assert.AreEqual(contato1.Nome, contatoResultado.Nome);
        }


        [TearDown]
        public void TearDown()
        {
            _contatos = null;
        }
    }
}
