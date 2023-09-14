using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoins : PowerUpBase
{
    [Header("Coin Collector")]
    public float sizeAmount = 18;
    public float normalSize = 1;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.instance.ChangeCoinCollectorSize(sizeAmount);
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.instance.ChangeCoinCollectorSize(normalSize);
    }
}
