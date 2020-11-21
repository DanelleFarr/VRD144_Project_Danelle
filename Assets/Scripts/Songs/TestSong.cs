using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSong : MonoBehaviour
{
    [SerializeField]
    private RhythmStucture[] song = new RhythmStucture[20];

    public RhythmStucture[] Song { get { return song; } }
}
