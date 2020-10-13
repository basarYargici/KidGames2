using UnityEngine;

/*
 * Written by İBRAHİM BAŞAR YARGICI
 * 
 * Date: 03/10/2020
 * 
 * Purpose: Activating (winning) canvas when all shapes matched (shapeCount).
 */
public class ActivateCanvas : MonoBehaviour
{
    public MatchObjectCounter matchObjectCounter;

    public GameObject canvas;

    public int shapeCount;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (matchObjectCounter.GetMatchedObjectCount() == shapeCount)
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }
    }
}