using System;
using Unity.Mathematics;
using UnityEngine;

/*
 * Written by İBRAHİM BAŞAR YARGICI
 * 
 * Date: 12/10/2020
 * 
 * Purpose: With player touch to the object, object moves. Checks if target matched.
 */
public class MatchObject : MonoBehaviour
{
    #region Variables

    public GameObject target;

    private Vector2 initialPosition;

    private Vector2 mousePosition;

    private bool isLocked;

    //public ParticleSystem particle;

    public MatchObjectCounter matchObjectCounter;

    private Vector3 offset;

    #endregion


    public void SetIsLocked(bool isLocked)
    {
        this.isLocked = isLocked;
    }

    public bool GetIsLocked()
    {
        return isLocked;
    }

    private void Start()
    {
        //particle.GetComponent<Renderer>().sortingOrder = 2;
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (isLocked)
        {
            GetComponent<Renderer>().sortingLayerName = "Background";
            GetComponent<Renderer>().sortingOrder = 2;
        }
    }


    void OnMouseDown()
    {
        offset = gameObject.transform.position -
                 Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
    }


    private void OnMouseDrag()
    {
        /*
         * if the shape has not locked drag the shape with input
         */
        if (!isLocked)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
            // ParticleSystem();
        }
    }
/*
    void ParticleSystem()
    {
        //Instantiate our one-off particle system
        var explosionEffect = Instantiate(particle, transform.position, quaternion.identity);
        // explosionEffect.transform.position = transform.position;
        //play it
        explosionEffect.loop = false;
        explosionEffect.Play();

        //destroy the particle system when its duration is up, right
        Destroy(explosionEffect.gameObject, 0.5f);
    }
*/

    private void OnMouseUp()
    {
        /*
         * if shape's transform and target's transform are close and sprite names are the same
         * then lock the shape to target
         * else take the shape to the first position 
         */
        if (Math.Abs(transform.position.x - target.transform.position.x) <= 1
            &&
            Math.Abs(transform.position.y - target.transform.position.y) <= 1
            &&
            target.GetComponent<SpriteRenderer>().sprite.name == GetComponent<SpriteRenderer>().sprite.name
        )
        {
            var position = target.transform.position;
            transform.position = new Vector3(position.x, position.y + 1.1f);
            isLocked = true;

            matchObjectCounter.IncreaseMatchedObjectCount();

            Debug.Log(matchObjectCounter.GetMatchedObjectCount());
        }
        else if (!isLocked)
        {
            transform.position = new Vector3(initialPosition.x, initialPosition.y);
        }
    }
}