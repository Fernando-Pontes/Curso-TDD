using NUnit.Framework;
using Agenda.DAL;
using Moq;
using Agenda.Repository;
using Agenda.Domain;
using System;
using System.Collections.Generic;

namespace Agenda.Repositoty.Test
{
    [TestFixture]
    public class RepositorioContatosTest
    {

        Mock<IContatos> _contatos;
        Mock<ITelefones> _telefones;
        RepositorioContatos _repositorioContatos;

        [SetUp]
        public void Setup()
        {
            _contatos = new Mock<IContatos>();
            _telefones = new Mock<ITelefones>();
            _repositorioContatos = new RepositorioContatos(_contatos.Object, _telefones.Object);
        }

        [Test]
        public void Test()
        {
            var telefoneId = Guid.NewGuid();
            var contatoId = Guid.NewGuid();

            var lstTelefone = new List<ITelefone>();

            var mContato = IContatoConstructor.Um()
                .ComId(contatoId)
                .ComNome("Aristides")
                .Obter();


            mContato.SetupSet(o => o.Telefones = It.IsAny<List<ITelefone>>())
                .Callback<List<ITelefone>>(p => lstTelefone = p);

            _contatos.Setup(o => o.Obter(contatoId)).Returns(mContato.Object);

            var mTelefone = ITelefoneConstructor.Um()
                .Default()
                .ComId(telefoneId)
                .ComContatoId(contatoId)
                .Construir();


            _telefones.Setup(o => o.ObterTodosDoContato(contatoId)).Returns(new List<ITelefone> { mTelefone });

            var contatoResultado = _repositorioContatos.ObterPorId(contatoId);
            mContato.SetupGet(o => o.Telefones).Returns(lstTelefone);

            Assert.AreEqual(mContato.Object.Id, contatoResultado.Id);
            Assert.AreEqual(mContato.Object.Nome, contatoResultado.Nome);
            Assert.AreEqual(1, contatoResultado.Telefones.Count);
            Assert.AreEqual(mTelefone.Numero, contatoResultado.Telefones[0].Numero);
            Assert.AreEqual(mTelefone.Id, contatoResultado.Telefones[0].Id);
            Assert.AreEqual(mContato.Object.Id, contatoResultado.Telefones[0].ContatoId);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _telefones = null;
        }
    }
}
