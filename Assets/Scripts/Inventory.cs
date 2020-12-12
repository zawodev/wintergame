using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public static Inventory inventory;
    private void Awake() {
        inventory = this;
        ActualizeSlots();
    }

    public GameObject child;
    public enum Zasob { wood, stone, cane, borowki, mieso };

    public Vector3Int zasobyAmount;
    public Vector2Int jedzeneAmount;

    public Slot[] slots;

    public void ActualizeSlots() {
        slots[0].Actualize(zasobyAmount.x);
        slots[1].Actualize(zasobyAmount.y);
        slots[2].Actualize(zasobyAmount.z);

        slots[3].Actualize(jedzeneAmount.x);
        slots[7].Actualize(jedzeneAmount.y);


    }
    public void AddZasob(string newZasob, int amount) {
        if (newZasob == Zasob.wood.ToString()) zasobyAmount.x += amount;
        else if (newZasob == Zasob.stone.ToString()) zasobyAmount.y += amount;
        else if (newZasob == Zasob.cane.ToString()) zasobyAmount.z += amount;
        else if (newZasob == Zasob.borowki.ToString()) jedzeneAmount.x += amount;
        else if (newZasob == Zasob.mieso.ToString()) jedzeneAmount.y += amount;

        ActualizeSlots();
    }
    public int GetZasob(string newZasob) {
        if (newZasob == Zasob.wood.ToString()) return zasobyAmount.x;
        else if (newZasob == Zasob.stone.ToString()) return zasobyAmount.y;
        else if (newZasob == Zasob.cane.ToString()) return zasobyAmount.z;
        else if (newZasob == Zasob.borowki.ToString()) return jedzeneAmount.x;
        else if (newZasob == Zasob.mieso.ToString()) return jedzeneAmount.y;
        else return 0;
    }

    public void Void1() {
        child.SetActive(true);
    }
    public void Void2() {
        child.SetActive(false);
    }
}
