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
    private int buildIndex,startIndex;
    [SerializeField] private int playUntilSceneIndex;

    private void Start()
    {
        startIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        
        SetUpSingleton();
    }

    
    private void SetUpSingleton()
    {
        if (buildIndex > playUntilSceneIndex || buildIndex < startIndex)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}