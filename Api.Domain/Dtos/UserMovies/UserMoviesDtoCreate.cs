using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.UserMovies
{
    public class UserMoviesDtoCreate
    {
        [Required(ErrorMessage = "Id de Usuário é campo obrigatório")]
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Id de Series é campo obrigatório")]
        public Guid MovieId { get; set; }
    }
}
