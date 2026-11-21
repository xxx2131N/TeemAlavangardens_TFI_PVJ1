using UnityEngine;
using UnityEngine.InputSystem;

public class NaveShooterN2 : MonoBehaviour
{
    [Header("Disparo")]
    public GameObject prefabBala;
    public Transform shooterPoint;
    public float tiempoEntreDisparos = 0.3f;

    private float tiempoDisparo;
    private bool disparoActivo;

    public void OnShoot(InputValue value)
    {
        if (value.isPressed && disparoActivo)
        {
            Disparar();
        }
    }

    void Update()
    {
        if (tiempoDisparo > 0)
            tiempoDisparo -= Time.deltaTime;
    }

    void Disparar()
    {
        if (tiempoDisparo > 0)
            return;

        Instantiate(
            prefabBala,
            shooterPoint.position,
            shooterPoint.rotation
        );

        tiempoDisparo = tiempoEntreDisparos;
    }

    public void ActivarDisparo()
    {
        disparoActivo = true;
    }
}
