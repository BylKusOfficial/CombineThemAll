using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshCollider))]
public class DragObject : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    private bool enable = true;

    public void EnableDrag(bool value)
	{
        enable = value;
    }

    private void OnMouseDown()
    {
        if (!enable)
            return;

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        if (!enable)
            return;

        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = new Vector3(curPosition.x, curPosition.y, transform.position.z);
    }
}