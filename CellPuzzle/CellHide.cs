using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace YDJ
{
    public class CellHide : MonoBehaviour
    {
        [SerializeField] Material visibleMat;
        [SerializeField] XRGrabInteractable hideGrab;
        [SerializeField] CellRay cellRay;

        public void HideGrabOn()
        {
            hideGrab.enabled = true;
        }

        public void HideGrabOff()
        {
            hideGrab.enabled = false;
        }

        public void Select() //ChangeMat
        {
            gameObject.GetComponent<Renderer>().material = visibleMat;
            cellRay.enabled = false;
        }

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (cellHideLayer.Contain(other.gameObject.layer))
        //    {
        //        hideGrab.enabled = true;
        //    }
        //}

        //private void OnTriggerExit(Collider other)
        //{
        //    if (grabCheck)
        //        return;

        //    if (cellHideLayer.Contain(other.gameObject.layer))
        //    {
        //        hideGrab.enabled = false;
        //    }
        //}
    }


}
