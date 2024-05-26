using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using BGS.ProgrammerTask.Utilities;
namespace BGS.ProgrammerTask.UI
{
    public class UIHoverPopup : MonoBehaviour
    {
        [SerializeField]
        private RectTransform _popup;
        [SerializeField]
        private CanvasGroup _popupCanvasGroup;
        [SerializeField]
        private TextMeshProUGUI _nameText;
        [SerializeField]
        private TextMeshProUGUI _descriptionText;
        [SerializeField]
        private TextMeshProUGUI _valueText;
        [SerializeField]
        private float fadeDuration = .1f;

        private static UIHoverPopup instance;
       

        public static UIHoverPopup Instance => instance;

        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            _popup.gameObject.SetActive(false);
           // ClosePopUp();
        }
        public void OpenPopUp() { 
            //_popup.gameObject.SetActive(true);
            StartCoroutine(Utils.FadeCanvasGroup(_popupCanvasGroup, 0f, 1f, fadeDuration));

        }
        public void ClosePopUp()
        {
            //_popup.gameObject.SetActive(false);
            StartCoroutine(Utils.FadeCanvasGroup(_popupCanvasGroup, 1f, 0f, fadeDuration));

        }

        public void UpdatePopupContent(string desc)
        {
            _nameText.text = string.Empty;
            _descriptionText.text = desc;
            _valueText.text = string.Empty;
        }
        public void UpdatePopupContent(string name, string desc, string value)
        {
            _nameText.text = name;
            _descriptionText.text = desc;
            _valueText.text = "Value: " + value.ToString();
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
                    _popup.pivot = new Vector2(0, 0);
                }
                else
                {
                    _popup.pivot = new Vector2(0, 1);
                }
            }
            else
            {
                if (eventData.position.y < screenCenter.y)
                {
                    _popup.pivot = new Vector2(1, 0);
                }
                else
                {
                    _popup.pivot = new Vector2(1, 1);
                }
            }

        _popup.transform.position = transform.TransformPoint(position); 
        }
    }
}