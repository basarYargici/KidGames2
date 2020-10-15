using UnityEngine;

public class UpDownAnim : MonoBehaviour
{
    public MatchObject matchObjects;
    public float speed = 0.5f;

    private float topPoint, bottomPoint;
    private bool islocked, isUpMovementDone;
    private Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        topPoint = startPosition.y + 0.5f;
        bottomPoint = startPosition.y - 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        islocked = matchObjects.GetIsLocked();
        if (!islocked)
        {
            moveUpAndBottom();
        }
    }

    void moveUpAndBottom()
    {
        var position = transform.position;

        if (!isUpMovementDone)
        {
            transform.Translate(Vector3.up * (speed * Time.deltaTime));
        }
        else
        {
            transform.Translate(-Vector3.up * (speed * Time.deltaTime));
        }

        if (position.y >= topPoint)
        {
            isUpMovementDone = true;
        }

        if (position.y <= bottomPoint)
        {
            isUpMovementDone = false;
        }
    }
}