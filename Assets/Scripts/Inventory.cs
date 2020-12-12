using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public static Inventory inventory;
    private void Awake() {
        inventory = this;
    }

    public GameObject child;
    public enum Zasob { wood, stone, cane };

    public Vector3Int zasobyAmount;

    public Slot[] slots;

    public void ActualizeSlots() {
        slots[0].Actualize(zasobyAmount.x);
        slots[1].Actualize(zasobyAmount.y);
        slots[2].Actualize(zasobyAmount.z);
    }
    public void AddZasob(string newZasob, int amount) {
        if (newZasob == Zasob.wood.ToString()) zasobyAmount.x += amount;
        else if (newZasob == Zasob.stone.ToString()) zasobyAmount.y += amount;
        else if (newZasob == Zasob.cane.ToString()) zasobyAmount.z += amount;
    }

    public void Void1() {
        child.SetActive(true);
    }
    public void Void2() {
        child.SetActive(false);
    }
}
