using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCanvasManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI notesCanvas;
    [SerializeField]
    private Color color;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Change the Text on the notesCanvas
    
    //Change the Text of the canvas
    public void PrintText(string output)
    {
        notesCanvas.text = output;
    }//end PrintText()

   //change the color of the canvas text
    public void ChangeTextColor(Color color)
    {
        notesCanvas.color = color;
    }
}
