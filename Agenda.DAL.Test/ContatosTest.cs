using NUnit.Framework;
using Agenda.Domain;
using AutoFixture;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTest : BaseTest
    {

        Contatos _contatos;
        Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _contatos = new Contatos();
            _fixture = new Fixture();
        }

        //Incluir Contato
        [Test]
        public void AdicionarContatoTest()
        {
            //Monta
            var contato = _fixture.Create<Contato>();

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
            var contato = _fixture.Create<Contato>();
            //Executa
            _contatos.Adicionar(contato);
            Contato contatoResultado = _contatos.Obter(contato.Id);
            //Verifica
            Assert.AreEqual(contato.Id, contatoResultado.Id);
            Assert.AreEqual(contato.Nome, contatoResultado.Nome);
        }

       


        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _fixture = null;
        }
    }
}
