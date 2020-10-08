using System.Collections;
using UnityEngine;

/*
 * Written by İBRAHİM BAŞAR YARGICI
 * 
 * Date: 05/10/2020
 * 
 * Purpose: Add forces to balloon prefabs to move up.
 * Gives Audio to them for playing when balloon popped.
 */

public class Balloon : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private AudioSource audio;

    public Vector3 force;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

        rigidBody = GetComponent<Rigidbody2D>();
        force = new Vector3(Random.Range(-15f, 15f), Random.Range(20f, 30f));
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.AddForce(force * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        audio.Play();
        StartCoroutine(WaitForDestroy());
    }

    IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}