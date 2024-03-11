using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{


    [SerializeField] private float rVel;

    private float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");


        if(horizontal != 0)
        {
             transform.Rotate(new Vector3(0,1,0) * -horizontal * Time.deltaTime * rVel);
        }
            
        


        //if(Input.GetKeyDown(KeyCode.Space))
        //{

       // }
        
    }
}
