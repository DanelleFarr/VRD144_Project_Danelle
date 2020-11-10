using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerscussionNote : NoteBluePrint
{
    public bool topHit = false;

    public void ToggleTopHit()
    {
        topHit = !topHit;
    }

    public void BtmHitCheck()
    {
        if (topHit) 
        {
            Destroy(this);
            Debug.Log("Score increased! ...once score is added");
        } 
        else { ToggleTopHit(); }
    }//end CheckHitDirection()
}
