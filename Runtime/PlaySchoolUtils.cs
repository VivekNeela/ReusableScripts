using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMKOC.Reusable
{
    public static class PlaySchoolUtils
    {
        /// <summary>
        /// Retrieves the language setting from PlayerPrefs.
        /// If the key does not exist or the value cannot be parsed, it returns a default
        /// </summary>
        /// <returns></returns>
        public static Language GetLanguage()
        {
            const string key = "PlayschoolLanguageAudio";

            if (!PlayerPrefs.HasKey(key))
            {
                Debug.LogWarning($"PlayerPrefs does not contain key '{key}'. Returning default Language (English).");
                return Language.EnglishUS; // Or choose a specific fallback like Language.English
            }

            var languageString = PlayerPrefs.GetString(key);

            try
            {
                return StringToEnum<Language>(languageString);
            }
            catch (ArgumentException ex)
            {
                Debug.LogError($"Failed to parse language from PlayerPrefs: {ex.Message}. Returning default Language.");
                return default; // Optional fallback
            }
        }


        // Convert string to enum (case-insensitive)
        public static T StringToEnum<T>(string value) where T : struct, Enum
        {
            if (Enum.TryParse(value, true, out T result))
                return result;
            else
                throw new ArgumentException($"'{value}' is not a valid value for enum {typeof(T)}.");
        }


        /// <summary>
        /// Sets the language for the game  
        /// </summary>
        public static void SetLanguageData<T>(TMKOC.Reusable.Language currentLanguage, ref Dictionary<Language, ScriptableObject> dict, ref T currentAudiodata)
        where T : ScriptableObject
        {
            if (dict.TryGetValue(currentLanguage, out ScriptableObject rawData))
            {
                if (rawData is T typedData)
                    currentAudiodata = typedData;
                else
                    Debug.LogError($"Data for {currentLanguage} is not of type {typeof(T)}.");
            }
            else
            {
                Debug.LogError($"No audio data found for {currentLanguage}.");
            }
        }







    }
}