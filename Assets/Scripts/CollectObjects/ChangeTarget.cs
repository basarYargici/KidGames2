#region Libraries

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

#endregion

public class ChangeTarget : MonoBehaviour
{
    /*
     * Written by İBRAHİM BAŞAR YARGICI
     * 
     * Date: 02/10/2020
     * 
     * Purpose: Takes shape list and shuffles them. Finally sets the shuffled list to the exact target point.  
     */

    #region Variables

    public List<GameObject> shapes = new List<GameObject>();
    private List<GameObject> targetShapes = new List<GameObject>();
    private List<GameObject> shapesAfterMatched = new List<GameObject>();
    private int shapeSize;
    private int randomNumber;
    private GameObject tempGameObject;
    private Sprite sprite;
    private bool isShapeMatched = false;
    private MatchObjects matchObjects;
    private int random = 0;
    public AudioSource sound;
    [SerializeField]private float x = -3.35f, y = -1.13f;
    public bool shapeResizeNeeded = false;
    #endregion

    //private List<ShapeData> shapeList;


    private void Start()
    {
        sound = GetComponent<AudioSource>();
        shapeSize = shapes.Count;
        targetShapes = shapes;
        shapesAfterMatched = shapes;
        Shuffle();
        SetTarget();
    }

    private void Update()
    {
        /*
         * if there is a target and shape has already matched
         * first make sprite null and later remove the shape 
         */
        if (targetShapes.Count > 0)
        {
            if (matchObjects.GetIsLocked())
            {
                sound.Play();
                shapesAfterMatched[random].transform.position = new Vector3(x, y, 0);
                shapesAfterMatched[random].GetComponent<Renderer>().sortingOrder = 0;
                //shapes[random].GetComponent<SpriteRenderer>().sprite = null;
                shapes.RemoveAt(random);
                x--;
                SetTarget();
            }
        }
    }


    // Shuffles shapes GameObject array
    void Shuffle()
    {
        //shapeList = new List<ShapeData>(); 
        for (int i = 0; i < shapeSize; i++)
        {
            randomNumber = Random.Range(0, shapeSize - 1);
            tempGameObject = shapes[randomNumber];
            shapes[randomNumber] = shapes[i];
            shapes[i] = tempGameObject;
            //shapeList.Add(new ShapeData(i, shapes[i].GetComponent<SpriteRenderer>().sprite));
        }
    }


    // Sets target shape 
    private void SetTarget()
    {
        if (targetShapes.Count > 0)
        {
            random = Random.Range(0, targetShapes.Count - 1);
            if (shapeResizeNeeded)
            {
                Vector3 scale = targetShapes[random].transform.localScale;
                transform.localScale = scale*55;
            }
            GetComponent<SpriteRenderer>().sprite = targetShapes[random].GetComponent<SpriteRenderer>().sprite;
            matchObjects = targetShapes[random].GetComponent<MatchObjects>();
        }
    }
}