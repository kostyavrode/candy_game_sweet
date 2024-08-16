using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private Item[] itemPrefabs;
    [SerializeField] private int itemCount=32;
    [SerializeField] private Transform spawnObjectTransform;
    private bool isObjectsSpawned;
    [SerializeField] private List<Item> spawnedItems;
    private void Awake()
    {
        GameManager.onGameStateChange += CheckGameState;
    }
    private void OnDisable()
    {
        GameManager.onGameStateChange -= CheckGameState;
    }
    private void CheckGameState(GameState state)
    {
        switch (state)
        {
            case GameState.OFF:
                break;
            case GameState.PLAYING:
                if (!isObjectsSpawned)
                {
                    SpawnObjects();
                        break;
                }
                break;
            case GameState.PAUSED:
                break;
            case GameState.FINISHED:
                break;
            case GameState.END:
                break;
        }
    }
    private void SpawnObjects()
    {
        for (int i = 0; i < itemCount/2; i++)
        {
            int randomNum=Random.Range(0, itemPrefabs.Length);
            Item newItem=Instantiate(itemPrefabs[randomNum]);
            spawnedItems.Add(newItem);
            newItem.transform.position=spawnObjectTransform.position;
            newItem = Instantiate(itemPrefabs[randomNum]);
            spawnedItems.Add(newItem);
            newItem.transform.position = spawnObjectTransform.position;
        }
        isObjectsSpawned = true;
    }
    public void RemoveItem(Item item)
    {
        spawnedItems.Remove(item);
        CheckSpawnedItems();
    }
    private void CheckSpawnedItems()
    {
        if (spawnedItems.Count==0)
        {
            ServiceLocator.GetService<GameManager>().FinishGame();
        }
    }
}
