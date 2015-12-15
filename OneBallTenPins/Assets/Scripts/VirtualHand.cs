using UnityEngine;
using System.Collections;
using Cave;

public class VirtualHand : MonoBehaviour {

    public GameObject Ball;
    
    private Rigidbody _rigidbodyBall;
    private FixedJoint _fixedJoint;

	// Use this for initialization
	void Start () {
        _rigidbodyBall = Ball.GetComponent<Rigidbody>();
        _fixedJoint = GetComponent<FixedJoint>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Return))
        {
            _rigidbodyBall.useGravity = true;
            _fixedJoint.breakForce = 0f;
            _rigidbodyBall.AddRelativeForce(Vector3.forward * (30f * 0.3f), ForceMode.Impulse);

            StartCoroutine(ResetBall());
        }

        transform.localPosition = API.Instance.Wand.transform.localPosition;
	}

    IEnumerator ResetBall()
    {
        yield return new WaitForSeconds(3f);

        _fixedJoint.breakForce = float.MaxValue;
        _rigidbodyBall.useGravity = false;

        Vector3 newPos = new Vector3(transform.localPosition.x, transform.localPosition.y - 0.255f, transform.localPosition.z);
        Ball.transform.localPosition = newPos;

        // TODO reset joint
    }
}
