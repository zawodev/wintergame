using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraSettings {

    public Transform target;
    public float moveSpeed = 6;
    public float magnifySpeed = 6;
    public float size = 5;

    //[Tooltip("Do animacji")]
    [HideInInspector]
    public Vector3 dynamicOffset;
    public Vector3 staticOffset = new Vector3(0f, 2.4f, 0f);

    public bool bounds = true;
    public Vector3 minCameraPos = new Vector3(0f, 0f, -10f);
    public Vector3 maxCameraPos = new Vector3(69f, 0f, -10f);

}
