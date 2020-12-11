using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SongInfo : ScriptableObject
{
    [SerializeField]
    private string songName;    

    public string SongName
    {
        get { return songName; }
        set { songName = value; }
    }
}
