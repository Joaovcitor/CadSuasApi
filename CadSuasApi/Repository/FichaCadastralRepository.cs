using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadSuasApi.Context;
using CadSuasApi.Models;

namespace CadSuasApi.Repository
{
    public class FichaCadastralRepository : Repository<FichaCadastralPessoal>, IFichaCadastralRepository
    {
        public FichaCadastralRepository(AppDbContext context) : base(context)
        {
        }
    }
}