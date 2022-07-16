using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{
    [SerializeField]
    private GameObject Canvas;

    public Color blue;
    public Color black;
    public Color orange;
    public Color pink;
    public Color green;
    public Color purple;
    public Color yellow;
    public Color red;

    public GameObject Side1;
    public GameObject Side2;
    public GameObject Side3;
    public GameObject Side4;
    public GameObject Side5;
    public GameObject Side6;
    public GameObject[] Sides;

    // Start is called before the first frame update
    void Awake()
    {
        Sides = new GameObject[6];
        Sides[0] = Side1;
        Sides[1] = Side2;
        Sides[2] = Side3;
        Sides[3] = Side4;
        Sides[4] = Side5;
        Sides[5] = Side6;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.DrawRay(transform.position + Vector3.up, Vector3.down * 10, Color.blue);
    }

    public void SetDiceColor(int side, Color newColor)
    {
        Sides[side - 1].GetComponent<MeshRenderer>().material.color = newColor;
    }

    public void SetCanvasColor()
    {
        LayerMask diceMask = LayerMask.GetMask("Dice");
        LayerMask canvasMask = LayerMask.GetMask("Canvas");
        RaycastHit diceHit;
        RaycastHit canvasHit;
        GameObject bottomSide = null;
        GameObject canvasPiece = null;

        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out diceHit, 10, diceMask))
        {
            bottomSide = diceHit.collider.gameObject;
            Debug.Log(bottomSide);
        }

        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out canvasHit, 10, canvasMask))
        {
            canvasPiece = canvasHit.collider.gameObject;
            Debug.Log(canvasPiece);
        }

        if (bottomSide && canvasPiece)
        {
            int x = Mathf.RoundToInt(canvasPiece.GetComponent<Canvas_Piece>().GetPosition().x);
            int y = Mathf.RoundToInt(canvasPiece.GetComponent<Canvas_Piece>().GetPosition().y);
            Canvas_Controller canvasController = Canvas.GetComponent<Canvas_Controller>();
            Color bottomColor = bottomSide.GetComponent<MeshRenderer>().material.color;
            Material newMaterial = null;

            if (bottomColor == blue)
            {
                newMaterial = canvasController.BlueCanvas;
            } else if (bottomColor == black)
            {
                newMaterial = canvasController.BlackCanvas;
            } else if (bottomColor == orange)
            {
                newMaterial = canvasController.OrangeCanvas;
            } else if (bottomColor == pink)
            {
                newMaterial = canvasController.PinkCanvas;
            } else if (bottomColor == green)
            {
                newMaterial = canvasController.GreenCanvas;
            } else if (bottomColor == purple)
            {
                newMaterial = canvasController.PurpleCanvas;
            } else if (bottomColor == yellow)
            {
                newMaterial = canvasController.YellowCanvas;
            } else if (bottomColor == red)
            {
                newMaterial = canvasController.RedCanvas;
            }

            if (newMaterial)
            {
                canvasController.SetMaterial(x, y, newMaterial);
            }

        } else
        {
            Debug.Log("Failed to paint canvas");
        }
    }
}
