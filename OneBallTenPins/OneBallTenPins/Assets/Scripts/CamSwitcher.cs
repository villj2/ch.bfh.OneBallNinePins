using UnityEngine;
using System.Collections;

public class CamSwitcher : MonoBehaviour
{

    public Camera newCamera; 

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "CamChanger")
        {
            newCamera.enabled = true;
        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "CamChanger")
        {
            newCamera.enabled = true;
        }
    }
}