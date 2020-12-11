using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlacedMusicManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI PlaySongCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PrintText(string output)
    {
        PlaySongCanvas.text = output;
    }//end PrintText()
}
