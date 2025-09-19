using UnityEngine;

public class camMove : MonoBehaviour
{
    public Transform player;
    public float speed;
    public Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition,speed*Time.fixedDeltaTime);

    }
}
