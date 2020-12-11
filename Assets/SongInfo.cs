using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SongInfo : ScriptableObject
{
    [SerializeField]
    private string songName;

    public bool stringsOn = false;
    public bool pluckedOn = false;
    public bool brassOn = false;
    public bool windOn = false;
    public bool keyboardOn = false;
    public bool vocalOn = false;
    public string SongName
    {
        get { return songName; }
        set { songName = value; }
    }

    public void SetStringsOn()
    {
        stringsOn = true;
    }
    public void SetPluckedOn()
    {
        pluckedOn = true;
    }
    public void SetBrassOn()
    {
        brassOn = true;
    }
    public void SetWindOn()
    {
        windOn = true;
    }
    public void SetKeyboardOn()
    {
        keyboardOn = true;
    }
    public void SetVocalOn()
    {
        vocalOn = true;
    }
}
