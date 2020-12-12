using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour {

    public Image icon;
    public TextMeshProUGUI value;

    public void Actualize(int amount) {
        value.text = amount.ToString();
    }
    public void UseItem() {
        
    }
}