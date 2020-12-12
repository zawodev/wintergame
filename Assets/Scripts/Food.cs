using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Inventory.Zasob zasob;
    public float tastiness;
    public void Eat() {
        if(Inventory.inventory.GetZasob(zasob.ToString()) > 0) Inventory.inventory.AddZasob(zasob.ToString(), -1);
    }
}
