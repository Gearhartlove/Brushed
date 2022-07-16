using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Piece : MonoBehaviour
{
    [SerializeField]
    private Vector2 Position;

    private Material DefaultMaterial;

    // Start is called before the first frame update
    void Awake()
    {
        DefaultMaterial = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetPosition()
    {
        return Position;
    }

    public void ResetMaterial()
    {
        GetComponent<MeshRenderer>().material = DefaultMaterial;
    }
}
