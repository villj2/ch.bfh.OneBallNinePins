using UnityEngine;
using System.Collections;

public class AddForce : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.GetComponent<Rigidbody>().AddForce(new Vector3(-30f, 0f, 0f),ForceMode.Impulse);
        }
	}
}
