using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemy1Prefab;
    [SerializeField] private GameObject enemy2Prefab;
    [SerializeField] private GameObject playerPrefab;
    private GameObject _enemy;
    public int MAX = 15;
    
    private int time = 0;

    private void Start() {
        //GameObject player = Instantiate(playerPrefab) as GameObject;
        //player.transform.position = new Vector3(0, 1, 0);
    }

    void Update() {
        time++;
        if (GameObject.FindGameObjectsWithTag("Respawn").Length < MAX-4 && time>=150) {

            int numberOfEnemies = Random.Range(0, 5);
            for(int i=0; i<numberOfEnemies; i++) StartCoroutine(SpawnNew());


            time = 0;
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            Application.LoadLevel("level1");
            SceneManager.LoadScene("level1", LoadSceneMode.Single);
        }
    }

    public void playerDeath() {

    }

    private IEnumerator SpawnNew() {
        int enemyNumber = Random.Range(0, 2);
        int x = Random.Range(-50, 50);
        int z = Random.Range(-50, 50);
        if (enemyNumber == 0) {
            _enemy = Instantiate(enemy1Prefab) as GameObject;
            _enemy.transform.position = new Vector3(x, 1, z);
        }
        else {
            _enemy = Instantiate(enemy2Prefab) as GameObject;
            _enemy.transform.position = new Vector3(z, 2.66f, z);
        }
        
        float angle = Random.Range(0, 360);
        _enemy.transform.Rotate(0, angle, 0);
        yield return new WaitForSeconds(5f);


    }
}
