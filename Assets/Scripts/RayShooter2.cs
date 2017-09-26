using UnityEngine;
using System.Collections;

public class RayShooter2 : MonoBehaviour {
    private Camera _camera;
    private bool gun = true;
    public bool canShoot = true;
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private GameObject fireball2Prefab;
    private GameObject _fireball;
    int time = 0;
    void Start() {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI() {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    void Update() {
        time++;
        if (Input.GetMouseButton(0) && time>=15 && canShoot) {
            time = 0;
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            if (GameObject.FindGameObjectsWithTag("Projectile").Length < 10) {
                if (gun) {
                    _fireball = Instantiate(fireballPrefab, transform.position + new Vector3(0, 0, 10*Time.deltaTime), Quaternion.Euler(0, 0, 0)) as GameObject;
                }
                else {
                    _fireball = Instantiate(fireball2Prefab, transform.position + new Vector3(0, 0, 10*Time.deltaTime), Quaternion.Euler(0, 0, 0)) as GameObject;
                }
                //Physics.IgnoreCollision(_fireball.GetComponent<Collider>(), GetComponent<Collider>());
                _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                _fireball.transform.rotation = transform.rotation;

            }
        }
        if (Input.GetMouseButtonUp(1)) {
            gun = !gun;
            Debug.Log("Gun: " + gun);
        }
    }

    private void OnMouseEnter() {

    }

    /*private IEnumerator SphereIndicator(Vector3 pos) {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        if (!gun) {
            sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);

    }*/
}