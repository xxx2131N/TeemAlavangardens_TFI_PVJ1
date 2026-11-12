using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    private float speed = 10f;
    private float gravity = -20f;
    private float jumpHeight = 2f;
    void Start()
    {
        
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, 5f);
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
