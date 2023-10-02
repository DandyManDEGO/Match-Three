using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public static SwipeDetection Instance;
    private Vector2 mouseDownPosition;
    private Vector2 mouseUpPosition;
    private DirectionSwipe direction;
    private bool detectSwipeOnlyAfterRelease = false;
    private float minDistanceForSwipe = 20f;
    private void Start()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Update()
    {
        DetectSwipe();
    }
    public DirectionSwipe ReturnDirection()
    {
        return direction;
    }
    private void DetectSwipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDownPosition = Input.mousePosition;
            mouseUpPosition = Input.mousePosition;
        }

        if (!detectSwipeOnlyAfterRelease && Input.GetMouseButton(0))
        {
            mouseUpPosition = Input.mousePosition;
            CheckSwipe();
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseUpPosition = Input.mousePosition;
            CheckSwipe();
        }
    }

    private void CheckSwipe()
    {
        float deltaX = mouseUpPosition.x - mouseDownPosition.x;
        float deltaY = mouseUpPosition.y - mouseDownPosition.y;

        if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
        {
            if (deltaX > minDistanceForSwipe)
            {
                direction = DirectionSwipe.Right;
            }
            else if (deltaX < -minDistanceForSwipe)
            {
                direction = DirectionSwipe.Left;
            }
        }
        else
        {
            if (deltaY > minDistanceForSwipe)
            {
                direction = DirectionSwipe.Up;
            }
            else if (deltaY < -minDistanceForSwipe)
            {
                direction = DirectionSwipe.Down;
            }
        }
    }
}
public enum DirectionSwipe
{
    Left, Right, Up, Down
}