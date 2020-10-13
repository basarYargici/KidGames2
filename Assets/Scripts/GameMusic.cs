using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
* Written by İBRAHİM BAŞAR YARGICI
* 
* Date: 05/10/2020
* 
* Purpose: Instantiates (balloon) prefabs between given x and y axis ranges.
*/
public class GameMusic : MonoBehaviour
{
    private int buildIndex;
    [SerializeField] private int playUntilScene; 

    private void Update()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        
        SetUpSingleton();
    }

    
    private void SetUpSingleton()
    {
        // if (FindObjectsOfType(GetType()).Length>1) 
        // {
        //     Destroy(gameObject);
        // }
        if (buildIndex > playUntilScene)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}