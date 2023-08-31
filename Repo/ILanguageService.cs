using MultiLangMvc.Models;

namespace MultiLangMvc.Repo
{
    public interface ILanguageService
    {
        IEnumerable<Language> GetLanguages();
        Language GetLanguageByCulture(string culture);
    }
}
