using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyNews.Domains
{
    [Table("Rubrics")]
    public class Rubric
    {
        [Key]
        public long RubricId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Article> ArticlesOfRubrics { get; set; }
    }
}
