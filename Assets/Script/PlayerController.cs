using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    Rigidbody2D rigidbody2D;
    float horizontal;
    float vertical;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    public GameObject projectilePrefab;
    public GameObject LaunchableProjectilePrefab;
    public Transform Launchoffset;

    public AudioClip projectileSound;

    public Image HPBar;

    public PickUp pickUp;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        pickUp = gameObject.GetComponent<PickUp>();
        pickUp.Direction = new Vector2(0, -1);
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if(!Mathf.Approximately(move.x,0.0f)|| !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        Vector2 position = transform.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;
        transform.position = position;

        if(Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(LaunchableProjectilePrefab, Launchoffset.position, transform.rotation);
        }
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        HPBar.fillAmount = (float)currentHealth / (float)maxHealth;
    }

    public void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2D.position + Vector2.up * 0.1f, Quaternion.identity);

        AudioSource.PlayClipAtPoint(projectileSound, Camera.main.transform.position);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);
    }
}
