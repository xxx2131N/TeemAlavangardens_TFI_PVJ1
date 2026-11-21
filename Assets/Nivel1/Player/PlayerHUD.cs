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
    public bool recibirDaño = true;

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
        if(textoVida != null)textoVida.text = "Vida " + vida;
        if(textoPuntos != null)textoPuntos.text = "Puntos " + puntos;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Daño") || other.CompareTag("Caos"))
        {
            RecibirDaño(1);
        }
        if (other.CompareTag("Suelo"))
        {
            Debug.Log("se detecto el suelo");
            Respawn();
        }
        if (other.CompareTag("Finish"))
        {
            final();
        }
    }
    public void RecibirDaño(int cantidad)
    {
        if (recibirDaño == true)
        {
            vida -= cantidad;
            ActualizarHUD();
            Debug.Log("el jugador recibio daño ");
            if (vida<=0)
            {
                GameManager.instance.GameOver();

            }
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
    public void SetInvulnerable(bool invulnerable)
    {
        recibirDaño = !invulnerable;
    }
    public void final()
    {
        GameManager.instance.Victoria();
    }
}
