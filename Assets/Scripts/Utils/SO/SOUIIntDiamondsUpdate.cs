using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIIntDiamondsUpdate : MonoBehaviour
{
    public SOInt soIntDiamonds;
    public TextMeshProUGUI uiTextValue;

    // Start is called before the first frame update
    void Start()
    {
        uiTextValue.text = soIntDiamonds.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        uiTextValue.text = soIntDiamonds.value.ToString();
    }
}
