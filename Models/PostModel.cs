using System.ComponentModel.DataAnnotations;

namespace portifolio_web_site.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        [Display(Name = "Título")]
        public string? Title { get; set; }
        [Display(Name = "Publicação")]
        public string? PostContent { get; set; }
        [Display(Name = "Data de postagem")]
        public DateTime DateCreate { get; set; }
        [Display(Name = "Data de atualização")]
        public DateTime DateUpdate { get; set; } = DateTime.Now;
    }
}
