using UnityEngine;

public class killObtacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        playerControllerN2 player = other.GetComponent<playerControllerN2>();

        if (player != null)
        {
            player.Die();
        }
    }

}
