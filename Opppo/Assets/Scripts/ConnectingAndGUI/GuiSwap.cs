using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiSwap : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject RegCanvas;
    public GameObject LogCanvas;

    public void clickBack()
    {
        RegCanvas.SetActive(false);
        LogCanvas.SetActive(true);
    }
    public void ClickSingUp()
    {
        RegCanvas.SetActive(true);
        LogCanvas.SetActive(false);
    }
}
