using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeCanvasTextColor : MonoBehaviour
{
    [SerializeField]
    private Color color = Color.white;
    [SerializeField]
    private TextMeshProUGUI myCanvas;

    public void ChangeTextColor()
    {
        myCanvas.color = color;
    }

}
