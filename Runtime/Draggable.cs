using UnityEngine;
using Lean.Touch;
using UnityEngine.Events;
using Lean.Common; 


[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D), typeof(LeanDragTranslate))]
[RequireComponent(typeof(LeanSelectableByFinger))]
public abstract class Draggable : MonoBehaviour
{
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected LeanDragTranslate leanDragTranslate;
    [SerializeField] protected LeanSelectableByFinger leanSelectableByFinger;

    //only for setting up action events in code
    private UnityAction<LeanSelect> OnSelectedAction;
    private UnityAction<LeanSelect> OnDeselectedAction;


    private void OnValidate()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        leanDragTranslate = GetComponent<LeanDragTranslate>();
        leanSelectableByFinger = GetComponent<LeanSelectableByFinger>();
    }

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        leanDragTranslate = GetComponent<LeanDragTranslate>();
        leanSelectableByFinger = GetComponent<LeanSelectableByFinger>();

        //settig selected and deselected in awake...
        OnSelectedAction = (LeanSelect) =>
        {
            OnSelected();
        };

        OnDeselectedAction = (LeanSelect) =>
        {
            OnDeselected();
        };

    }

    protected virtual void OnEnable()
    {
        leanSelectableByFinger.OnSelected.AddListener(OnSelectedAction);
        leanSelectableByFinger.OnDeselected.AddListener(OnDeselectedAction);
    }

    protected virtual void OnDisable()
    {
        leanSelectableByFinger.OnSelected.RemoveListener(OnSelectedAction);
        leanSelectableByFinger.OnDeselected.RemoveListener(OnDeselectedAction);
    }

    protected abstract void OnSelected();

    protected abstract void OnDeselected();




}
