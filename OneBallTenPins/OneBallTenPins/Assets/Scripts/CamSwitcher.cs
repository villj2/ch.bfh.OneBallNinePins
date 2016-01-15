using UnityEngine;
using System.Collections;

public class CamSwitcher : MonoBehaviour
{

    private Camera _newCamera;
    private Camera _mainCamera;

    private GameBehaviour _gameBehaviour;


    public void Start()
    {
        _gameBehaviour = GameObject.Find("ScriptContainer").GetComponent<GameBehaviour>();
        _newCamera = GameObject.Find("PinCamera").GetComponent<Camera>();
        _mainCamera = Camera.main;
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "CamChanger")
        {
            _mainCamera.enabled = false;


            _newCamera.enabled = true;
            _newCamera.tag = "MainCamera";


            StartCoroutine(checkPointsStrike());
              
        }
    }


    IEnumerator checkPointsStrike()
    {
        yield return new WaitForSeconds(2);
        int currPoints = _gameBehaviour.getPointsFromPins();
        if(currPoints== 10)
        {
            _gameBehaviour.StrikeEffect();
        }
        else
        {
            _gameBehaviour.PointEffect(currPoints);
        }


    }
}