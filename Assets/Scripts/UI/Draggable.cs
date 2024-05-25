using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using static UnityEditor.Progress;
using UnityEditor.Experimental.GraphView;
using BGS.ProgrammerTask.Utilities;
namespace BGS.ProgrammerTask.UI
{
    public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [HideInInspector]
        public Transform parentToReturnTo = null;
        [HideInInspector]
        public Transform placeHolderParent = null;

        private GameObject placeHolder = null;
        public string draggableTag = "";

        private LayoutElement mylayoutElement;
        private CanvasGroup myCanvasGroup;
        public DropZone CurrentDropZone;

        public int GetSilbingIndex
        {
            get
            {
                if (placeHolder != null)
                {
                    return placeHolder.transform.GetSiblingIndex();
                }
                else
                    return transform.GetSiblingIndex();
            }
        }

        private void Awake()
        {
            mylayoutElement = gameObject.GetComponent<LayoutElement>();
            myCanvasGroup = gameObject.GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                return;
            }
            placeHolder = new GameObject();
            placeHolder.transform.SetParent(this.transform.parent);
            LayoutElement le = placeHolder.AddComponent<LayoutElement>();
            le.preferredWidth = mylayoutElement.preferredWidth;
            le.preferredHeight = mylayoutElement.preferredHeight;
            le.flexibleWidth = 0;
            le.flexibleHeight = 0;

            placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

            parentToReturnTo = this.transform.parent;
            placeHolderParent = parentToReturnTo;
            this.transform.SetParent(CanvasReference.Instance.GetCanvas().transform);
            myCanvasGroup.blocksRaycasts = false;
        }



        int newSiblingIndex;
        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                return;
            }
            this.transform.position = eventData.position;
            //if (placeHolder.transform.parent != placeHolderParent)
            //{
            //    placeHolder.transform.SetParent(placeHolderParent);
            //}

            newSiblingIndex = placeHolderParent.childCount;

            for (int i = 0; i < placeHolderParent.childCount; i++)
            {
                if (this.transform.position.x < placeHolderParent.GetChild(i).position.x)
                {
                    newSiblingIndex = i;

                    if (i < newSiblingIndex)
                        newSiblingIndex--;

                    break;
                }
            }

            //  placeHolder.transform.SetSiblingIndex(newSiblingIndex);
        }

        public void SetIndexPosition(int silbingIndex)
        {
            if (silbingIndex < 0)
                silbingIndex = transform.parent.childCount;
            this.transform.SetParent(parentToReturnTo);
            this.transform.SetSiblingIndex(silbingIndex);
            myCanvasGroup.blocksRaycasts = true;

        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                return;
            }
            this.transform.SetParent(parentToReturnTo);
            this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
            myCanvasGroup.blocksRaycasts = true;
            Destroy(placeHolder);
        }

        public void LeaveDropZone()
        {
            if (CurrentDropZone)
                CurrentDropZone.RemoveDraggable(this);

        }
        public bool CanBeRemovedFromDropZone()
        {
            if (CurrentDropZone)
                return CurrentDropZone.CanRemovedDraggable(this);
            return true;
        }


    }

}
