using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BGS.ProgrammerTask.UI
{
    public class ShopkeeperFlavorText : MonoBehaviour
    {

        [SerializeField]
        private TMPro.TextMeshProUGUI UITextMeshPro;
        [SerializeField]
        private DropZone _zone;
        [SerializeField]
        private string _defaultText = "Hello, please check out our latest products...";
        [SerializeField]
        private string _noGoldText = "You gotta need more gold to buy that...";
        protected virtual void Awake()
        {
            _zone.OnRemoveFailed += OnRemoveFailed;
        }

        private void OnRemoveFailed(Draggable draggable)
        {
            UITextMeshPro.text = _noGoldText;
        }

        private void OnDisable()
        {
            UITextMeshPro.text = _defaultText;
        }

        private void OnDestroy()
        {
            _zone.OnRemoveFailed -= OnRemoveFailed;

        }
    }
}
