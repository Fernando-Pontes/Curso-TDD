using Agenda.DAL;
using Agenda.Domain;
using System;
using System.Collections.Generic;

namespace Agenda.Repository
{
    public  class RepositorioContatos
    {
        private readonly IContatos _contatos;
        private readonly ITelefones _telefones;

        public RepositorioContatos(IContatos contatos, ITelefones telefones)
        {
            _contatos = contatos;
            _telefones = telefones;
        }

        public IContato ObterPorId(Guid Id)
        {
            IContato contato = _contatos.Obter(Id);

            List<ITelefone> lstTelefone = _telefones.ObterTodosDoContato(Id);
            contato.Telefones = lstTelefone;
            return contato;
        }
    }
}
