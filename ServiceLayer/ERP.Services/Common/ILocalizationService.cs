using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Services.Common
{
    public interface ILocalizationService
    {
        string GetResource(string resourceKey, int languageId = 0, bool logIfNotFound = true, string defaultValue = "", bool returnEmptyIfNotFound = false);
    }

    public class LocalizationService : ILocalizationService
    {
        public string GetResource(string resourceKey, int languageId = 0, bool logIfNotFound = true, string defaultValue = "", bool returnEmptyIfNotFound = false)
        {
            throw new NotImplementedException();
        }
    }
}
