﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MatchObjects : MonoBehaviour
{
    
    #region  Variables

    public GameObject target;

    private Vector2 initialPosition;

    private Vector2 mousePosition;

    private bool isLocked = false;

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
        initialPosition = transform.position;
    }

    private void OnMouseDrag()
    {
/*
 * if the shape has not locked
 * drag the shape with input
 */
        if (!isLocked)
        {
            if (Camera.main != null)
            {
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            transform.position = new Vector3(mousePosition.x, mousePosition.y);
        }
    }


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
            transform.position = new Vector3(position.x, position.y);
            isLocked = true;
        }
        else
        {
            transform.position = new Vector3(initialPosition.x, initialPosition.y);
        }
    }
}