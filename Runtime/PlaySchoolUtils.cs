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


        /*

                /// <summary>
                /// Sets the language for the game  
                /// </summary>
                public static void SetLanguageData<T>(TMKOC.Reusable.Language currentLanguage, ref T currentAudiodata) where T : ScriptableObject
                {
                    // T currentAudiodata = null;

                    switch (currentLanguage)
                    {
                        case TMKOC.Reusable.Language.Hindi:
                            currentAudiodata = soundDataSO_Hindi;
                            break;
                        case TMKOC.Reusable.Language.EnglishUS:
                            currentAudiodata = soundDataSO_English;
                            break;
                        case TMKOC.Reusable.Language.Tamil:
                            currentAudiodata = soundDataSO_English;  //not done
                            break;
                        case TMKOC.Reusable.Language.Marathi:
                            currentAudiodata = soundDataSO_Marathi;
                            break;
                        case TMKOC.Reusable.Language.Bengali:    //didnt receive the audio for bengali yet...
                            currentAudiodata = soundDataSO_Bengali;
                            break;
                        case TMKOC.Reusable.Language.French:
                            currentAudiodata = soundDataSO_English;  //not done
                            break;
                        case TMKOC.Reusable.Language.Malayalam:
                            currentAudiodata = soundDataSO_English;  //not done
                            break;
                        default:
                            currentAudiodata = soundDataSO_English;
                            break;
                    }
                }

        */

        public static Dictionary<TKey, TValue> AddToDictionary<TKey, TValue>(ref Dictionary<TKey, TValue> dict, TKey language, TValue audioData)
        where TKey : Enum
        where TValue : ScriptableObject
        {
            // Dictionary<TKey, TValue> dict = new Dictionary<TKey, TValue>();
            dict.Add(language, audioData);
            return dict;
        }




    }
}