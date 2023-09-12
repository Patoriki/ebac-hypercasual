using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIIntCoinsUpdate : MonoBehaviour
{
    public SOInt soIntCoins;
    public TextMeshProUGUI uiTextValue;

    // Start is called before the first frame update
    void Start()
    {
        uiTextValue.text = soIntCoins.value.ToString();    
    }

    // Update is called once per frame
    void Update()
    {
        uiTextValue.text = soIntCoins.value.ToString();
    }
}
