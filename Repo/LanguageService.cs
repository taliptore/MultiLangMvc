using MultiLangMvc.Models;

namespace MultiLangMvc.Repo
{
    public class LanguageService : ILanguageService
    {
        private readonly AppDbContext _context;

        public LanguageService(AppDbContext context)
        {
            _context = context;
        }

        public Language GetLanguageByCulture(string culture)
        {
            return _context.Languages.FirstOrDefault(x =>
           x.Culture.Trim().ToLower() == culture.Trim().ToLower());
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _context.Languages.ToList();
        }
    }
}
