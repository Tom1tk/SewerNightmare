using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RaycastGun : MonoBehaviour
{
    //main gun variables
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCamera;
    public ParticleSystem muzzleFlash;
    public GameObject muzzleLight;
    public GameObject impactFX;
    public GameObject deathFX;

    public float RoF = 8f;
    public float RoF2 = 10f;
    public float burstSize = 3f;
    public Transform gunBarrel;
    private WaitForSeconds laserDuration = new WaitForSeconds(0.01f);
    private LineRenderer laserLine;
    private float nextFire = 0f;

    //reload variables
    public int maxAmmo = 15;
    public int currentAmmo;
    public float reloadTime = 2f;
    public float reloadTimeLeft;
    private bool reloading = false;
    public Animator animator;
    public ammoCounter ac;
    public Slider reloadBar;
    public GameObject reloadBarObj;

    //health variables
    public float health = 50f;
    public Slider healthBar;
    public GameObject deathUI;

    //audio references
    public AudioClip hitSound;
    public AudioClip deathSound;
    public AudioClip gunSound;
    public AudioClip reloadSound;
    public AudioSource AS;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        muzzleLight.SetActive(false);

        currentAmmo = maxAmmo;

        reloadBar.value = reloadTime;
        reloadBar.maxValue = reloadTime;
        reloadBarObj.SetActive(false);

        health = 100f;
        healthBar.maxValue = health;
        healthBar.value = health;

        laserLine = GetComponent<LineRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        //disabled gun when paused
        if (PauseMenu.GamePaused == true)
        {
            return;
        }

        //ammo counter UI update
        ac.UpdateUI(currentAmmo, maxAmmo);

        //Starts and decreases reload bar, also disables shooting and reloading whilst reloading
        if (reloading)
        {
            reloadTimeLeft -= Time.deltaTime;
            reloadBar.value = reloadTimeLeft;
            return;
        }

        //reload if gun empty
        if (currentAmmo <= 0f)
        {
            StartCoroutine(Reload());
            return;
        }

        //reload if R pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        //fire on mouse1
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextFire)
        {
            nextFire = Time.time + 1f / RoF2;
            StartCoroutine(Shoot());
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator Reload()
    {
        AS.PlayOneShot(reloadSound);
        reloading = true;
        reloadBar.value = reloadTimeLeft;
        //reloadBarObj.SetActive(true);
        Debug.Log("Reloading...");
        animator.SetBool("isReloading", true);
        yield return new WaitForSeconds(reloadTime - 0.25f);
        animator.SetBool("isReloading", false);
        yield return new WaitForSeconds(0.25f);
        currentAmmo = maxAmmo;
        reloadTimeLeft = reloadTime;
        reloading = false;
        //reloadBarObj.SetActive(false);
    }

    private IEnumerator LaserEffect()
    {
        muzzleLight.SetActive(true);
        laserLine.enabled = true;
        yield return laserDuration;
        laserLine.enabled = false;
        muzzleLight.SetActive(false);
    }

    public IEnumerator Shoot ()
    {
        float bulletDelay = 60f / RoF;

        for (int i = 0; i < burstSize; i++)
        {
            AS.PlayOneShot(gunSound);

            StartCoroutine(LaserEffect());

            muzzleFlash.Play();

            RaycastHit hit;

            currentAmmo--;

            laserLine.SetPosition(0, gunBarrel.position);
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
            {
                laserLine.SetPosition(1, hit.point);
                Debug.Log(hit.transform.name);

                enemyZombie zombie = hit.transform.GetComponent<enemyZombie>();
                if (zombie != null)
                {
                    zombie.TakeDamage(damage);
                }

                GameObject impactFXgo = Instantiate(impactFX, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactFXgo, 2f);
            }
            else
            {
                laserLine.SetPosition(1, fpsCamera.transform.position + (fpsCamera.transform.forward * range));
            }
            
            yield return new WaitForSeconds(bulletDelay);
        }
    }

    public void recieveDamage(float amount)
    {
        health -= amount;
        healthBar.value = health;
        
        if (health <= 0f)
        {
            AS.PlayOneShot(deathSound);
            deathUI.SetActive(true);
            Time.timeScale = 0;
        }else{
            AS.PlayOneShot(hitSound);
        }
    }
}
