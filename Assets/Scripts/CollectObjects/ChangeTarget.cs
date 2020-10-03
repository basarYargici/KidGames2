
#region Libraries
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
#endregion

public class ChangeTarget : MonoBehaviour
{
    #region Variables 
    public List<GameObject> shapes = new List<GameObject>();
    public List<GameObject> targetShapes = new List<GameObject>();
    private int shapeSize;
    private int randomNumber;
    private GameObject tempGameObject;
    private Sprite sprite;
    private bool isShapeMatched = false;
    private MatchObjects matchObjects;
    private int random = 0;

    #endregion

    //private List<ShapeData> shapeList;
   

    private void Start()
    {
        shapeSize = shapes.Count;
        targetShapes = shapes;
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
                shapes[random].GetComponent<SpriteRenderer>().sprite = null;
                shapes.RemoveAt(random);
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
            GetComponent<SpriteRenderer>().sprite = targetShapes[random].GetComponent<SpriteRenderer>().sprite;
            matchObjects = targetShapes[random].GetComponent<MatchObjects>();
        }
    }

    
    

}