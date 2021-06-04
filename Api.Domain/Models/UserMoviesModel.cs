using System;

namespace Api.Domain.Models
{
    public class UserMoviesModel : BaseModel
    {
        private Guid _userId;
        public Guid UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        
        private Guid _movieId;
        public Guid MovieId
        {
            get { return _movieId; }
            set { _movieId = value; }
        }       
    }
}