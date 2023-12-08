using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        //context e erişim için yapıyoruz.
        public readonly RepositoryContext _context;
        //lazy loading: nesne kullanıldığında sadece newlenir. amacı budur. , inject edilmez, sınıfta manuel olarak kullanılır.
        private readonly Lazy<IBookRepository> _bookRepository;
        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_context));

        }
        //"new BookRepository" neden yaptık: IoC pratikliği
        public IBookRepository Book => _bookRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
