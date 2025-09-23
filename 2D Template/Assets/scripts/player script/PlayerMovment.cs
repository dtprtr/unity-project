using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerMovment : MonoBehaviour
{
    public float speed;

    public float JumpHeight;

    private Rigidbody2D Rb;

    private float _movement;

    public Vector2 boxsize;

    public float castDistance;

    public LayerMask groundLayer;

    public GameObject playerObj;
    
    
    // grabs inital position
    private Vector2 InitialPos;

    // grabs initial rotation
    private Quaternion InitialRot;

    private DragBoxes drag;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        drag = GetComponent<DragBoxes>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("level_work");
        }


        Rb.linearVelocityX = _movement;
    }
    // Crontrolls the players horizontal movment
    public void Move(InputAction.CallbackContext ctx)
    {

        _movement = ctx.ReadValue<Vector2>().x * speed;

    }
    // Controlls the players jump and makes sure the player is grounded
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() == 1)
        {
            if (IsGrounded())
            {
                Rb.linearVelocityY = JumpHeight;
            }
        }



    }

    // Check if the player is grounded using a boxcast
    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxsize, 0, -transform.up, castDistance, groundLayer);

        if (!hit.collider.CompareTag("box")||hit.collider.gameObject!= drag.m_targtjoint.gameObject)
        {
            Debug.Log("Grounded");
            return true;
        }
        else
        {
            Debug.Log("Not Grounded");
            return false;
        }
    }

    

    // Draw the boxcast in unity
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + Vector3.down * castDistance, boxsize);
    }


    
    void Reset()
    {
        transform.position = InitialPos;
        transform.rotation = InitialRot;
    }
}
    