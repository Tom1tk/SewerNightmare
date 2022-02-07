using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System.Collections;

public class enemyZombie : MonoBehaviour
{
    public float health = 60f;
    public float damage = 10f;
    public GameObject body;
    public ParticleSystem deathFX;
    public AudioSource activateSound;

    public bool soundPlayed;

    //ai stuff
    public float lookRadius = 10f;
    public Transform target;
    NavMeshAgent agent;
    public float RateOfFire = 1f;
    public bool canHit = true;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        canHit = true;
        soundPlayed = false;
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
            if(soundPlayed == false)
            {
                activateSound.Play();
                soundPlayed = true;
            }

            agent.SetDestination(target.position);

            if (canHit)
            {
                //StartCoroutine(attack());
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
        if (health <= 0f)
        {
            Die();
        }
    }

    IEnumerator attack(RaycastGun player)
    {    
        Debug.Log("zombie attacks");
        if (canHit)
        {
            player.recieveDamage(damage);
            Debug.Log("player is hit");
            canHit = false;
            yield return new WaitForSeconds(RateOfFire);
            canHit = true;
        }
    }

    void Die()
    {
        Debug.Log("ZOMBIE KILLED");

        body.SetActive(false);

        activateSound.Stop();

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

    void OnTriggerStay(Collider other)
    {
        RaycastGun player = other.GetComponent<RaycastGun>();
        
        if(player != null)
        {
            StartCoroutine(attack(player));
        }

        //Destroy(this.gameObject);
    }
}
