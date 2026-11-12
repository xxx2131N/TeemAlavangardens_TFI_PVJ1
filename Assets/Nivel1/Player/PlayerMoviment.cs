using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    private float speed = 10f;
    private float gravity = -20f;
    private float fuerzaSalto = 5f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        isGrounded = controller.isGrounded;
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, 5f);
        controller.Move(moveDirection * speed * Time.deltaTime);
        
        if (isGrounded && speed > 0)
        {
            velocity.y = -2;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(fuerzaSalto * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
