using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerscript : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public float timeinterval = 3;
    public GameObject powerup;
    public GameObject speedboost;
    float timer = 0;
    float poweruptimer = 0;
    public float powerupinterval = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer>timeinterval){
            Vector3 position = new Vector3(Random.Range(-50,50),0.5f,Random.Range(-50,50));
            GameObject e = Instantiate(enemy, position, Quaternion.identity);
            enemycontroller ec = e.GetComponent<enemycontroller>();
            ec.player=player;
            timer = 0;
        }
        poweruptimer += Time.deltaTime;
        if(poweruptimer>powerupinterval){
            Vector3 position = new Vector3(Random.Range(-50,50),0.5f,Random.Range(-50,50));
            if(Random.Range(0,2) == 0){
                Instantiate(powerup, position, Quaternion.identity);
            }else{
                Instantiate(speedboost, position, Quaternion.identity);
            }
            poweruptimer = 0;
        }
    }

}
