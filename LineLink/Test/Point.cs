using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace YDJ
{
    public class Point : MonoBehaviour
    {
        private XRGrabInteractable interactable;

        private void Start()
        {
            interactable = GetComponent<XRGrabInteractable>();
        }

        public void PointMove()
        {
            interactable.selectEntered.Equals(true);
        }
    }
}
