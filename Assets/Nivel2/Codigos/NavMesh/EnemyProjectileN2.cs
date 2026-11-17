using UnityEngine;

public class EnemyProjectileN2 : MonoBehaviour
{
    public float speed = 15f;
    public float lifetime = 5f;

    private Vector3 moveDirection;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    private void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger) return;

        if (other.CompareTag("Player"))
        {
            other.GetComponent<playerControllerN2>().Die();
           
        }

        Destroy(gameObject);
    }



}
