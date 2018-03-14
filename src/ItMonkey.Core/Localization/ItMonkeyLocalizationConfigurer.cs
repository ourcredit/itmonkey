using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace ItMonkey.Localization
{
    public static class ItMonkeyLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(ItMonkeyConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ItMonkeyLocalizationConfigurer).GetAssembly(),
                        "ItMonkey.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
