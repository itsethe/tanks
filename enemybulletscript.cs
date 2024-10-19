using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybulletscript : MonoBehaviour
{
    Rigidbody rb;
    public GameObject shooter;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>(); 
       rb.AddForce(this.transform.forward*30,ForceMode.Impulse);
       Destroy(this.transform.gameObject, 5);   
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision c){
        if(c.transform.CompareTag("player")){
            PlayerController pc = c.transform.gameObject.GetComponent<PlayerController>();
            pc.LoseHp();
            Destroy(this.transform.gameObject);
        }
        if(c.transform.CompareTag("enemy")){
            enemycontroller pc = c.transform.gameObject.GetComponent<enemycontroller>();
            pc.LossHp();
            pc.changeTarget(shooter);
            Destroy(this.transform.gameObject);
        }
    }
    
        
    
}
