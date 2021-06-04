using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Movie
{
    public class MovieDtoCreate
    {
        [Required(ErrorMessage = "Nome é campo obrigatório")]
        [StringLength(150, ErrorMessage = "Nome deve ter no máximo {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Descrição é campo obrigatório")]
        [StringLength(255, ErrorMessage = "Descrição deve ter no máximo {1} caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Id de Genêro é campo obrigatório")]
        public Guid GenreId { get; set; }
    }
}
