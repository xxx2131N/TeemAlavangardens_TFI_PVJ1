using UnityEngine;

public class CheckPointN2 : MonoBehaviour
{
    private Renderer checkPointRender;

    private void OnTriggerEnter(Collider other)
    {
        playerControllerN2 player = other.GetComponent<playerControllerN2>();

        if (player != null)
        {
            player.SetSpawnPoint(transform);

            if (checkPointRender != null)
            {
                checkPointRender.material.color = Color.green;
            }
        }
    }
}
