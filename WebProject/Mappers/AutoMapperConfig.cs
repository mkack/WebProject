using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProject.DTO;
using WebProject.Models;

namespace WebProject.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper MapperInitialize() 
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookDTO>();
                cfg.CreateMap<BookDTO, Book>();
            })
            .CreateMapper();
    }
}
