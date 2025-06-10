using System;
using System.Collections;
using UnityEngine;

namespace TMKOC.Reusable
{
    public class AudioFunctions : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioSource audioSource_BG;
        public AudioSource audioSource_Sfx;

        [SerializeField] private bool isPlaying;
        public bool IsPlaying { get => isPlaying; set => isPlaying = value; }

        private void Update()
        {
            if (audioSource != null)
                IsPlaying = audioSource.isPlaying;
        }

        public void PlayOnce(AudioClip clip, Action nextClip = null)
        {
            // stopPlaying = false;
            if (clip == null)
            {
                Debug.LogWarning("<color=yellow> AudioClip is null ! </color>");
                StartCoroutine(WaitForClipEnd(nextClip));   //need to do this in case the clip is null and we still need to execute the next callback...(stupid af) 
                return;
            }

            audioSource.clip = clip;
            audioSource.loop = false;
            audioSource.Play();

            StartCoroutine(WaitForClipEnd(nextClip));

        }


        public void PlayOnLoop(AudioClip clip)
        {
            if (clip == null)
            {
                Debug.LogWarning("AudioClip is null.");
                return;
            }

            audioSource.clip = clip;
            audioSource.loop = true;
            audioSource.Play();
        }


        public void StopPlaying()
        {
            audioSource.Stop();
        }

        private IEnumerator WaitForClipEnd(Action onClipEnd)
        {
            while (audioSource.isPlaying)
            {
                yield return null; // Wait for the next frame
            }
            onClipEnd?.Invoke();
        }

        public void PlayBgMusic(AudioClip clip)   //just different audiosource...
        {
            if (clip == null)
            {
                Debug.LogWarning("AudioClip is null.");
                return;
            }

            audioSource_BG.clip = clip;
            audioSource_BG.loop = true;
            audioSource_BG.Play();
        }

        //only for playing sfx clips
        public void PlaySfxClip(AudioClip clip, Action nextClip)
        {
            // stopPlaying = false;
            if (clip == null)
            {
                Debug.LogWarning("<color=yellow> Sfx AudioClip is null ! </color>");
                StartCoroutine(WaitForClipEnd(nextClip));   //need to do this in case the clip is null and we still need to execute the next callback...(stupid af) 
                return;
            }

            audioSource_Sfx.clip = clip;
            audioSource_Sfx.loop = false;
            audioSource_Sfx.Play();

            StartCoroutine(WaitForClipEnd(nextClip));
        }

    }


}
