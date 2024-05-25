using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BGS.ProgrammerTask.UI
{
    public class UIHoverPopupCaller : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
    {
        [SerializeField]
       private Item_UI hoverItem;
        public void OnPointerEnter(PointerEventData eventData)
        {
            UIHoverPopup.Instance.OpenPopUp();
            UIHoverPopup.Instance.UpdatePopupContent(hoverItem.GetItem.GetName, 
                hoverItem.GetItem.GetDescription, hoverItem.GetItem.GetValue.ToString());
            UIHoverPopup.Instance.UpdatePopupPosition(eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            UIHoverPopup.Instance.ClosePopUp();
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            // Actualizar la posición del popup mientras se mueve el mouse
            // Ocultar el popup
            UIHoverPopup.Instance.UpdatePopupPosition(eventData);
        }
    }
}
