using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    public bool isInteracting;
    private Transform currentItem;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateRay();
        }
        if (isInteracting)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                currentItem.GetComponent<Item>().Follow(hit.point);
            }
        }
        if (Input.GetMouseButtonUp(0) && isInteracting)
        {
            if (currentItem != null)
            {
                currentItem.transform.SendMessage("SellectItem");
                currentItem = null;
            }
            isInteracting = false;
            Debug.Log("Up");
        }
    }
    public void CreateRay()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit,200f,layerMask))
        {
            if (hit.transform.tag=="item")
            {
                currentItem = hit.transform;
                currentItem.transform.SendMessage("SellectItem");
                isInteracting = true;
            }
        }
    }
    public void ClearInteractionItem()
    {
        if (currentItem != null)
        {
            currentItem.transform.SendMessage("SellectItem");
            currentItem = null;
        }
        isInteracting = false;
        Debug.Log("Up");
    }
}
