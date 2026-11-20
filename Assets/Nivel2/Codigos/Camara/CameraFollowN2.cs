using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollowN2 : MonoBehaviour
{
    public Transform target;

    public float distance = 6f;
    public float height = 2f;

    public float rotationSpeed = 60f;

    private float currentYaw = 0;
    private bool isDragging = false;

    private void Update()
    {
        //detectar click
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            isDragging = true;
        }
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            isDragging = false;
        }
        if (isDragging)
        {
            float mouseX = Mouse.current.delta.ReadValue().x;

            currentYaw += mouseX * rotationSpeed * Time.deltaTime;
        }

        
    }

    void LateUpdate()
    {
        if (target == null) return;

        Quaternion rotation = Quaternion.Euler(0f, currentYaw, 0f);

        Vector3 offseet = new Vector3(0, height, -distance);

        //posicion de camara
        transform.position = target.position + rotation * offseet;

        //rotacion hacia player
        transform.rotation = Quaternion.LookRotation(target.position - transform.position);
    }

}
