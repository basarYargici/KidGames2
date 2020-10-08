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
    [SerializeField] private string scene;

    public void openNewScene(int sceneNumber) {
        //SceneManager.LoadScene("Scenes/ShapeMatchAnimals");
        SceneManager.LoadScene(sceneNumber);
    }
}