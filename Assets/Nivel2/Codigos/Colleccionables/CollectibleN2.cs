using UnityEngine;

public class CollectibleN2 : MonoBehaviour
{
    [Header("Visual")]
    public float rotationSpeed = 100f;

    private void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            CollectibleManagerN2.Instance.AddCollectible();

            Destroy(gameObject);
        }
    }
}
