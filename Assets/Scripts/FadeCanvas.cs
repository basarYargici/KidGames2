using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Written by İBRAHİM BAŞAR YARGICI
 * 
 * Date: 16/10/2020
 * 
 * Purpose: After the player matches all the objects, canvas fades in slowly. 
 */
public class FadeCanvas : MonoBehaviour
{
    private SpriteRenderer image;
    private Color imageColor;
    [SerializeField]private ChangeScene change;
    private int activeSceneIndex,openScene;
    [SerializeField]private int sceneNumber;
    void Start()
    {
        //change = gameObject.AddComponent<ChangeScene>();
       // activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        openScene = activeSceneIndex + 1;
        image = GetComponent<SpriteRenderer>();
        imageColor = image.color;
        imageColor.a = 0f;    // setting the color opaque 
        image.color = imageColor;
        StartCoroutine(FadeIn());
        StartCoroutine(changeScene());
    }


    IEnumerator FadeIn()
    {
        while(imageColor.a <0.8f){
            imageColor.a +=Time.deltaTime/3;   //increasing the alpha 
            image.color = imageColor;     //fades out over 1 second. change to += to fade in    
            yield return null;
        }
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(7);
        if (sceneNumber != 0)
        {
            change.openNewScene(sceneNumber);
        }
        else
        {
            change.openNextScene();
        }
    }
}