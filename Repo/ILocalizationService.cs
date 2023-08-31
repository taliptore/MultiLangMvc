using MultiLangMvc.Models;

namespace MultiLangMvc.Repo
{
    public interface ILocalizationService
    {
        StringResource GetStringResource(string resourceKey, int languageId);

    }
}
