using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadSuasApi.Repository
{
    public interface IUnitOfWork
    {
        IFichaCadastralProfisionalRepository FichaCadastralProfisionalRepository { get; }
        IFichaCadastralRepository FichaCadastralRepository { get; }

        void Commit();
    }
}