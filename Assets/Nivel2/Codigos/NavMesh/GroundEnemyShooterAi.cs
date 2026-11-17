using UnityEngine;
using UnityEngine.AI;

public class GroundEnemyShooterAi : MonoBehaviour
{
    [Header("Chase")]
    public float chaseDuration = 5f;

    [Header("Attack")]
    public float attackRange = 6f;
    public float fireRate = 1.5f;

    public GameObject projectilePrefab;
    public Transform shootPoint;

    [Header("Rotation")]
    public float rotationSpeed = 5f;

    private NavMeshAgent agent;

    private Transform player;

    private bool isChasing = false;
    private bool isReturning = false;

    private float chaseTimer;
    private float fireTimer;

    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    private void Update()
    {
        if (isChasing && player != null)
        {
            ChasePlayer();
        }
        else if (isReturning)
        {
            ReturnToStart();
        }
    }

    void ChasePlayer()
    {
        chaseTimer -= Time.deltaTime;

        
        float distance = Vector3.Distance(transform.position, player.position);

        RotateTowardsPlayer();

        if (distance > attackRange)
        {
            agent.isStopped = false;

            agent.SetDestination(player.position);
        }
        else
        {
            agent.isStopped = true;

            AttackPlayer();
        }

        if (chaseTimer <= 0)
        {
            StopChase();
        }

    }

    void AttackPlayer() 
    {
        fireTimer -= Time.deltaTime;

        if (fireTimer <= 0)
        {
            fireTimer = fireRate;

            shootPoint.LookAt(player.position);

            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

            EnemyProjectileN2 projectileScript = projectile.GetComponent<EnemyProjectileN2>();

            if (projectileScript != null) 
            {
                projectileScript.SetDirection(shootPoint.forward);
            }
        }
    }

    void RotateTowardsPlayer() 
    {
        Vector3 direction = (player.position - transform.position).normalized;

        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void StopChase() 
    {
        isChasing = false;

        isReturning = true;

        player = null;

        agent.isStopped = false;

        agent.SetDestination(startPosition);
    }

    void ReturnToStart(){
        float distance = Vector3.Distance(transform.position, startPosition);

        if (distance < 0.5f)
        {
            isReturning = false;

            agent.ResetPath();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;

            isChasing = true;

            isReturning = false;

            chaseTimer = chaseDuration;

        }
    }

    public void ResetEnemy()
    {
        isChasing = false;

        isReturning = false;

        player = null;

        agent.ResetPath();

        agent.Warp(startPosition);

        transform.rotation = startRotation;
    }

}

