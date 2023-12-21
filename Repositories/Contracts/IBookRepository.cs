using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        //TASK öncesi: IEnuremable<Book> GetAllBooks
        Task<PagedList<Book>> GetAllBooksAsync(BookParameters bookParameters, 
            bool trackChanges);

        //Task öncesi: Book GetOneBookById(int id, bool trackChanges);
        Task<Book> GetOneBookByIdAsync(int id, bool trackChanges);

        //Tracking bazlı çalışmalarda async kullanmayız. (aşağıdaki metodlar)
        void CreateOneBook(Book book);
        void UpdateOneBook(Book book);
        void DeleteOneBook(Book book);


    }
}
