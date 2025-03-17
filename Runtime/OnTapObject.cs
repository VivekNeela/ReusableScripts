
using UnityEngine;
using UnityEngine.EventSystems;

namespace TMKOC.Reusable
{
    public abstract class OnTapObject : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public abstract void OnMouseDown();
        public abstract void OnPointerDown(PointerEventData eventData);
        public abstract void OnPointerUp(PointerEventData eventData);
        public virtual void OnDrag(PointerEventData eventData) { }

        protected virtual void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                ClickedOnce();
            }
        }

        protected virtual void ClickedOnce() { }




    }
}
