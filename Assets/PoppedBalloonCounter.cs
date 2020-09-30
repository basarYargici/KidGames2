using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoppedBalloonCounter : MonoBehaviour {
    private int poppedBalloonCount = 0;

    public int GetPoppedBalloonCount() {
        return poppedBalloonCount;
    }

    public void SetPoppedBalloonCount(int count) {
        this.poppedBalloonCount = count;
    }


}