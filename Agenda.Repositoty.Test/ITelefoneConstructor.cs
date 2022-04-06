using Agenda.Domain;
using Moq;
using System;
using AutoFixture;

namespace Agenda.Repositoty.Test
{
    public class ITelefoneConstructor : BaseConstructor<ITelefone>
    {

        protected ITelefoneConstructor() : base()
        {

        }

        public static ITelefoneConstructor Um()
        {
            return new ITelefoneConstructor();
        }


        public ITelefoneConstructor Default()
        {
            _mock.SetupGet(x => x.Id).Returns(_fixture.Create<Guid>());
            _mock.SetupGet(x => x.Numero).Returns(_fixture.Create<string>());
            _mock.SetupGet(x => x.ContatoId).Returns(_fixture.Create<Guid>());
            return this;
        }

        public ITelefoneConstructor ComId(Guid id)
        {
            _mock.SetupGet(x => x.Id).Returns(id);
            return this;
        }

        public ITelefoneConstructor ComNumero(string numero)
        {
            _mock.SetupGet(x => x.Numero).Returns(numero);
            return this;
        }

        public ITelefoneConstructor ComContatoId(Guid contatoId)
        {
            _mock.SetupGet(x => x.ContatoId).Returns(contatoId);
            return this;
        }
    }
}
