using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Genre
{
    public class GenreDtoCreate
    {
        [Required(ErrorMessage = "Nome é campo obrigatório")]
        [StringLength(150, ErrorMessage = "Nome deve ter no máximo {1} caracteres")]
        public string Name { get; set; }
    }
}