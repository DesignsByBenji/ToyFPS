using UnityEngine;
using System.Collections;

public class PlayerFireball : MonoBehaviour {
	public float speed = 10.0f;
	public int damage = 1;
    int time = 0;
    bool shouldMove = true;

    void Update() {
        time++;
        if (shouldMove) {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        if (time >= 90) Destroy(this.gameObject);
	}

	void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Respawn") {
            ReactiveTarget enemyRT = other.GetComponent<ReactiveTarget>();
            WanderingAI enemyWAI = other.GetComponent<WanderingAI>();
            ChaseAI enemyChase = other.GetComponent<ChaseAI>();
            if (enemyChase != null) {
                enemyChase.Hurt(1);
                Destroy(this.gameObject);
            }
            else if (enemyWAI._alive) {
                enemyRT.ReactToHit();
                Destroy(this.gameObject);
            }
            else {
                Physics.IgnoreCollision(other, GetComponent<Collider>());
            }
        }
        else {
            Debug.Log("wall!");
            
            shouldMove = false;
            transform.Translate(0, 0, -0.2f);
        }
		//Destroy(this.gameObject);
	}

}