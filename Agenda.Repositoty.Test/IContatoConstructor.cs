using Agenda.Domain;
using Moq;
using System;
using AutoFixture;

namespace Agenda.Repositoty.Test
{
    public class IContatoConstructor : BaseConstructor<IContato>
    {
        protected IContatoConstructor() : base()
        {

        }

        public static IContatoConstructor Um()
        {
            return new IContatoConstructor();
        }

        public IContatoConstructor ComNome(string nome)
        {
            _mock.SetupGet(x => x.Nome).Returns(nome);
            return this;
        }

        public IContatoConstructor ComId(Guid id)
        {
            _mock.SetupGet(x => x.Id).Returns(id);
            return this;
        }

    }
}
