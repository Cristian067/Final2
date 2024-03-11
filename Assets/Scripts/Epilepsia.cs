using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Epilepsia : MonoBehaviour
{
    [SerializeField] private Color[] colorArray;

    [SerializeField] private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Colors();
    }


    private IEnumerator Colors()
    {
        foreach (Color color in colorArray)
        {



        }
        yield return new WaitForSeconds(1);
    }


}
