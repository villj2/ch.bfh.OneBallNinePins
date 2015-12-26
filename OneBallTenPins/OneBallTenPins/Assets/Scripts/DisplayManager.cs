using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayManager : MonoBehaviour
{

    private PointsBehaviour _pointsBehaviour;
    private GameBehaviour _gameBehaviour;

    public void Start()
    {
        _pointsBehaviour = GameObject.Find("ScriptContainer").GetComponent<PointsBehaviour>();
        _gameBehaviour = GameObject.Find("ScriptContainer").GetComponent<GameBehaviour>();
    }

    public void OnGUI()
    {

        // does not work
    //    GUI.Label(new Rect(10, 10, 100, 30), string.Format("Player1: ",_gameBehaviour.getPoints(1)));
    //    GUI.Label(new Rect(10, 40, 100, 30), string.Format("Player2: ", _gameBehaviour.getPoints(2)));
    }
  
}