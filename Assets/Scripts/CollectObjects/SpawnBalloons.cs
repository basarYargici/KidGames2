using UnityEngine;

/*
 * Written by İBRAHİM BAŞAR YARGICI
 * 
 * Date: 05/10/2020
 * 
 * Purpose: Instantiates (balloon) prefabs between given x and y axis ranges.
 */
public class SpawnBalloons : MonoBehaviour
{
    public GameObject prefab;
    public MatchObjectCounter matchObjectCounter;
    public int shapeSize;
    private Vector3 spawningPosition;
    private int balloonCount;

    // Start is called before the first frame update
    void Start()
    {
        balloonCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;

        spawningPosition = new Vector3(Random.Range(-8,9), Random.Range(position.y-2,position.y+1), position.z);

        if (matchObjectCounter.GetMatchedObjectCount() == shapeSize)
        {
            InvokeRepeating("SpawnObject", 0, 2);
        }
    }

    public void SpawnObject()
    {
        if (balloonCount < 10)
        {
            Instantiate(prefab, spawningPosition, Quaternion.identity);
            balloonCount++;
        }
    }
    
}