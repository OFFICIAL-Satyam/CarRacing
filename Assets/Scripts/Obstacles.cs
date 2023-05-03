using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject[] obstacles;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spaner",0.2f,0.2f);
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector3.forward * 50 *Time.deltaTime);
    }

    public void Spaner()
    {
        Instantiate(obstacles[Random.Range(0,2)] , new Vector3(Random.Range(-3f,3f),transform.position.y,transform.position.z), Quaternion.identity);

    }

    
}
