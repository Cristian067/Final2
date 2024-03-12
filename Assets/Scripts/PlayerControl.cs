using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private Rigidbody rb;

    [SerializeField] private float speed;

    //[SerializeField] private Transform camera_pos;
    [SerializeField] private GameObject focalPoint;

    public bool hasPowerup;

    private float power = 10f;


    [SerializeField] private GameObject[] powerupIndicator;


    //private float forwardInput;

    private bool paused;

    private float vertical;

    [SerializeField] private int lives = 3;

    private bool isGameOver;

    private SpawnManager spawnManager;


    private UIManager uiManager;


    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        hasPowerup = false;
        lives = 3;
        isGameOver = false;
    }
    void Start()
    {
        Time.timeScale = 1;
        spawnManager = FindAnyObjectByType<SpawnManager>();
        uiManager = FindAnyObjectByType<UIManager>();
        HideIndicators();

    }

    // Update is called once per frame
    void Update()
    {

        if (isGameOver)
        {
            //uiManager.ShowGameOverPanel();
            return;
        }

        vertical = Input.GetAxis("Vertical");
        if (!paused)
        {
            rb.AddForce(focalPoint.transform.forward * speed * vertical);
        }
        


        if (transform.position.y < -5)
        {
            lives--;
            if (lives <= 0)
            {
                uiManager.ShowGameOverPanel();
                Destroy(gameObject);

            }
            else
            {
                transform.position = new Vector3(0, 0, 0);
                rb.velocity = Vector3.zero;
            }

            //rb.

            

        }


        if (Input.GetKeyDown("escape"))
        {
            if(paused == false)
            {
                uiManager.ShowPausePanel();
                paused = true;

            }
            else if (paused == true)
            {
                uiManager.HidePausePanel();
                paused = false;

            }
            
        }
        



        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Powerup")
        {
            hasPowerup = true;
            spawnManager.PowerupUse(true);
            Destroy(other.gameObject);

            StartCoroutine(PowerupCountdown());

        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy" && hasPowerup)
        {
            
            Rigidbody foeRb = collision.gameObject.GetComponent<Rigidbody>();
            
            Vector3 direction = (collision.transform.position - transform.position).normalized;


            foeRb.AddForce(direction * speed * power, ForceMode.Impulse);
            
            
            

        }
        
    }


    private IEnumerator PowerupCountdown()
    {
        
        
        for (int i = 0; i < powerupIndicator.Length; i++)
        {
            
            powerupIndicator[i].SetActive(true);
            yield return new WaitForSeconds(2);
            HideIndicators();
            
        }

        

        hasPowerup = false;
        spawnManager.PowerupUse(false);
    }


    private void fall()
    {

        lives--;


    }
    private void test1()
    {
        
    }

    private void HideIndicators()
    {
        foreach (GameObject indicator in powerupIndicator)
        {
            indicator.SetActive(false);
        }
    }


    public bool KnowIfPause()
    {
        return paused;
    }

}
