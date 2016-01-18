using UnityEngine;
using System.Collections;

public class PinBehaviour : MonoBehaviour {


    public int point { get { return getPoint(); } }


    private GameObject _pinField;


	// Use this for initialization
	void Start () {
	
	}

    void Awake()
    {
        _pinField = GameObject.Find("PinField");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    private int getPoint()
    {
        int ret = 0;

        //if(Vector3.Dot(transform.up*-1,Vector3.up) != 0) { ret = 1; }

        // first check if standing
        // second check if they are on the plane
        if ((transform.up.y < 0.7) || (Vector3.Distance(_pinField.transform.position, transform.position) > 5f))

            { ret = 1; }


        return ret;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Ball")
        {
            // do nothing
            // _currentExplosition = (GameObject)Instantiate(prefabExplosition,transform.position,Quaternion.identity);
        }
    }
}
