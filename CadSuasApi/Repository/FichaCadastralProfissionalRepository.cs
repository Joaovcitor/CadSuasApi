using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadSuasApi.Context;
using CadSuasApi.Models;

namespace CadSuasApi.Repository
{
    public class FichaCadastralProfissionalRepository : Repository<FichaCadastralProfissional>, IFichaCadastralProfisionalRepository
    {
        public FichaCadastralProfissionalRepository(AppDbContext context) : base(context)
        {
        }
    }
}