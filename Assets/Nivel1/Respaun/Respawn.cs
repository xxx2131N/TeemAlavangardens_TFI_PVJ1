using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Renderer rend;
    public void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHUD playerHUD = other.GetComponentInParent<PlayerHUD>();
        if (playerHUD != null)
        {
            playerHUD.SetRespawn(transform);
            if (rend != null)
            {
                rend.material.color = Color.green;
                Debug.Log("Respaun activado");
            }
        }
    }
}
