using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    private Rigidbody rb;

    [SerializeField] private float speed;

    private GameObject player;

    private PlayerControl playerControl;

    private SpawnManager spawnManager;


    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {

        playerControl = FindAnyObjectByType<PlayerControl>();

        spawnManager = FindAnyObjectByType<SpawnManager>();

        player = GameObject.Find("Player");

        spawnManager.enemyCount++;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!playerControl.KnowIfPause())
        {
            if(transform.position.y <-5)
        {
            Destroy(gameObject);
        }

        Vector3 direction = (player.transform.position - transform.position).normalized;

        rb.AddForce(direction * speed);

        }
        

        

        
    }

    private void OnDestroy()
    {
        spawnManager.enemyCount--;
    }


}
