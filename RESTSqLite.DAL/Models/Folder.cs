using System.ComponentModel.DataAnnotations.Schema;

namespace RESTSqLite.DAL.Models
{
    public class Folder
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public Folder ParentFolder { get; set; }
        public string Name { get; set; }
    }
}
