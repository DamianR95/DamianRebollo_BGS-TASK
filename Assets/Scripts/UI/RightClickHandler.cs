using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
namespace BGS.ProgrammerTask.UI
{
    public class RightClickHandler : MonoBehaviour , IPointerClickHandler
    {
        [SerializeField]
        protected DropZone _myZone;
        [SerializeField]
        private DropZone _zoneToTravel;


        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
                {
                    position = Input.mousePosition
                };

                RaycastResult raycastResult = RaycastUI(pointerEventData);

                if (raycastResult.gameObject != null)
                {
                    Apply(raycastResult.gameObject.GetComponent<Draggable>());
                }
            }
        }
        protected virtual void Apply(Draggable d) {

            if (d != null && _myZone.myDraggables.Contains(d))
            {
                _zoneToTravel.AddDraggable(d);
            }
        }

        private RaycastResult RaycastUI(PointerEventData pointerEventData)
        {
            EventSystem eventSystem = EventSystem.current;
            RaycastResult raycastResult = new RaycastResult();

            if (eventSystem != null)
            {
                eventSystem.RaycastAll(pointerEventData, m_RaycastResults);

                if (m_RaycastResults.Count > 0)
                {
                    raycastResult = m_RaycastResults[0];
                }

                m_RaycastResults.Clear();
            }

            return raycastResult;
        }


        private List<RaycastResult> m_RaycastResults = new List<RaycastResult>();
    }
}