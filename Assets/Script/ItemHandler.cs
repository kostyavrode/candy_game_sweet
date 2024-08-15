using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    [SerializeField] private Item point1Item;
    [SerializeField] private Item point2Item;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="item")
        {
            if (point1Item == null && point2Item!=other.GetComponent<Item>())
            {
                point1Item=other.GetComponent<Item>();
                point1Item.transform.position=point1.position;
                //point1Item.SellectItem();
                FindObjectOfType<PlayerInput>().isInteracting = false;
                Debug.Log("STAY1");
            }
            else if (point2Item == null && point1Item!=other.GetComponent<Item>())
            {
                Debug.Log("STAY2");
                point2Item =other.GetComponent<Item>();
                point2Item.transform.position=point2.position;
                FindObjectOfType<PlayerInput>().ClearInteractionItem();
                point2Item.SellectItem();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="item")
        {
            if (other.GetComponent<Item>() == point1Item)
            {
                point1Item=null;
            }
            else if (other.GetComponent<Item>() == point2Item)
            {
                point2Item=null;
            }
        }
    }
}
