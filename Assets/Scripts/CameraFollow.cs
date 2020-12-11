using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public static CameraFollow CF;
    Camera mainCam;
    void Awake() {
        CF = this;

        if (startCameraSettings.target == null) startCameraSettings.target = PlayerController.playerController.transform;
        ActualizeCameraSettings(startCameraSettings);

        Vector3 startPos = presentCameraSettings.target.position + presentCameraSettings.dynamicOffset + presentCameraSettings.staticOffset;
        startPos.z = -10;
        transform.position = startPos;

        mainCam = GetComponent<Camera>();
        synced = true;
    }

    [HideInInspector]
    public CameraSettings presentCameraSettings;
    public CameraSettings startCameraSettings;

    [HideInInspector]
    public bool synced;

    Vector3 GetPos(Vector3 targetPos) {
        targetPos = new Vector3(
                Mathf.Clamp(targetPos.x, presentCameraSettings.minCameraPos.x, presentCameraSettings.maxCameraPos.x),
                Mathf.Clamp(targetPos.y, presentCameraSettings.minCameraPos.y, presentCameraSettings.maxCameraPos.y),
                Mathf.Clamp(targetPos.z, presentCameraSettings.minCameraPos.z, presentCameraSettings.maxCameraPos.z));
        //==============
        return targetPos;
    }
    private void FixedUpdate() {

        Vector3 targetPos = presentCameraSettings.target.position;
        if (presentCameraSettings.bounds) targetPos = GetPos(targetPos);

        Vector3 desiredPosition = targetPos + presentCameraSettings.dynamicOffset + presentCameraSettings.staticOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, presentCameraSettings.moveSpeed * 0.01f);
        float desiredSize = presentCameraSettings.size;
        float smoothedSize = Mathf.Lerp(mainCam.orthographicSize, desiredSize, presentCameraSettings.magnifySpeed * 0.01f);

        if (synced) {
            transform.position = smoothedPosition;
            mainCam.orthographicSize = smoothedSize;
        }
        else {
            transform.position = desiredPosition;
            mainCam.orthographicSize = desiredSize;
        }
    }

    public void ActualizeCameraSettings(CameraSettings newCameraSettings = null) {

        if (newCameraSettings == null) newCameraSettings = startCameraSettings;

        if (newCameraSettings.target != null) presentCameraSettings.target = newCameraSettings.target;
        presentCameraSettings.moveSpeed = newCameraSettings.moveSpeed;
        presentCameraSettings.magnifySpeed = newCameraSettings.magnifySpeed;
        presentCameraSettings.size = newCameraSettings.size;
        
        presentCameraSettings.dynamicOffset = newCameraSettings.dynamicOffset;
        presentCameraSettings.staticOffset = newCameraSettings.staticOffset;

        presentCameraSettings.bounds = newCameraSettings.bounds;
        presentCameraSettings.minCameraPos = newCameraSettings.minCameraPos;
        presentCameraSettings.maxCameraPos = newCameraSettings.maxCameraPos;
    }

    public void SetMinCamPos() {
        presentCameraSettings.minCameraPos = gameObject.transform.position;
    }
    public void SetMaxCamPos() {
        presentCameraSettings.maxCameraPos = gameObject.transform.position;
    }
}
