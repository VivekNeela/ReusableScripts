using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMKOC.Reusable
{
    public static class PlaySchoolUtils
    {
        public static Language GetLanguage()
        {
            var languageString = PlayerPrefs.GetString("PlayschoolLanguageAudio");
            return StringToEnum<Language>(languageString);
        }

        // Convert string to enum (case-insensitive)
        public static T StringToEnum<T>(string value) where T : struct, Enum
        {
            if (Enum.TryParse(value, true, out T result))
                return result;
            else
                throw new ArgumentException($"'{value}' is not a valid value for enum {typeof(T)}.");
        }


    }
}