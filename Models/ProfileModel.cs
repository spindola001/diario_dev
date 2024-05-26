using System.ComponentModel.DataAnnotations;

namespace portifolio_web_site.Models
{
	public class ProfileModel
	{
		public int Id { get; set; }
        [Display(Name = "Nome")]
		public string? Name { get; set; }
        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Idade")]
        public int Age { get; set; }
		[Display(Name = "Profissão")]
		public string? Profesion { get; set; }
		[Display(Name = "Resumo profissional")]
		public string? ProfessionalSumary { get; set; }
		[Display(Name = "Resumo pessoal")]
		public string? PersonalSumary { get; set; }
    }
}
