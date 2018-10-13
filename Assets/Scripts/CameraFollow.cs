﻿using UnityEngine;

public class CameraFollow : MonoBehaviour{
    public Transform playerTransform;

    // Update is called once per frame
    void Update(){
        if (playerTransform != null){
            transform.position = playerTransform.position + new Vector3(0, 5, 0);
        }
    }

    public void setTarget(Transform target){
        playerTransform = target;
    }
}