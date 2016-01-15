using UnityEngine;
using System.Collections;
using System.Linq;
using Cave;
using System.Collections.Generic;



public class VirtualHand : MonoBehaviour
{

    //private GameObject _Ball;
    //private GameObject _VirtualHand;

    //private Rigidbody _rigidbodyBall;
    //private FixedJoint _fixedJoint;

    //private Rigidbody _rigibodyVirtualHand;

    //// Use this for initialization
    //void Start()
    //{
    //    _Ball = GameObject.Find("Ball");
    //    _VirtualHand = GameObject.Find("VirtualHand");
    //    _rigidbodyBall = _Ball.GetComponent<Rigidbody>();
    //    _fixedJoint = _VirtualHand.GetComponent<FixedJoint>();
    //    _rigibodyVirtualHand = _VirtualHand.GetComponent<Rigidbody>();

        
        
    //}

    //void FixedUpdate()
    //{
    //    //Debug.Log((Vector3.Dot(_rigidbodyBall.velocity, Vector3.forward) * 300f));
    //    //_velocityList.Add(API.Instance.Wand.transform.localPosition.z);

    //}

    //// Update is called once per frame
    //void Update()
    //{
        

        

    //    //_Ball.transform.localPosition  = 


    //    //Debug.Log("----------------");
    //    //_velocityList.ForEach( x => Debug.Log(x));
    //}

    //public void ResetBall()
    //{
    //    //yield return new WaitForSeconds(3f);
    //    Vector3 newPos = new Vector3(transform.localPosition.x, transform.localPosition.y - 0.255f, transform.localPosition.z);
    //    //_Ball.transform.localPosition = newPos;
    //    //Ball.transform.localRotation = Quaternion.Euler(new Vector3(0f, 270f, 0f));

    //    

    //    _fixedJoint = gameObject.AddComponent<FixedJoint>();
    //    _fixedJoint.breakForce = float.MaxValue;
    //    _fixedJoint.breakTorque = float.MaxValue;

    //    _fixedJoint.connectedBody = _rigidbodyBall;

        
    //    // TODO reset joint
    //}
}
