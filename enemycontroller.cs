using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycontroller : MonoBehaviour
{
    public GameObject player;
    GameObject target;
    Rigidbody RB;
    public GameObject spawnpoint;
    public GameObject bullet;
    private float timer = 0;
    private int hp = 10;
    // Start is called before the first frame update
    void Start()
    {
     RB = GetComponent<Rigidbody>();
     target = player;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target == null){
            target = player;
        }
        this.transform.LookAt(target.transform);
        Vector3 movement=transform.forward*Time.deltaTime;
        RB.MovePosition(this.transform.position+movement);  
        timer += Time.deltaTime;
        if(timer>3){
            GameObject b = Instantiate(bullet, spawnpoint.transform.position, spawnpoint.transform.rotation);
            b.GetComponent<enemybulletscript>().shooter=this.gameObject;
            timer = 0;
        }
    }
    public void LossHp(){
        hp-=2;
        if(hp<=0){
            Destroy(this.transform.gameObject);
            GameVariables.points++;
        }
    }
    public void changeTarget(GameObject m){
        target = m;
        
    }
}
