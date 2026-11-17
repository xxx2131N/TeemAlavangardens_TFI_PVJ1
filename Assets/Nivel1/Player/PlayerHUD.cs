using UnityEngine;
using System.Collections;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    public int vida= 10;
    public int puntos=0; 

    public TextMeshProUGUI textoVida;
    public TextMeshProUGUI textoPuntos;

    private Transform newRespawnPoint;
    private bool recibirDaño = true;

    public void Start()
    {
        ActualizarHUD();
    }
    public void CurarVida(int cantidad)
    {
        vida += cantidad;
        ActualizarHUD();
    }
    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        ActualizarHUD();
    }
    public void ActualizarHUD()
    {
        textoVida.text = "Vida " + vida;
        textoPuntos.text = "Puntos " + puntos;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Daño"))
        {
            RecibirDaño(1);
        }
        if (other.CompareTag("Suelo"))
        {
            Debug.Log("se detecto el suelo");
            Respawn();
        }
    }
    public void RecibirDaño(int cantidad)
    {
        if (recibirDaño == true)
        {
            Debug.Log("Jugador ha muerto");
            /*vida -= cantidad;
            if (vida <= 0)
            {
                GameManager.instance.GameOver();
                Debug.Log("Jugador ha muerto");
            }*/
        }
        else if (recibirDaño == false)
        {
            Debug.Log("Jugador es invulnerable");
        }
    }
    public void SetRespawn(Transform respawnPoint)
    {
        newRespawnPoint = respawnPoint;
        Debug.Log("punto de respaun establecido");
    }
    public void Respawn()
    {
        if (newRespawnPoint != null)
        {
            CharacterController controller = GetComponent<CharacterController>();
            if (controller !=null)
            {
                controller.enabled = false;
            }
            transform.position = newRespawnPoint.position + Vector3.up;
            if (controller != null)
            {
                controller.enabled = true;
            }

            Debug.Log("Jugador respauneado");
        }
    }
}
