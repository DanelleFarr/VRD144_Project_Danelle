using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongMenuManager : MonoBehaviour
{
    [SerializeField]
    private SongInfo globalSongInfo;
    [SerializeField]
    Button Per_PractButton;
    [SerializeField]
    Button Str_PractButton;
    [SerializeField]
    Button Plu_PractButton;
    [SerializeField]
    Button Bra_PractButton;
    [SerializeField]
    Button Win_PractButton;
    [SerializeField]
    Button Key_PractButton;
    [SerializeField]
    Button Voc_PractButton;


    // Start is called before the first frame update
    void Start()
    {
        if(globalSongInfo.stringsOn == true)
        {
            Str_PractButton.interactable = true;
        }
        if (globalSongInfo.pluckedOn == true)
        {
            Plu_PractButton.interactable = true;
        }
        if (globalSongInfo.brassOn == true)
        {
            Bra_PractButton.interactable = true;
        }
        if (globalSongInfo.windOn == true)
        {
            Win_PractButton.interactable = true;
        }
        if (globalSongInfo.keyboardOn == true)
        {
            Key_PractButton.interactable = true;
        }
        if (globalSongInfo.vocalOn == true)
        {
            Voc_PractButton.interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadScene (string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }
}
