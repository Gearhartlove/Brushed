using System.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = System.Random;

public class Controls : MonoBehaviour {
    private Quaternion targetRotation;
    private Paint paint;

    private GameManage gameManager;

    // Cinamachine Camera
    [SerializeField] private Camera camera;
    [SerializeField] private Vector3 camRot;

    [SerializeField] private Animator animator;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private SFX_Manager sfx;

    public bool isPaused;
    public bool isComplete;

    private bool isAnimating;

    private void Start() {
       
        if (gameObject.name == "Level-Select-Dice") {
            InvokeRepeating("MoveLevelSelectDice", 2f, 0.9f);
        }
    }

    private void MoveLevelSelectDice() {
        var rand = new Random();
        var move = rand.Next(4);
        switch (move) {
            case 0:
                OnW();
                break;
            case 1:
                OnA();
                break;
            case 2:
                OnS();
                break;
            case 3:
                OnD();
                break;
        }
    }

    private void Awake()
    {
        paint = GetComponent<Paint>();
        sfx = GameObject.Find("SFX").GetComponent<SFX_Manager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManage>();
    }

    private void Update() {
        // Treat the level - select dice different than the game play dice
        if (gameObject.name != "Level-Select-Dice") {
            camRot = camera.transform.rotation.eulerAngles;   
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Dice Falling"))
            {
                isAnimating = true;
            } else
            {
                isAnimating = false;
            }
        }

        if (!sfx)
        {
            sfx = GameObject.Find("SFX").GetComponent<SFX_Manager>();
        }
    }

    public enum Direction {
        North,
        South,
        West,
        East,
    }

    private Vector3 GetDirection(Direction dir) {
        if (camRot.y >= 45 && camRot.y <= 135) {
            switch (dir) {
                case Direction.North:
                    return Vector3.right;
                case Direction.South:
                    return Vector3.left;
                case Direction.West:
                    return Vector3.forward;
                case Direction.East:
                    return Vector3.back;
            }
        }

        if (camRot.y >= 135 && camRot.y <= 225) {
            switch (dir) {
                case Direction.North:
                    return Vector3.back;
                case Direction.South:
                    return Vector3.forward;
                case Direction.West:
                    return Vector3.right;
                case Direction.East:
                    return Vector3.left;
            }
        }

        if (camRot.y >= 225 && camRot.y <= 315) {
            switch (dir) {
                case Direction.North:
                    return Vector3.left;
                case Direction.South:
                    return Vector3.right;
                case Direction.West:
                    return Vector3.back;
                case Direction.East:
                    return Vector3.forward;
            }
        }

        if (camRot.y >= 315 || camRot.y <= 45) {
            switch (dir) {
                case Direction.North:
                    return Vector3.forward;
                case Direction.South:
                    return Vector3.back;
                case Direction.West:
                    return Vector3.left;
                case Direction.East:
                    return Vector3.right;
            }
        }
        
        // will never happen
        return Vector3.zero;
    }
    
    public void OnW() {
        if (!isMoving && !isPaused && !isAnimating && !isComplete) {
            var dir = GetDirection(Direction.North);
            if (gameManager.InBounds(dir)) {
                UpdatePosition(dir);
                StartCoroutine(Roll(dir));
            }
        }
    }

    public void OnS() {
        if (!isMoving && !isPaused && !isAnimating && !isComplete) {
            var dir = GetDirection(Direction.South);
            if (gameManager.InBounds(dir)) {
                UpdatePosition(dir);
                StartCoroutine(Roll(dir));
            }
        }
    }

    public void OnA() {
        if (!isMoving && !isPaused && !isAnimating && !isComplete) {
            var dir = GetDirection(Direction.West);
            if (gameManager.InBounds(dir)) {
                UpdatePosition(dir);
                StartCoroutine(Roll(dir));
            }
        }
    }

    public void OnD() {
        if (!isMoving && !isPaused && !isAnimating && !isComplete) {
            var dir = GetDirection(Direction.East);
            if (gameManager.InBounds(dir)) {
                UpdatePosition(dir);
                StartCoroutine(Roll(dir));
            }
        }
    }

    public void UpdatePosition(Vector3 dir) {
        if (dir == Vector3.back) {
            gameManager.zPos--;
        }
        else if (dir == Vector3.forward) {
            gameManager.zPos++;
        }
        else if (dir == Vector3.right) {
            gameManager.xPos++;
        }
        else if (dir == Vector3.left) {
            gameManager.xPos--;
        }
    }

    public void OnEscape() {
        if (!isComplete)
        {
            if (!isPaused)
            {
                pauseMenu.SetActive(true);
                pauseMenu.GetComponent<Pause_Menu>().Pause();
            }
            else
            {
                pauseMenu.GetComponent<Pause_Menu>().Resume();
            }
        }
    }

    private bool isMoving = false;
    public int speed = 200;

    IEnumerator Roll(Vector3 direction) {
        isMoving = true;

        sfx.PlayRoll();

        float remainingAngle = 90;
        Vector3 rotationCenter = transform.position + direction + Vector3.down;
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);

        while (remainingAngle > 0) {
            float rotationAngle = Mathf.Min(Time.deltaTime * speed, remainingAngle);
            transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
            remainingAngle -= rotationAngle;
            yield return null;
        }

        // finished rolling, paint the canvas
        paint.SetCanvasColor();
        // check if the cell is correct
        gameManager.CheckCell(paint.pieceBelow);

        isMoving = false;
    }

}