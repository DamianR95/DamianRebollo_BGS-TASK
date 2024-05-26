using UnityEngine;

namespace BGS.ProgrammerTask.Systems
{
    public class CloseGame :MonoBehaviour
    {
        public void CloseApplication() { 
            Application.Quit();
        }
    }
}
