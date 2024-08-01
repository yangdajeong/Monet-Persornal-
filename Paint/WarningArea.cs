using UnityEngine;

namespace YDJ
{
    public class WarningArea : MonoBehaviour
    {
        private bool warningCheck = false;
        public bool WarningCheck { get { return warningCheck; } set { warningCheck = value; } }

        private void OnTriggerExit(Collider other)
        {
            warningCheck = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            warningCheck = false;
        }
    }
}
