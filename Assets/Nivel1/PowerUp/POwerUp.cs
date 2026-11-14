using UnityEngine;
using System.Collections;
public class POwerUp : MonoBehaviour
{
    private GameObject PRed;
    private GameObject PBlue;
    private GameObject PGreen;
    private PlayerController player;
    private float tiempoPowerUp;
    private EnemyController enemy;
    void Start()
    {
        player= PlayerController.instance;
        enemy = EnemyController.instance;
    }

    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject == PRed)
            {
                PowerUpRed();
            }
            else if (gameObject == PBlue)
            {
                PowerUpBlue();
            }
            else if (gameObject == PGreen)
            {
                PowerUpGreen();
            }
        }
    }
    public void PowerUpRed()
    {
        if (tag == PlayerController.instance.tag)
        {
            PRed.SetActive(false);
            PerderVida.instance.vida = false;
            tiempoPowerUp = 5f;
            
        }
    }
    public void PowerUpBlue()
    {
        if (tag == PlayerController.instance.tag)
        {
            PBlue.SetActive(false);
            EnemyController.instance.speed -= 5f;
            tiempoPowerUp = 5f;
        }
    }
    public void PowerUpGreen()
    { 
        if (tag == PlayerController.instance.tag)
        {
            PGreen.SetActive(false);
            player.vida += 1;
        }
    }
}
