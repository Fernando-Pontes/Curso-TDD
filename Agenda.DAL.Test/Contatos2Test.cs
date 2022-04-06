using Agenda.Domain;
using AutoFixture;
using NUnit.Framework;
using System.Linq;


namespace Agenda.DAL.Test
{
    [TestFixture]
    public class Contatos2Test : BaseTest
    {
        Contatos _contatos;
        Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _contatos = new Contatos();
            _fixture = new Fixture();
        }

        [Test]
        public void ObterTodosTest()
        {
            Contato contato1 = _fixture.Create<Contato>();

            Contato contato2 = _fixture.Create<Contato>();

            _contatos.Adicionar(contato1);
            _contatos.Adicionar(contato2);
            var lstContatos = _contatos.ObterTodos();
            var contatoResultado = lstContatos.Where(o => o.Id == contato1.Id).FirstOrDefault();

            Assert.AreEqual(2, lstContatos.Count());
            Assert.AreEqual(contato1.Id, contatoResultado.Id);
            Assert.AreEqual(contato1.Nome, contatoResultado.Nome);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _fixture = null;
        }
    }
}
