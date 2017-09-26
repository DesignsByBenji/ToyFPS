using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAI : MonoBehaviour {
    public float speed = 6.0f;
    public float obstacleRange = 5.0f;
    public float range = 10;
    public int damage = 1;
    public int health = 2;
    //GameObject player = GameObject.FindGameObjectWithTag("Player");
    public bool _alive;

    // Use this for initialization
    void Start () {

        _alive = true;
	}
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (Vector3.Distance(player.transform.position, this.gameObject.transform.position) < range && _alive) {
            Vector3 target = player.transform.position;
            transform.LookAt(new Vector3(target.x, transform.position.y, target.z));
            transform.Translate(new Vector3(0, 0, speed* Time.deltaTime));

        }
	}
    public void Hurt(int dmg) {
        health -= dmg;
        Debug.Log("DMG: " + health);
        if (health <= 0) {
            //player dead
            ReactiveTarget enemyReact = this.GetComponent<ReactiveTarget>();
            enemyReact.ReactToHit();
            
        }
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            PlayerCharacter player = other.GetComponent<PlayerCharacter>();
            if (player != null) {
                player.Hurt(damage);
            }
            
        }
    }
    public void SetAlive(bool alive) {
        _alive = alive;
    }
}
