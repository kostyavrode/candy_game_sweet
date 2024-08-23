using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButt : MonoBehaviour
{
    public int levelNumber;
    private bool isCanInteract;
    private void OnEnable()
    {
        InitButton();
    }
    private void InitButton()
    {
        if (PlayerPrefs.HasKey("LevelDone" + (levelNumber)) || PlayerPrefs.HasKey("LevelDone" + (levelNumber - 1)))
        {
            isCanInteract = true;
            GetComponent<Button>().interactable = true;
        }
        else if (levelNumber == 1)
        {
            isCanInteract = true;
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
    }
}
