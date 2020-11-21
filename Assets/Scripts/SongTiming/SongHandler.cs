using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SongHandler : MonoBehaviour
{
    [SerializeField]
    public RhythmStucture[] notes;
    [SerializeField]
    private int currNote = 0;
    //[SerializeField]
    //private float songTime = 0f;
    [SerializeField]
    public float spawnDistMod = 2f;
    [SerializeField]
    private SongSocket songReader;
    [SerializeField]
    private bool songIsPlaying = false;
    
    private void Start()
    {
       
    }

    private void Update()
    {
        //songTime += Time.deltaTime;

    }


    public void PlaySong(RhythmStucture[] notes)
    {
        foreach (RhythmStucture note in notes)
        {
            GameObject go = Instantiate(note.NotePrefab.gameObject, note.StartPos.position, note.StartPos.rotation);
            go.transform.Translate(0, 0, note.TimeStamp * spawnDistMod);
            StartCoroutine(go.GetComponent<NoteBluePrint>().MoveToTarget(note.EndPos, note.TimeStamp));
        }
    }//end PlaySong()
    private IEnumerator SpawnNote(RhythmStucture note)
    {
        GameObject go = Instantiate(note.NotePrefab.gameObject, note.StartPos.position, note.StartPos.rotation);
        go.transform.Translate(0, 0, note.TimeStamp);
        Vector3 startPos = go.transform.position;
        Vector3 endPos = note.EndPos.position;

        float elapsedTime = 0f;

        while(elapsedTime < note.TimeStamp)
        {
            go.transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / note.TimeStamp);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(go);
    }

    // Spawn note
    
    // Move from spawn to target in proper time


}
