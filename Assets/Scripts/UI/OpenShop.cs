using BGS.ProgrammerTask.NPC;
using BGS.ProgrammerTask.Utilities;
using UnityEngine;

namespace BGS.ProgrammerTask.UI
{
    public class OpenShop : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _shopPanel;
        [SerializeField]
        private OpenInventory _inventoryPanel;
        [SerializeField]
        private Interactable _interactable;
        [SerializeField]
        private float _fadeDuration = .1f;

        private void Start()
        {
            _interactable.OnInteract += OpenMenu;
            _shopPanel.gameObject.SetActive(false); 
        }

        private void OnDestroy()
        {
            _interactable.OnInteract -= OpenMenu;

        }
        void Update()
        {
            if ((Input.GetKeyDown(KeyCode.I) ||Input.GetKeyDown(KeyCode.Escape)) && _shopPanel.gameObject.activeSelf)
            {
                CloseMenu();
            }
            if(!_interactable.PlayerIsInRange && _shopPanel.gameObject.activeSelf)
            {
                CloseMenu();
            }
        }

        void OpenMenu()
        {
            if (_shopPanel.gameObject.activeSelf)
                return;
            StartCoroutine(Utils.FadeCanvasGroup(_shopPanel, 0f, 1f, _fadeDuration));

            _inventoryPanel.OpenMenu();
        }

        void CloseMenu()
        {
            StartCoroutine(Utils.FadeCanvasGroup(_shopPanel, 1f, 0f, _fadeDuration));

            _inventoryPanel.CloseMenu();
            UIHoverPopup.Instance.ClosePopUp();

        }
    }

}
