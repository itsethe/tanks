using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public static class GameVariables{
    public static int points = 0;

}
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10;
    public float rotationspeed = 10;
    public GameObject spawnpoint;
    public GameObject bullet;
    float timer = 0;
    public float timeinterval = 1;
    int hp = 10;
    public Text scoreText;
    public Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float ws = Input.GetAxis("Vertical");
        float ad = Input.GetAxis("Horizontal");
        Vector3 movement = this.transform.forward*ws*Time.deltaTime*speed;
        rb.MovePosition(this.transform.position+movement);
        Quaternion rotation = Quaternion.Euler(0,ad*Time.deltaTime*rotationspeed,0);
        rb.MoveRotation(this.transform.rotation*rotation);
        timer += Time.deltaTime;
        if(Input.GetKey("space")&& timer>timeinterval){
            timer = 0;
            Instantiate(bullet,spawnpoint.transform.position,spawnpoint.transform.rotation);
        }
        scoreText.text = "Points: " + GameVariables.points;
    }
    void OnTriggerEnter(Collider c){
        if(c.CompareTag("speedboost")){
           speed += 1;
           rotationspeed += 1; 
           Destroy(c.gameObject);
        }
        if(c.CompareTag("powerup")){
            timeinterval -= 0.1f;
            Destroy(c.gameObject);
        }
    }
    public void LoseHp(){
        hp-=1;
        livesText.text="Lives: " + hp;
        if(hp<0){
          Destroy(this.transform.gameObject);
          SceneManager.LoadScene(1);
        }
    }
}
