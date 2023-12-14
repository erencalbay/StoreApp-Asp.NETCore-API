using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{

    //Data Transfer Objects!!; 
    //DTO readonly olmalı
    //DTO LinQ desteği vardır
    //ref type vardır
    //ctor(DTO) şansımız vardır

    //set yerine init koyarsak readonly olur.
    public record BookDtoForUpdate : BookDtoForManipulation
    {
        [Required]
        public int Id { get; init; }

    }

}
