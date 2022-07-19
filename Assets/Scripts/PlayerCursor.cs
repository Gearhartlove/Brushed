
using System;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
     private static GameObject cursorInstance;

     public Texture2D cursorTexture;
     public CursorMode cursorMode = CursorMode.Auto;
     public Vector3 positionOffset = Vector2.zero;
     
     private void Start() {
          DontDestroyOnLoad(gameObject);

          if (cursorInstance == null)
          {
               cursorInstance = gameObject;
          } else
          {
               DestroyObject(gameObject);
          }
          
          Cursor.SetCursor(cursorTexture, positionOffset, cursorMode);
     }
}
