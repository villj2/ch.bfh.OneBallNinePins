using UnityEngine;
using System.Collections;

public class CamSwitcher : MonoBehaviour
{

    public Camera newCamera;

    private GameBehaviour _gameBehaviour;


    public void Start()
    {
        _gameBehaviour = GameObject.Find("ScriptContainer").GetComponent<GameBehaviour>();
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "CamChanger")
        {
            newCamera.enabled = true;

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