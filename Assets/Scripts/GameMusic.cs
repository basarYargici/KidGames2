using UnityEngine;
/*
* Written by İBRAHİM BAŞAR YARGICI
* 
* Date: 05/10/2020
* 
* Purpose: Instantiates (balloon) prefabs between given x and y axis ranges.
*/
public class GameMusic : MonoBehaviour
{
    void Awake()
    {
        SetUpSingleton();
    }
 
    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length>1)
        {
            Destroy(gameObject);
 
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
 
}