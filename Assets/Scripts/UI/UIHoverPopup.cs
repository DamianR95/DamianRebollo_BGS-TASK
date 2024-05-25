using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
namespace BGS.ProgrammerTask.UI
{
    public class UIHoverPopup : MonoBehaviour
    {
        public RectTransform popup;
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI descriptionText;
        public TextMeshProUGUI valueText;

        private static UIHoverPopup instance;

        public static UIHoverPopup Instance => instance;

        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            popup.gameObject.SetActive(false);
        }

      

        public void UpdatePopupContent(string name, string desc, string value)
        {
            // Actualizar el contenido del popup con la información del ítem
            nameText.text = name;
            descriptionText.text = desc;
            valueText.text = "Value: " + value.ToString();
        }

        public void UpdatePopupPosition(PointerEventData eventData)
        {
            // Posicionar el popup al lado del cursor
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                transform as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out position);

            Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
            if (eventData.position.x < screenCenter.x)
            {
                if (eventData.position.y < screenCenter.y)
                {
                    popup.pivot = new Vector2(0, 0);
                    //currentQuadrant = Quadrant.BottomLeft;
                }
                else
                {
                    popup.pivot = new Vector2(0, 1);
                    //currentQuadrant = Quadrant.TopLeft;
                }
            }
            else
            {
                if (eventData.position.y < screenCenter.y)
                {
                    popup.pivot = new Vector2(1, 0);
                    //  currentQuadrant = Quadrant.BottomRight;
                }
                else
                {
                    popup.pivot = new Vector2(1, 1);
                    // currentQuadrant = Quadrant.TopRight;
                }
            }

        popup.transform.position = transform.TransformPoint(position); 
        }
    }
}