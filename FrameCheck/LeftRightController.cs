using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace YDJ
{
    public class LeftRightController : MonoBehaviour
    {
        [SerializeField] Transform left;
        [SerializeField] Transform right;
        [SerializeField] XRGrabInteractable Interactable;
        [SerializeField] int selectCount;

        private void Awake()
        {
            Interactable = GetComponent<XRGrabInteractable>();
            if (Interactable != null)
            {
                //Interactable.selectEntered.AddListener(OnSelect);
                //Interactable.selectExited.AddListener(OnSelectExit);
                //Interactable.onHoverEnter.AddListener(OnHoverEntered);
            }
        }

        public void OnSelect(SelectEnterEventArgs args)
        {
            //selectCount++;

            XRGrabInteractable interactable = args.interactableObject.transform.GetComponent<XRGrabInteractable>();
            //if (selectCount == 1)
            {

                if (args.interactorObject.transform.parent.name == "Left Controller")
                {
                    if (interactable == null)
                        return;

                    interactable.attachTransform = left;
                }
                else if (args.interactorObject.transform.parent.name == "Right Controller")
                {
                    if (interactable == null)
                        return;

                    interactable.attachTransform = right;
                }
            }
            //else
            //{
            //    if (args.interactorObject.transform.parent.name == "Left Controller")
            //    {
            //        if (interactable == null)
            //            return;

            //        interactable.secondaryAttachTransform = left;
            //    }
            //    else if (args.interactorObject.transform.parent.name == "Right Controller")
            //    {
            //        if (interactable == null)
            //            return;

            //        interactable.secondaryAttachTransform = right;
            //    }
            //}
            //}
            //public void OnSelectExit(SelectExitEventArgs args)
            //{
            //    selectCount--;

            //    if (selectCount != 1)
            //        return;

            //    XRGrabInteractable interactable = args.interactableObject.transform.GetComponent<XRGrabInteractable>();

            //    if (args.interactorObject.transform.parent.name == "Left Controller")
            //    {
            //        interactable.attachTransform = right;
            //    }
            //    else if (args.interactorObject.transform.parent.name == "Right Controller")
            //    {
            //        interactable.attachTransform = left;
            //    }
            //}

            //    public void OnHoverEntered(XRBaseInteractor arg)
            //{
            //    XRGrabInteractable interactable = arg.interactableObject.transform.GetComponent<XRGrabInteractable>();

            //    if (arg.interactorObject.transform.parent.name == "Left Controller")
            //    {
            //        if (interactable == null)
            //            return;

            //        interactable.attachTransform = left;
            //    }
            //    else if (arg.interactorObject.transform.parent.name == "Right Controller")
            //    {
            //        if (interactable == null)
            //            return;

            //        interactable.attachTransform = right;
            //    }
            //}
        }
    }
}

