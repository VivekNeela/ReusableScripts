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
        [SerializeField] private Color color;
        [SerializeField] private bool inTransition;
        public bool InTransition { get => inTransition; set => inTransition = value; }


        private void Start()
        {
            //keeping the circle open at start
            transitionMat.SetFloat("_Radius", 1);
            //some random ass scaling logic below dosent makes much sense, just wanted to try this...
            var canvasSize = canvas.GetComponent<RectTransform>().sizeDelta;
            //scale up circle to the screen...
            var side = canvasSize.x > canvasSize.y ? canvasSize.x : canvasSize.y;
            circleRect.sizeDelta = new Vector2(side, side);
            transitionMat.SetColor("_Color", color);

        }

        public void CloseCircle(Action callback = null)
        {
            StartCoroutine(TransitionLerp(1, -0.1f, transitionDuration, callback));
        }

        public void OpenCircle(Action callback = null)
        {
            StartCoroutine(TransitionLerp(-0.1f, 1f, transitionDuration, callback));
        }

        public void SetRadius(float radius)
        {
            transitionMat.SetFloat("_Radius", radius);
        }

        public IEnumerator TransitionLerp(float a, float b, float duration, Action callback = null)
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
            callback?.Invoke();
        }


    }



}