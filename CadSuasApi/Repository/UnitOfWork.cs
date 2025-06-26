using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadSuasApi.Context;

namespace CadSuasApi.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IFichaCadastralProfisionalRepository? _fichaProfissional;
        private IFichaCadastralRepository? _fichaRepository;

        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IFichaCadastralProfisionalRepository FichaCadastralProfisionalRepository
        {
            get { return _fichaProfissional = _fichaProfissional ?? new FichaCadastralProfissionalRepository(_context); }
        }

        public IFichaCadastralRepository FichaCadastralRepository
        {
            get { return _fichaRepository = _fichaRepository ?? new FichaCadastralRepository(_context); }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}