using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CellKeyManager : MonoBehaviour
{
    public bool socketCheck;
    public bool SocketCheck {  get { return socketCheck; } }
    [SerializeField] CellBox cellBox;

    public void OnSeletEnter(SelectEnterEventArgs args)
    {
        socketCheck = true;
        cellBox.OpenBox();
    }

    public void OnSeletExit(SelectExitEventArgs args)
    {
        socketCheck = false;
    }
}
