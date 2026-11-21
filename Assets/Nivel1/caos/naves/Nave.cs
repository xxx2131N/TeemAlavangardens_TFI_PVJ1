using UnityEngine;

public class Nave : MonoBehaviour
{
    public PlayerHUD player;
    public float velocidad;
    public CharacterController c;
    public void OnTrigerEnter(Collider other)
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
            player.RecibirDaño(3);
        }
        
    }
}
