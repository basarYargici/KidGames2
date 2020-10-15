using System.Collections;
using UnityEngine;

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
    
    void Start()
    {
        image = GetComponent<SpriteRenderer>();
        imageColor = image.color;
        imageColor.a = 0f;    // setting the color opaque 
        image.color = imageColor;
        StartCoroutine(FadeIn());
    }


    IEnumerator FadeIn()
    {
        while(imageColor.a <0.8f){
            imageColor.a +=Time.deltaTime/3;   //increasing the alpha 
            image.color = imageColor;     //fades out over 1 second. change to += to fade in    
            yield return null;
        }
    }
}