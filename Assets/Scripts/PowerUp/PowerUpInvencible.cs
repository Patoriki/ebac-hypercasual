using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvencible : PowerUpBase
{
    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.instance.SetInvencible();
        PlayerController.instance.SetInvencibleText("Invencible");
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.instance.SetInvencible(false);
        PlayerController.instance.SetInvencibleText("");
    }
}
