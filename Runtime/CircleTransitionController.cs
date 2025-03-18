using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTransitionController : MonoBehaviour
{
    [SerializeField] private Material transitionMat;
    [SerializeField] private float transitionDuration;
    [SerializeField] private bool inTransition;


    public IEnumerator TransitionLerp(float a, float b, float duration)
    {
        inTransition = true;
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
        inTransition = false;
    }

}
