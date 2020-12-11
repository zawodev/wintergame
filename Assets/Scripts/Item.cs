using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public bool isActive;
    [HideInInspector]
    public bool isChosen;
    public bool canOnShift;
    public enum Type {
        Gun, Souvenir, Sword, Food
    }

    [Header("ITEM")]
    public bool isInfinitiv;
    public new string name;
    public Type type;

    [Space]
    public Sprite inHand;
    public bool generateFromCalculations = true;
    public Vector3 firePointPos;

    public void Use() {

    }

    /*
    //LPM
    public abstract void LPMStart();
    public abstract void LPMEnd();
    public abstract void LPMHold();

    //PPM
    public abstract void PPMStart();
    public abstract void PPMEnd();
    public abstract void PPMHold();
    */
    
    private void Update() {
        
    }
}
