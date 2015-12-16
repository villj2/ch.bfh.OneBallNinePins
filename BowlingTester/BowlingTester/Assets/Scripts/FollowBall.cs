using UnityEngine;
using System.Collections;

public class FollowBall : MonoBehaviour {


    public Transform Ball;

    private Camera _mainCam;

	// Use this for initialization
	void Start () {
        _mainCam = Camera.main;
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Ball);
        transform.localPosition = new Vector3(Ball.localPosition.x + 10f, Ball.localPosition.y + 10f,Ball.localPosition.z);
	}
}
