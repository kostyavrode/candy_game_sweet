using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private ItemViewer ItemViewer;
    private Rigidbody rb;
    [SerializeField] private int type;
    public int Type {  get { return type; } }
    private void Awake()
    {
        ItemViewer = GetComponent<ItemViewer>();
        rb= GetComponent<Rigidbody>();
    }
    public void Follow(Vector3 newPos)
    {
        newPos.y = 0;
        transform.position = newPos;
    }
    public void SellectItem()
    {
        ItemViewer.Interact();
    }
    public void rbSetKinematic()
    {
        rb.isKinematic = true;
        rb.useGravity = false;
    }
    public void rbSetIsNotKinematic()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
