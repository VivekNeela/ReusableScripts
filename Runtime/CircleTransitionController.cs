using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TMKOC.Reusable
{

    public class CircleTransitionController : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private RectTransform circleRect;
        [SerializeField] private Material transitionMat;
        [SerializeField] private float transitionDuration;
        [SerializeField] private bool inTransition;
        public bool InTransition { get => inTransition; set => inTransition = value; }


        private void Start()
        {
            //some random ass scaling logic below dosent makes much sense, just wanted to try this...
            var canvasSize = canvas.GetComponent<RectTransform>().sizeDelta;
            //scale up circle to the screen...
            var side = canvasSize.x > canvasSize.y ? canvasSize.x : canvasSize.y;
            circleRect.sizeDelta = new Vector2(side, side);

            // PlayModeExitCallback.transitionMat = transitionMat;
        }


        public void CloseCircle()
        {
            StartCoroutine(TransitionLerp(1, -0.1f, transitionDuration));
        }

        public void OpenCircle()
        {
            StartCoroutine(TransitionLerp(-0.1f, 1f, transitionDuration));
        }

        public IEnumerator TransitionLerp(float a, float b, float duration)
        {
            InTransition = true;
            float time = 0;
            while (time < duration)
            {
                float t = time / duration;
                float value = Mathf.Lerp(a, b, t);
                transitionMat.SetFloat("_Radius", value);
                time += Time.deltaTime;
                yield return null;
            }
            transitionMat.SetFloat("_Radius", b);
            InTransition = false;
        }


    }


    // [InitializeOnLoad]
    // public class PlayModeExitCallback
    // {
    //     public static Material transitionMat;

    //     static PlayModeExitCallback()
    //     {
    //         EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    //     }

    //     private static void OnPlayModeStateChanged(PlayModeStateChange state)
    //     {
    //         if (state == PlayModeStateChange.ExitingPlayMode)
    //         {
    //             Debug.Log("Exiting Play Mode!");
    //             transitionMat.SetFloat("_Radius", 1);   //just needed to do this on exit...
    //         }
    //     }
    // }
}