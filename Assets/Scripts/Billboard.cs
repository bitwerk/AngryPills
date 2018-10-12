using UnityEngine;

public class Billboard : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        Transform t = Camera.main.transform;
        transform.LookAt(t);
    }
}
