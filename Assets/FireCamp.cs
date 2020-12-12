using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCamp : MonoBehaviour {

    public Vector2Int price;
    public GameObject firecamp;

    public void ChangeBool() {
        if (Inventory.inventory.GetZasob(Inventory.Zasob.wood.ToString()) >= price.x && Inventory.inventory.GetZasob(Inventory.Zasob.stone.ToString()) >= price.y) {
            Inventory.inventory.AddZasob(Inventory.Zasob.wood.ToString(), -price.x);
            Inventory.inventory.AddZasob(Inventory.Zasob.stone.ToString(), -price.y);
            Instantiate(firecamp, transform.position, Quaternion.identity);
        }
    }
}
