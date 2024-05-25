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
            ClosePopUp();
        }
        public void OpenPopUp() { 
            popup.gameObject.SetActive(true);
        }
        public void ClosePopUp()
        {
            popup.gameObject.SetActive(false);

        }

        public void UpdatePopupContent(string name, string desc, string value)
        {
            nameText.text = name;
            descriptionText.text = desc;
            valueText.text = "Value: " + value.ToString();
        }

        public void UpdatePopupPosition(PointerEventData eventData)
        {
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
                }
                else
                {
                    popup.pivot = new Vector2(0, 1);
                }
            }
            else
            {
                if (eventData.position.y < screenCenter.y)
                {
                    popup.pivot = new Vector2(1, 0);
                }
                else
                {
                    popup.pivot = new Vector2(1, 1);
                }
            }

        popup.transform.position = transform.TransformPoint(position); 
        }
    }
}