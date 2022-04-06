using Agenda.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DAL
{
    public  interface IContatos
    {
        IContato Obter(Guid id);
    }
}
