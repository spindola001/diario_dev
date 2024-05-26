using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using portifolio_web_site.Data;

namespace portifolio_web_site.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new portifolio_web_siteContext(
                serviceProvider.GetRequiredService<DbContextOptions<portifolio_web_siteContext>>()
            ))
            {
                SeedDataProfileModel(context);
                SeedDataPostModel(context);
            }
        }

        private static void SeedDataProfileModel(portifolio_web_siteContext context)
        {
            if (context == null || context.ProfileModel == null)
            {
                throw new ArgumentException("Null portifolio_web_siteContext");
            }

            if (context.ProfileModel.Any())
            {
                return;
            }

            context.ProfileModel.AddRange(
                new ProfileModel
                {
                    Name = "Marcos Spindola",
                    DateOfBirth = DateTime.Parse("2001-4-2"),
                    Age = 23,
                    Profesion = "Engenheiro de Software .NET Pleno",
                    ProfessionalSumary = "Engenheiro de Software .NET há 3 anos, atuando no setor de automação de processos de negócios, focado em processos de instituções financeiras.",
                    PersonalSumary = "Músico, extrovertido e comprometido com aquilo que me disponho a fazer. Amante de tecnologia, e outras coisas de nerd."
                }
            );

            context.SaveChanges();
        }
        private static void SeedDataPostModel(portifolio_web_siteContext context)
        {
            if (context == null || context.PostModel == null)
            {
                throw new ArgumentException("Null portifolio_web_siteContext");
            }

            if (context.PostModel.Any())
            {
                return;
            }


            context.PostModel.AddRange(
                new PostModel
                {
                    Title = $"Apresentação",
                    PostContent = $@"Fala Diário Dev! Tranquilo no mamilo? Hoje eu preciso me apresentar. Sou o Marcos Spindola, nascido em 2001, e trabalho como Dev desde 2021. Mas vocês já devem ter visto algo assim no Home desse site. Então vamos lá: O intuíto desse site é compartilhar um pouco do meu conhecimento com vocês. Desabafar as minhas dores e aprendizados do dia a dia de um Dev maluco. Vamos lá?",
                    DateCreate = DateTime.Now,
                    DateUpdate = DateTime.Now,
                }
            );

            context.SaveChanges();
        }
    }
}
