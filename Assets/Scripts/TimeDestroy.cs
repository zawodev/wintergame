using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroy : MonoBehaviour {
    public float timed;

    void Update() {
        timed -= Time.deltaTime;
    }
}
