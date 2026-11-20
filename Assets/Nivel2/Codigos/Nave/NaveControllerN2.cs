using UnityEngine;
using UnityEngine.InputSystem;

public class NaveControllerN2 : MonoBehaviour
{
    [Header("Movimiento")]
    public Transform nave;
    public float velocidad = 10f;
    public float velocidadRotacion = 80f;
    public float velocidadVertical = 7f;

    private Vector2 moveInput;
    private bool controlActivo;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        if (!controlActivo || nave == null)
            return;

        float vertical = 0f;

        // Shift + W = subir
        // Shift + S = bajar
        if (Keyboard.current.leftShiftKey.isPressed)
        {
            if (Keyboard.current.wKey.isPressed)
                vertical = 1f;

            if (Keyboard.current.sKey.isPressed)
                vertical = -1f;
        }
        else
        {
            // W y S = avanzar y retroceder
            nave.Translate(
                Vector3.forward * moveInput.y * velocidad * Time.deltaTime,
                Space.Self
            );
        }

        // A y D = girar
        nave.Rotate(
            0f,
            moveInput.x * velocidadRotacion * Time.deltaTime,
            0f
        );

        // Movimiento vertical
        nave.Translate(
            Vector3.up * vertical * velocidadVertical * Time.deltaTime,
            Space.World
        );
    }

    public void ActivarControl()
    {
        controlActivo = true;
    }

}
