using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Controller : MonoBehaviour
{
    [SerializeField]
    public Material RedCanvas;
    [SerializeField]
    public Material BlueCanvas;
    [SerializeField]
    public Material GreenCanvas;
    [SerializeField]
    public Material OrangeCanvas;
    [SerializeField]
    public Material PinkCanvas;
    [SerializeField]
    public Material PurpleCanvas;
    [SerializeField]
    public Material BlackCanvas;
    [SerializeField]
    public Material YellowCanvas;
    [SerializeField] 
    public Material DefaultCanvas;

    private GameObject[,] CanvasArray;

    // Start is called before the first frame update
    void Awake()
    {
        CanvasArray = new GameObject[7, 7];
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject currentChild = transform.GetChild(i).gameObject;
            if (currentChild.CompareTag("Canvas"))
            {
                Vector2 CanvasPosition = currentChild.GetComponent<Canvas_Piece>().GetPosition();
                int XPos = Mathf.RoundToInt(CanvasPosition.x);
                int YPos = Mathf.RoundToInt(CanvasPosition.y);
                CanvasArray[XPos, YPos] = currentChild;
            }
        }
    }
    
    public Material GetMaterial(int XPos, int YPos)
    {
        GameObject canvas = CanvasArray[XPos, YPos];
        return canvas.GetComponent<MeshRenderer>().material;
    }

    public void SetMaterial(int XPos, int YPos, Material Color)
    {
        // Debug.Log("X: " + XPos + "Y: " + YPos);
        // Debug.Log(CanvasArray[XPos, YPos]);
        GameObject canvasPiece = CanvasArray[XPos, YPos];
        canvasPiece.GetComponent<MeshRenderer>().material = Color;
    }

    public void ResetMaterial(int XPos, int YPos)
    {
        GameObject canvas = CanvasArray[XPos, YPos];
        canvas.GetComponent<Canvas_Piece>().ResetMaterial();
    }
}
