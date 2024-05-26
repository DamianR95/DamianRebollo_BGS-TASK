using UnityEngine;
namespace BGS.ProgrammerTask.Utilities
{
    public class CanvasReference : MonoBehaviour
    {
        private static CanvasReference instance;

        public static CanvasReference Instance => instance;
        [SerializeField]
        private Canvas _Canvas;
        [SerializeField]
        private RectTransform _CanvasRect;
        public Canvas GetCanvas() { return _Canvas; }
        public RectTransform GetCanvasRect() { return _CanvasRect; }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}