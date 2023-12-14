using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace WebAPI.Utilities.AutoMapper
{

    //maplenmesi için profil dosyası gerekli.
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //kaynaktan, varışa veriyoruz yani <source, destination> = <bookdtoforupdate, book>
            //Kaynak: BookDtoForUpdate,
            //Varış: Book,
            CreateMap<BookDtoForUpdate, Book>();
            CreateMap<Book, BookDto>();
            CreateMap<BookDtoForInsertion, Book>();
        }
    }
}
