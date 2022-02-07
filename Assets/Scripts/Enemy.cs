using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float health = 60f;
    public ParticleSystem deathFX;
    public Slider healthBar;

    //ai stuff
    public float lookRadius = 10f;
    public Transform target;
    NavMeshAgent agent;

    public GameObject bulletPrefab;
    private GameObject bullet;
    public Transform barrel;

    public float shootRange = 20f;
    public float RateOfFire = 1f;

    public bool canShoot = true;

    void Start()
    {
        healthBar.value = health;
        healthBar.maxValue = health;
        
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (PauseMenu.GamePaused == true)
        {
            return;
        }

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (canShoot)
            {
                StartCoroutine(Shoot());
            }

            if (distance <= agent.stoppingDistance)
            {
                
                FaceTarget();
            }
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.value = health;
        if (health <= 0f)
        {
            Die();
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        bullet = Instantiate(bulletPrefab);
        bullet.transform.position = barrel.transform.TransformPoint(Vector3.forward);
        bullet.transform.rotation = transform.rotation;

        Debug.Log("drone shoots");
        yield return new WaitForSeconds(RateOfFire);
        canShoot = true;
    }

    void Die()
    {
        Debug.Log("DRONE KILLED");

        deathFX.Play();

        Destroy(gameObject, 0.5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
