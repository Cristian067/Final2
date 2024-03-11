using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]private GameObject foe;
    [SerializeField]private GameObject powerup;

    [SerializeField] private float[] posX;
    [SerializeField] private float[] posz;
    [SerializeField] private Vector3[] poses;

    public int wave = 0;





    private PlayerControl player;

    public int enemyCount;

    private int powerupNum;

    private GameObject power;

    private bool playerHasPowerup;




    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerControl>();
        //waves(wave);
        //InvokeRepeating("summon",1,10f);
    }

    // Update is called once per frame
    void Update()
    {

        power = GameObject.Find("PowerUp");
        //Debug.Log(power);

        if (enemyCount <= 0)
        {
            SummonPower();
            waves(wave);
            wave++;
            
            //wave++;
        }

        //powerupNum = int.GameObject.Find("PowerUp");
        
    }

    void summon()
    {

        int ran = Random.Range(0, posX.Length);

        Instantiate(powerup, poses[ran],Quaternion.identity);
    }
    
    void SummonPower()
    {
        if (power == null && !playerHasPowerup)
        {
            int ran = Random.Range(0, posX.Length);
            GameObject PowerUp;
            PowerUp = Instantiate(powerup, poses[ran],Quaternion.identity);
            PowerUp.name = "PowerUp";

        }

        
    }
    


    private void waves(int spwanEnemies)
    {

        for(int i = 0; i < spwanEnemies; i++)
        {
            int ran = Random.Range(0, poses.Length);
            Instantiate(foe, poses[ran], Quaternion.identity);
        }

    }


    public void PowerupUse(bool power)
    {
        if (power)
        {

            playerHasPowerup = true;

        }
        else
        {
            playerHasPowerup = false;
        }
        


    }


}
