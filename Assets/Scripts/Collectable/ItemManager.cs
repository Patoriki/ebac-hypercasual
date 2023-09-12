using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EVO.Core.Singleton;
//using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    //public TextMeshProUGUI coinsAmount;
    public SOInt coins;
    public SOInt diamonds;
    public SOInt coinsTotal;
    public SOInt diamondsTotal;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        diamonds.value = 0;
        //UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        coinsTotal.value += amount;
        //UpdateUI();
    }

    public void AddDiamonds(int amount = 1)
    {
        diamonds.value += amount;
        diamondsTotal.value += amount;
    }

    public void UpdateUI()
    {
        //coinsAmount.text = "X " + coins;
        //UIInGameManager.UpdateTextCoins("X " + coins.value.ToString());
    }
}
