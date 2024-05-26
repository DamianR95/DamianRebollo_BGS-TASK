using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Linq;
using BGS.ProgrammerTask.Utilities;
using System;
namespace BGS.ProgrammerTask.UI
{
    public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public string draggableTag = "";
        public bool hasLimitChild;
        public int maxChilds = 1;
        public bool replaceChild;
        public System.Action<Draggable> OnReceiveDraggable;
        public System.Action<Draggable> OnRemoveDraggable;

        public List<Draggable> myDraggables = new List<Draggable>();

        public System.Action<Draggable> OnAttemptToRemoveDraggable;
        public System.Action<Draggable> OnRemoveFailed;

        private List<Func<bool>> conditionsToRemove;

        public bool IsFull => hasLimitChild ? myDraggables.Count >=  maxChilds : false;

        private void Awake()
        {
            myDraggables = GetComponentsInChildren<Draggable>().ToList();
        }
        public void AddConditionForRemove(Func<bool> condition)
        {
            if(conditionsToRemove == null)
                conditionsToRemove = new List<Func<bool>>();

            conditionsToRemove.Add(condition);
        }

        public void AddDraggable(Draggable d, int prevIndex = -1)
        {
            if (d.CurrentDropZone != null && d.CurrentDropZone == this)
                return;

            if (CanReceiveDraggable(d) && d.CanBeRemovedFromDropZone())
            {
                var NewDraggablePreviousDropZone = d.CurrentDropZone;
                d.LeaveDropZone();
                myDraggables.Add(d);
                d.CurrentDropZone = this;
                d.parentToReturnTo = this.transform;
                d.SetIndexPosition(prevIndex);

                if (replaceChild)
                {
                    while (myDraggables.Count > maxChilds)
                    {
                        if (myDraggables[0] == null)
                        {
                            
                            myDraggables.RemoveAt(0);
                        }
                        else
                        {
                            var removedD = RemoveDraggable(myDraggables[0]);
                            NewDraggablePreviousDropZone.AddDraggable(removedD, d.GetSilbingIndex);
                            //  removedD.ReturnToOriginalDragZone();
                        }
                    }
                }
                if (OnReceiveDraggable != null)
                    Utils.CallAction(OnReceiveDraggable.GetInvocationList(), d);
            }
        }

        public Draggable RemoveDraggable(Draggable d)
        {
            if (OnRemoveDraggable != null)
                Utils.CallAction(OnRemoveDraggable.GetInvocationList(), d);
            d.CurrentDropZone = null;
            myDraggables.Remove(d);
            return d;
        }

        private Transform _transform;
        public Transform myTransform
        {
            get
            {
                if (!_transform)
                    _transform = transform;
                return _transform;
            }
        }
        public bool CanReceiveDraggable(Draggable newDraggable)
        {

            if (!newDraggable)
                return false;

            if (!replaceChild && hasLimitChild && myDraggables.Count >= maxChilds)
                return false;
            if (!string.IsNullOrEmpty(draggableTag))
            {
                if (newDraggable.draggableTag != draggableTag)
                    return false;
            }
            return true;

        }

        public bool CanRemovedDraggable(Draggable d) {
            if (OnAttemptToRemoveDraggable != null)
                Utils.CallAction(OnAttemptToRemoveDraggable.GetInvocationList(), d);
            if (conditionsToRemove != null) { 
            foreach (var condition in conditionsToRemove)
            {
                if (!condition())
                {
                      if (OnRemoveFailed != null)
                           Utils.CallAction(OnRemoveFailed.GetInvocationList(), d);

                        return false;
                }
                }
            }
            return true;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {

            if (eventData.pointerDrag == null)
                return;

            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (CanReceiveDraggable(d))
            {
                d.placeHolderParent = this.transform;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {

            if (eventData.pointerDrag == null)
                return;

            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if ((CanReceiveDraggable(d)) && d.placeHolderParent == this.transform)
            {
                d.placeHolderParent = d.parentToReturnTo;
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            //Debug.Log(eventData.pointerDrag.name + " dropped on " + gameObject.name);

            if (eventData.button == PointerEventData.InputButton.Right)
            {
                return;
            }
            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            AddDraggable(d);
        }
    }
}