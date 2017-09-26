using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour {
	private Camera _camera;
    private bool gun = true;

	void Start() {
		_camera = GetComponent<Camera>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void OnGUI() {
		int size = 12;
		float posX = _camera.pixelWidth/2 - size/4;
		float posY = _camera.pixelHeight/2 - size/2;
		GUI.Label(new Rect(posX, posY, size, size), "*");
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
			Ray ray = _camera.ScreenPointToRay(point);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                //if (gun) {
                    if (target != null) {
                        target.ReactToHit();
                    }
                    else {
                        StartCoroutine(SphereIndicator(hit.point));
                    }
                //}
                /*else {
                    //implement secondary weapon
                    if (target != null) { 
                        target.ReactToHit();
                    }
                    else {
                        StartCoroutine(SphereIndicator(hit.point));
                    }
                }*/
			}
		}
        if (Input.GetMouseButtonUp(1)) {
            gun = !gun;
            Debug.Log("Gun: " + gun);
        }
	}

    private void OnMouseEnter() {
        
    }

    private IEnumerator SphereIndicator(Vector3 pos) {
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        if (!gun) {
            sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        sphere.transform.position = pos;
		yield return new WaitForSeconds(1);
		Destroy(sphere);

	}
}