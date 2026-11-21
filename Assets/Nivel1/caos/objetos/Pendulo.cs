using UnityEngine;

public class Pendulo : MonoBehaviour
{
    public float velocidad =50;
    private float anguloActual;
    private float limite =45f;
    public PlayerHUD player;

    void Start()
    {
        anguloActual = Random.Range(-limite, limite);
    }
    void Update()
    {
        anguloActual += velocidad * Time.deltaTime;
        if(anguloActual >= limite || anguloActual <= -limite)
        {
            velocidad *= -1;
            anguloActual = Mathf.Clamp(anguloActual, -limite, limite);
        }
        transform.localRotation = Quaternion.Euler( anguloActual,0,0);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DañarPlayer();
        }
    }
    public void DañarPlayer()
    {
        if (player != null)
        {
            player.RecibirDaño(2);
        }
    }
}
