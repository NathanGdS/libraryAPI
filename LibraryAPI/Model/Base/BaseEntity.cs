using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
