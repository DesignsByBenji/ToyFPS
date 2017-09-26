using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {

	public void ReactToHit() {
		WanderingAI behavior = GetComponent<WanderingAI>();
        ChaseAI behaviorChase = GetComponent<ChaseAI>(); 
		if (behavior != null) {
			behavior.SetAlive(false);
		}
        else {
            behaviorChase.SetAlive(false);
        }
		StartCoroutine(Die());
	}

	public IEnumerator Die() {
		this.transform.Rotate(-75, 0, 0);
		yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
        try {
            Destroy(transform.parent.gameObject);
        } catch(System.NullReferenceException e) {
            Debug.Log("Mob 2 killed");
        }
	}
}
