using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private ItemViewer ItemViewer;
    [SerializeField] private int type;
    public int Type {  get { return type; } }
    private void Awake()
    {
        ItemViewer = GetComponent<ItemViewer>();
    }
    public void Follow(Vector3 newPos)
    {
        newPos.z = 0;
        transform.position = newPos;
    }
    public void SellectItem()
    {
        ItemViewer.Interact();
    }
}
