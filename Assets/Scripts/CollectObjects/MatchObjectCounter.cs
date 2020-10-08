using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Written by İBRAHİM BAŞAR YARGICI
 * 
 * Date: 05/10/2020
 * 
 * Purpose: Counting matched objects.
 */
public class MatchObjectCounter : MonoBehaviour
{
    private int matchedObjectCount;

    public int GetMatchedObjectCount()
    {
        return matchedObjectCount;
    }
    public void IncreaseMatchedObjectCount()
    {
        matchedObjectCount++;
    }
}
