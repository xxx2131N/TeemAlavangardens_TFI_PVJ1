using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public float velocidad = 10;
    public PlayerHUD player;
    public CharacterController c;
    public Transform destinoActual;
    public void Start()
    {
        destinoActual = B;
        if (player == null)
        {
            player = FindFirstObjectByType<PlayerHUD>();
        }
    }
    public void Update()
    {
        if(A != null && B != null)
        {
            transform.position = Vector3.MoveTowards(transform.position,destinoActual.position,velocidad *Time.deltaTime);
            if (Vector3.Distance(transform.position, destinoActual.position)<0.2f)
            {
                destinoActual =(destinoActual==A) ? B : A;
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHUD hudTocando = other.GetComponentInParent<PlayerHUD>();
            if(hudTocando != null)
            {
                player = hudTocando;
            }
            dañarPlayer();
        }
    }
    public void dañarPlayer()
    {
        if(player != null)
        {
            player.RecibirDaño(1);
        }
    }
}
