using MultiLangMvc.Models;

namespace MultiLangMvc.Repo
{
    public class LocalizationService : ILocalizationService
    {
        private readonly AppDbContext _context;

        public LocalizationService(AppDbContext context)
        {
            _context = context;
        }

        public StringResource GetStringResource(string resourceKey, int languageId)
        {
            return _context.StringResources.FirstOrDefault(x =>
                    x.Name.Trim().ToLower() == resourceKey.Trim().ToLower()
                    && x.LanguageId == languageId);
        }
    }
}
