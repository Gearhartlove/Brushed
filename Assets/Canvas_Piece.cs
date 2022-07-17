using UnityEngine;

public class Canvas_Piece : MonoBehaviour
{
    [SerializeField]
    private Vector2 Position;
    
    // determine whether the tile is the correct color
    // private Color CorrectMateral;
    // public void SetCorrectMateral(Color c) => CorrectMateral = c;
    // public Color GetCorrectMateral => CorrectMateral;
    // private Color CurrentMateral;
    // public void SetCurrentMateral(Color c) => CurrentMateral = c;
    // public Color GetCurrentMateral => CurrentMateral;
    // public bool IsCurrentColor => CurrentMateral == CorrectMateral;
    
    
    private Material DefaultMaterial;
    private Material CurrentMaterial;
    public Material GetCurrentMaterial => CurrentMaterial;

    // Start is called before the first frame update
    void Awake() {
        DefaultMaterial = GetComponent<MeshRenderer>().material;
    }

    public Vector2 GetPosition() {
        return Position;
    }

    public void ResetMaterial() {
        GetComponent<MeshRenderer>().material = DefaultMaterial;
    }
}
