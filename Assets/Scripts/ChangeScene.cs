using System;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Written by İBRAHİM BAŞAR YARGICI
 * 
 * Date: 03/10/2020
 * 
 * Purpose: Changes scene to the given scene index.
 */

public class ChangeScene : MonoBehaviour {
    public void openNewScene(int sceneNumber) {
        //SceneManager.LoadScene("Scenes/ShapeMatchAnimals");
        SceneManager.LoadScene(sceneNumber);
    }

    public void openNewSceneViaName(String sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void openNextScene()
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        index++;
        SceneManager.LoadScene(index);
    }
    public void exitGame()
    {
        Application.Quit();
    }
}