using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZasobPickUp : EventHolder {

    public Inventory.Zasob zasob;
    public int amount;

    public override void OurStart() {

    }
    public override void TriggerEvent() {
        Inventory.inventory.AddZasob(zasob.ToString(), amount);
        Destroy(gameObject);
    }
}
