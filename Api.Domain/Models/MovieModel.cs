using System;

namespace Api.Domain.Models
{
    public class MovieModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        
        private Guid _genreId;
        public Guid GenreId
        {
            get { return _genreId; }
            set { _genreId = value; }
        }
    }
}