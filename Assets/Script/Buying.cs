using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buying : MonoBehaviour
{
    public GameObject buyButton1;
    public GameObject buyButton2;
    public TMP_Text moneyBar;
    public int cost1;
    public int cost2;
    private void OnEnable()
    {
        CheckBuying();
        ShowMoney();
    }
    private void ShowMoney()
    {
        if (moneyBar != null)
        {
            moneyBar.text = PlayerPrefs.GetInt("Money").ToString();

        }
    }
    private void CheckBuying()
    {
        if (PlayerPrefs.HasKey("Buy1"))
        {
            buyButton1.SetActive(false);
        }
        if (PlayerPrefs.HasKey("Buy2"))
        {
            buyButton2.SetActive(false);
        }
    }
    public void Buying1()
    {
        if (PlayerPrefs.GetInt("Money")>=cost1)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - cost1);
            PlayerPrefs.SetString("Buy1", "-");
            PlayerPrefs.Save();
            ShowMoney();
        }
    }
    public void Buying2()
    {
        if (PlayerPrefs.GetInt("Money") >= cost2)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - cost2);
            PlayerPrefs.SetString("Buy2", "-");
            PlayerPrefs.Save();
            ShowMoney();
        }
    }
}
