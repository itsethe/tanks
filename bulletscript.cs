using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>(); 
       rb.AddForce(this.transform.forward*30,ForceMode.Impulse);
       Destroy(this.transform.gameObject, 5);
    }

    void OnCollisionEnter(Collision c){
        if(c.transform.CompareTag("enemy")){
            enemycontroller ec = c.transform.gameObject.GetComponent<enemycontroller>();
            ec.LossHp();
            Destroy(this.transform.gameObject);
        }
    }
}
