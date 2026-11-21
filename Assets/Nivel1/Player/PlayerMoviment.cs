using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    private float speed = 10f;
    private float gravity = -20f;
    private float fuerzaSalto = 5f;

    [SerializeField] private LayerMask plataformaLayer;
    [SerializeField]public float distaciaRaycast= 3f;
    [SerializeField]public float offsetAltura =1f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool sobrePlataforma;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        Vector3 originRayo = transform.position + Vector3.up * offsetAltura;
        sobrePlataforma = Physics.Raycast(originRayo, Vector3.down,distaciaRaycast, plataformaLayer);
        Color cLinea = sobrePlataforma ? Color.green : Color.red;
        Debug.DrawRay(originRayo, Vector3.down * distaciaRaycast,cLinea);

        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(horizontalInput * 2, 0f, 5f);
        controller.Move(moveDirection * speed * Time.deltaTime);
        
        if (sobrePlataforma && velocity.y < 0)
        {
            velocity.y = -2;
        }
        if (Input.GetButtonDown("Jump") && sobrePlataforma)
        {
            velocity.y = Mathf.Sqrt(fuerzaSalto * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
