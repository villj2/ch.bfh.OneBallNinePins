using UnityEngine;
using System.Collections;
using Cave;

public class BallBehaviour : MonoBehaviour {

    private GameBehaviour myGameBehaviour;

	// Use this for initialization
	void Start () {

        myGameBehaviour = GameObject.Find("ScriptContainer").GetComponent<GameBehaviour>();
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {

        myGameBehaviour._velocityList.Add(API.Instance.Wand.transform.localPosition.z);


        Vector3 v3 = new Vector3(API.Instance.Wand.transform.position.x - myGameBehaviour.startPosBall.x,
                                API.Instance.Wand.transform.position.y - myGameBehaviour.startPosBall.y,
                                API.Instance.Wand.transform.position.z - myGameBehaviour.startPosBall.z);

        if (!myGameBehaviour._isThrowing) { 
             this.transform.position = v3;
             //this.transform.rotation = API.Instance.Wand.transform.rotation;
        }
    }
}
