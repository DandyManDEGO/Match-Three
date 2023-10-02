using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemMatch3 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private FieldMatch3 fieldMatch;
    public LayerMask targetLayerMask;
    public float shootingDistance = 10f;
    private void Start()
    {
        fieldMatch = FindObjectOfType<FieldMatch3>();
        Invoke("Check", 1f);
    }
    private void FixedUpdate()
    {
        Check();
    }
    public void Check()
    {
        print("CHECK");
        CheckHorizontal();
        CheckVertical();
    }
    private void CheckHorizontal()
    {
        bool isLeftToo = ShootRaycast(Vector2.left);
        bool isRightToo = ShootRaycast(Vector2.right);
        if (isLeftToo == true && isRightToo == true)
        {
            print("������������� �������");
            DestroyHorizonatal();
        }
    }
    private void CheckVertical()
    {
        bool isDownToo = ShootRaycast(Vector2.down);
        bool isUpToo = ShootRaycast(Vector2.up);
        if (isUpToo == true && isDownToo == true)
        {
            DestroyVertical();
        }
    }
    private void DestroyHorizonatal()
    {
        fieldMatch.PlusScore();
        var itemLeft = fieldMatch.ReturnNewItem();
        itemLeft.transform.position = ShootRaycastForDestroy(Vector2.left).transform.position;
        var itemRight = fieldMatch.ReturnNewItem();
        itemRight.transform.position = ShootRaycastForDestroy(Vector2.right).transform.position;
        var itemCurrent = fieldMatch.ReturnNewItem();
        itemCurrent.transform.position = transform.position;
        Destroy(ShootRaycastForDestroy(Vector2.left));
        Destroy(ShootRaycastForDestroy(Vector2.right));
        Destroy(gameObject);
    }
    private GameObject ShootRaycastForDestroy(Vector2 direction)
    {
        gameObject.layer = 0;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, shootingDistance, targetLayerMask);
        gameObject.layer = 3;
        return hit.transform.gameObject;
    }
    private void DestroyVertical()
    {
        fieldMatch.PlusScore();
        var itemUp = fieldMatch.ReturnNewItem();
        itemUp.transform.position = ShootRaycastForDestroy(Vector2.up).transform.position;
        var itemDown = fieldMatch.ReturnNewItem();
        itemDown.transform.position = ShootRaycastForDestroy(Vector2.down).transform.position;
        var itemCurrent = fieldMatch.ReturnNewItem();
        itemCurrent.transform.position = transform.position;
        Destroy(ShootRaycastForDestroy(Vector2.up));
        Destroy(ShootRaycastForDestroy(Vector2.down));
        Destroy(gameObject);
    }
    private bool ShootRaycast(Vector2 direction)
    {
        gameObject.layer = 0;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, shootingDistance, targetLayerMask);
        gameObject.layer = 3;
        if (hit.collider != null)
        {
            if (hit.collider.tag == transform.tag)
            {
                return true;
            }
        }
        return false;
    }
    private void ShootRaycastPosition(Vector2 direction)
    {
        gameObject.layer = 0;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, shootingDistance, targetLayerMask);
        gameObject.layer = 3;
        if (hit.collider != null)
        {
            Vector3 positionSecond = hit.transform.position;
            hit.transform.position = transform.position;
            transform.position = positionSecond;
        }       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        switch (SwipeDetection.Instance.ReturnDirection())
        {
            case DirectionSwipe.Left:
                ShootRaycastPosition(Vector2.left);
                break;
            case DirectionSwipe.Right:
                ShootRaycastPosition(Vector2.right);
                break;
            case DirectionSwipe.Up:
                ShootRaycastPosition(Vector2.up);
                break;
            case DirectionSwipe.Down:
                ShootRaycastPosition(Vector2.down);
                break;
        }
    }
}
