using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongMenuManager : MonoBehaviour
{

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
