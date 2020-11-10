using UnityEngine;

[System.Serializable]
public class RhythmStucture
{
    [SerializeField]
    GameObject notePrefab;
    /// <summary>
    /// Time in seconds along the
    /// song timeline
    /// </summary>
    [SerializeField]
    float timeStamp = 1f;
    [SerializeField]
    Transform startPos;
    [SerializeField]
    Transform endPos;


    public float TimeStamp
    {
        get { return timeStamp; }
    }

    public GameObject NotePrefab
    {
        get { return notePrefab; }
    }

    public Transform StartPos
    {
        get { return startPos; }
    }

    public Transform EndPos
    {
        get { return endPos; }
    }
}
