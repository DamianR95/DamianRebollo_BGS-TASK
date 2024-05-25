using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BGS.ProgrammerTask.Utilities
{
    public class CanvasReference : MonoBehaviour
    {
        public static CanvasReference instance;
        [SerializeField]
        private Canvas _Canvas;
        public Canvas GetCanvas() { return _Canvas; }
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