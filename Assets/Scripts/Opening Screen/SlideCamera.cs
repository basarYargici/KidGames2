using UnityEngine;

/*
 * Written by İBRAHİM BAŞAR YARGICI
 * 
 * Date: 02/10/2020
 * Last update: 08/10/2020
 * 
 * Purpose: Sliding camera to the given positions by given Vector3 target positions.
 */
public class SlideCamera : MonoBehaviour
{
    //You should give 1 number bigger values for targetVectors 

    [SerializeField] private Camera mainCamera;
    [SerializeField] private Vector3 targetDownVector3;

    [SerializeField] private Vector3 targetUpVector3;

    //Speed of sliding down or up
    [SerializeField] private float speed = 2.5f;

    //Three scenes has been used for opening screen so to give properly screen
    //you should use specific indexes  
    [SerializeField] private int openingScreenIndex;
    private bool _isPlayClicked;

    private bool _isGoUpClicked;
    // private bool isButtonClicked = false;

    private void Start()
    {
        if (openingScreenIndex == 1)
        {
            StartMovementDown();
        }
        else if (openingScreenIndex == 2)
        {
            StartMovementUp();
        }
    }

    public void StartMovementDown()
    {
        if (!_isPlayClicked)
        {
            _isPlayClicked = true;
            _isGoUpClicked = false;
        }
    }

    public void StartMovementUp()
    {
        if (!_isGoUpClicked)
        {
            _isGoUpClicked = true;
            _isPlayClicked = false;
        }
    }

    private void FixedUpdate()
    {
        if (_isPlayClicked)
        {
            MoveCameraDown();
        }

        if (_isGoUpClicked)
        {
            MoveCameraUp();
        }
    }

    private void MoveCameraDown()
    {
        var position = mainCamera.transform.position;
        if (position.y - targetDownVector3.y >= 1)
        {
            position = Vector3.Lerp(position,
                targetDownVector3, Time.deltaTime * speed);
            mainCamera.transform.position = position;
        }
        else
        {
            _isPlayClicked = false;
        }
    }

    private void MoveCameraUp()
    {
        var position = mainCamera.transform.position;
        if (targetUpVector3.y - position.y >= 1)
        {
            position = Vector3.Lerp(position,
                targetUpVector3, Time.deltaTime * speed);
            mainCamera.transform.position = position;
        }
        else
        {
            _isGoUpClicked = false;
        }
    }
}