using UnityEngine;
using UnityEngine.InputSystem;

public class NaveInteractuableN2 : MonoBehaviour
{
    private bool playerCerca;
    private bool naveActivada;

    public GameObject player;
    public NaveControllerN2 naveController;
    public NaveShooterN2 naveShooter;

    public Transform cameraTarget;

    void Update()
    {
        if (!playerCerca || naveActivada)
            return;

        if (Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (CollectibleManagerN2.Instance.GetCollectibleCount() < 4)
            {
                Debug.Log("Necesitás las 4 baterías.");
                return;
            }

            SubirANave();
        }
    }

    private void SubirANave()
    {
        naveActivada = true;

        player.GetComponent<playerControllerN2>().enabled = false;
        player.GetComponent<CharacterController>().enabled = false;

        foreach (Renderer r in player.GetComponentsInChildren<Renderer>())
            r.enabled = false;

        naveController.ActivarControl();
        naveShooter.ActivarDisparo();

        Camera.main.GetComponent<CameraFollowN2>().target = cameraTarget;

        Debug.Log("¡Subiste a la nave!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerCerca = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerCerca = false;
    }
}   
