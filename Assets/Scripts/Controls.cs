using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;
using Cinemachine;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Controls : MonoBehaviour {
    private Quaternion targetRotation;
    private Quaternion defaultRotation;

    // debugging cube rotation 
    [SerializeField] float xrot = 0;
    [SerializeField] float zrot = 0;
    [SerializeField] private float yrot = 0;
    [SerializeField] private Vector3 camRot; 

    // Cinamachine Camera
    [SerializeField]
    private Camera camera;

    private void Awake() {
        defaultRotation = new Quaternion();
    }

    private void Update() {
        camRot = camera.transform.rotation.eulerAngles;
    }

    public enum Direction {
        North,
        South,
        West,
        East,
    }

    public (float, float, float, float, float) GetRotation(Direction dir) {
        // opposite transformations
        (float, float, float, float, float) north = (0f, 0f, 0f, 0f, 0f);
        (float, float, float, float, float) south = (0f, 0f, 0f, 0f, 0f);
        (float, float, float, float, float) east = (0f, 0f, 0f, 0f, 0f);
        (float, float, float, float, float) west = (0f, 0f, 0f, 0f, 0f);;

        float xpos = 0f;
        float zpos = 0f;

        var camRot = camera.transform.rotation.eulerAngles;
         if (camRot.y >= 45 && camRot.y <= 135) {
             north = (0f, 0f, -90f, 0f, -1f);
             south = (0f, 0f, 90f, 0f, 1f);
             west = (90f, 0f, 0f, 1f, 0f);
             east = (-90f, 0f, 0f, -1f, 0f);
         }
         if (camRot.y >= 135 && camRot.y <= 225) {
             north = (-90f, 0f, 0f, -1f, 0f);
             south = (90f, 0f, 0f,  1f, 0f);
             west = (0f, 0f, -90f, 0f, -1f);
             east = (0f, 0f, 90f, 0f, 1f);
         }
         if (camRot.y >= 225 && camRot.y <= 315) {
             north = (0f, 0f, 90f, 0f, -1f);
             south = (0f, 0f, -90f, 0f, 1f);
             west = (-90f, 0f, 0f, 1f, 0f);
             east = (90f, 0f, 0f,  -1f, 0f);
         }
         if (camRot.y >= 315 || camRot.y <= 45) {
             north = (90f, 0f, 0f, 1f, 0f);
             south = (-90f, 0f, 0f, -1f, 0f);
             west = (0f, 0f, 90f, 0f, 1f);
             east = (0f, 0f, -90f, 0f, -1f);
         }
        
         switch (dir) {
             case Direction.North:
                 return north;
             case Direction.South:
                 return south;
             case Direction.West:
                 return west;
             case Direction.East:
                 return east;
         }
        
        return (xrot, yrot, zrot, xpos, zpos);
    }

    public void OnW() {
        if (!isRotating) {
            (float xrot, float yrot, float zrot, float xpos, float zpos) = GetRotation(Direction.North);
            StartCoroutine(Role90(xrot, yrot, zrot, xpos, zpos));
        }
    }
    
    public void OnS() {
        if (!isRotating) {
            (float xrot, float yrot, float zrot, float xpos, float zpos) = GetRotation(Direction.South);
            StartCoroutine(Role90(xrot, yrot, zrot, xpos, zpos));
        }
    }
    
    public void OnA() {
        if (!isRotating) {
            (float xrot, float yrot, float zrot, float xpos, float zpos) = GetRotation(Direction.West);
            StartCoroutine(Role90(xrot, yrot, zrot, xpos, zpos));
        }
    }
    
    public void OnD() {
        if (!isRotating) {
            (float xrot, float yrot, float zrot, float xpos, float zpos) = GetRotation(Direction.East);
            StartCoroutine(Role90(xrot, yrot, zrot, xpos, zpos));
        }
    }

    public void OnEscape() {
        Debug.Log("Pressed Escape");
    }

    private float lerpDuration = 0.75f;
    private bool isRotating = false;

    IEnumerator Role90(float xrot, float yrot, float zrot, float xpos, float zpos) {
        isRotating = true;
        float timeElapsed = 0;
        // rotation
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation =  Quaternion.Euler(xrot, yrot, zrot) * startRotation;
        // positioning
        Vector3 startPosition = transform.position;
        Vector3 tarpetPosition = transform.position + new Vector3(xpos, 0f, zpos); 
        while (timeElapsed < lerpDuration)
        {
            // rotating 
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / lerpDuration);
            // positioning
            transform.position = Vector3.Slerp(startPosition, tarpetPosition, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = targetRotation;
        isRotating = false;
    }
    
}