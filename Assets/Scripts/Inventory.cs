using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public GameObject child;
    public void Void1() {
        child.SetActive(true);
    }
    public void Void2() {
        child.SetActive(false);
    }
}
