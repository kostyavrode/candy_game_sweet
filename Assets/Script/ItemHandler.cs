using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    [SerializeField] private Item point1Item;
    [SerializeField] private Item point2Item;
    private UIManager uiManager;
    private ItemManager itemManager;
    private bool isMerged;
    private GameInfoHandler gameInfoHandler;
    private float mergeTimer;
    private float gameTimer;
    [SerializeField] private float gameTime=30f;
    private void Start()
    {
        itemManager=ServiceLocator.GetService<ItemManager>();
    }
    private void Update()
    {
        if (isMerged)
        {
            mergeTimer += Time.deltaTime;
            //uiManager.ShowTime(((int)Mathf.Round(mergeTimer)).ToString());
            if (mergeTimer>1)
            {
                isMerged = false;
                mergeTimer = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="item")
        {
            if (point1Item == null && point2Item!=other.GetComponent<Item>())
            {
                point1Item=other.GetComponent<Item>();
                point1Item.rbSetKinematic();
                point1Item.transform.position=point1.position;
                FindObjectOfType<PlayerInput>().ClearInteractionItem();
                Debug.Log("STAY1");
            }
            else if (point2Item == null && point1Item!=other.GetComponent<Item>())
            {
                Debug.Log("STAY2");
                point2Item =other.GetComponent<Item>();
                point2Item.rbSetKinematic();
                point2Item.transform.position=point2.position;
                FindObjectOfType<PlayerInput>().ClearInteractionItem();
            }
        }
        if (point1Item!=null && point2Item != null)
        {
            if (point1Item.Type==point2Item.Type && !isMerged)
            {
                MergeItems();
            }
            else
            {
                point1Item.rbSetIsNotKinematic();
                point2Item.rbSetIsNotKinematic();
                point1Item.rbSetForce(200f, new Vector3(0, 0, -1));
                point2Item.rbSetForce(200f, new Vector3(0, 0, -1));
                point1Item = null;
                point2Item = null;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="item")
        {
            if (other.GetComponent<Item>() == point1Item)
            {
                point1Item.rbSetIsNotKinematic();
                point1Item=null;
            }
            else if (other.GetComponent<Item>() == point2Item)
            {
                point2Item.rbSetIsNotKinematic();
                point2Item=null;
            }
        }
    }
    private void MergeItems()
    {
        if (!isMerged)
        {
            if (uiManager == null)
            {
                uiManager = ServiceLocator.GetService<UIManager>();
                gameInfoHandler = ServiceLocator.GetService<GameInfoHandler>();
            }
            gameInfoHandler.AddScore();
            ServiceLocator.GetService<VibrationManager>().MakeVibration(0.5f);
            isMerged = true;
            itemManager.RemoveItem(point2Item);
            itemManager.RemoveItem(point1Item);
            point1Item.DissapearItem();
            point2Item.DissapearItem();
            //Destroy(point1Item.gameObject);
            //Destroy(point2Item.gameObject);

            
            uiManager.ShowScore();
            //ServiceLocator.GetService<GameInfoHandler>().SetScoreToZero();
        }
    }
}
