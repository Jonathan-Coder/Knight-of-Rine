using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float xRange = 10;
    public float changeTime = 3.0f;

    public bool paused;
    private bool attackStance;

    public Health healthCS;
    public Menu menu;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
        /*
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        */

        if (Input.GetKeyDown(KeyCode.Space) && attackStance)
        {
            //Launch a projectile from the player
            //Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            attackStance = false;
        } else if (Input.GetKeyDown(KeyCode.Space) && !attackStance)
        {
            attackStance = true;
        }

        if (Input.GetKeyUp(KeyCode.Escape) && !paused)
        {
            menu.startUp();
            pause();
            paused = true;
        } else if(Input.GetKeyUp(KeyCode.Escape) && paused)
        {
            resume();
            menu.startButton();
            paused = false;
        }
        
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);
    }

    public void pause()
    {
        Time.timeScale = 0;
    }

    public void resume()
    {
        Time.timeScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && attackStance)
        {
            Destroy(other.gameObject);
            
        } else if(other.gameObject.CompareTag("Enemy") && !attackStance)
        {
            healthCS.health--;
        }


    }
}
