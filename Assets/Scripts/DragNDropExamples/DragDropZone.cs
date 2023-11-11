using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DragDropZone : MonoBehaviour
{

    private GameObject selectedObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("Drag"))
                    {
                        return;
                    }

                    selectedObject = hit.collider.gameObject;
                    Cursor.visible = false;
                }
            }
            else
            {
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                selectedObject.transform.position = new Vector3(worldPosition.x, 0f, worldPosition.z);

                selectedObject = null;
                Cursor.visible = true;
            }
        }

        if (selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.transform.position = new Vector3(worldPosition.x, .25f, worldPosition.z);

            if (Input.GetMouseButtonDown(1))
            {
                selectedObject.transform.rotation = Quaternion.Euler(new Vector3(
                    selectedObject.transform.rotation.eulerAngles.x,
                    selectedObject.transform.rotation.eulerAngles.y + 90f,
                    selectedObject.transform.rotation.eulerAngles.z));
            }
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
}











//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DragDropZone : MonoBehaviour
//{
//    public LayerMask draggableMask;
//    public LayerMask dropSpotMask;

//    GameObject selectedObejct;
//    bool isDragging;

//    Vector3 offset;

//    // Start is called before the first frame update
//    void Start()
//    {
//        isDragging = false;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, draggableMask);

//            if (hit.collider != null)
//            {
//                Debug.Log(hit.collider.gameObject.name);
//                selectedObejct = hit.collider.gameObject;
//                offset = hit.collider.gameObject.transform.position - ray.origin;
//                isDragging = true;
//            }
//        }

//        if (isDragging)
//        {
//            Vector3 pos = mousePos();
//            selectedObejct.transform.position = pos + offset;

//        }

//        if (Input.GetMouseButtonUp(0))
//        {
//            isDragging = false;

//            CheckForDrop();
//        }
//    }

//    Vector3 mousePos()
//    {
//        return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
//    }

//    void CheckForDrop()
//    {
//        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, dropSpotMask);
//        if(hit.collider != null)
//        {
//            Debug.Log("Dropped onto " + hit.collider.gameObject.name);
//        }

//    }
//}
