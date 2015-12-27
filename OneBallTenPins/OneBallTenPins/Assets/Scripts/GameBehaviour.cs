using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameBehaviour : MonoBehaviour {


    public GameObject Pins;
    public GameObject PrefabExplositionStrike;
    public GameObject PrefabMoveText;


    private Vector3 _startPosBall;
    private Vector3 _startPosPins;

    private GameObject _currentPins;
    private GameObject _currentPrefabExplositionsStrike;
    private GameObject _currentPrefabMoveText;
    private Camera _StartCamera;
    private Camera _pinCamera;

    private Dictionary<int, string> _players;
    private int _currentPlayer = 0;

    private PointsBehaviour _pointsBehaviour;


    // Use this for initialization
    void Start () {
        _startPosBall = GameObject.Find("Ball").transform.position;
        _startPosPins = new Vector3(-12.5f, 0f, 0.9f);

        _currentPins = (GameObject)Instantiate(Pins, _startPosPins, Quaternion.identity);

        _StartCamera = Camera.main;
        _pinCamera = (Camera)GameObject.FindWithTag("PinCamera").GetComponent<Camera>();

        _pointsBehaviour = GameObject.Find("ScriptContainer").GetComponent<PointsBehaviour>();

        _players = new Dictionary<int, string>();

        createPlayers();
        _currentPlayer = _players.Keys.First();
        

	}

    private void createPlayers()
    {
        _players.Add(1, "Player 1");
        _players.Add(2, "Player 2");
        _pointsBehaviour.addPoints(1, 0);
        _pointsBehaviour.addPoints(2, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            resetBallPins();
            //switchPlayer();
        }
        if(Input.GetKeyDown(KeyCode.N)) // next
        {
            addPoints();
            resetBallPins();
            switchPlayer();
        }

        //Debug.Log(string.Format("Player 1 Points: {0}, Player 2 Points: {1}", getPoints(1), getPoints(2)));

    }

    public int getPointsFromPins()
    {
        int ret = 0;
        GameObject[] _ListPins = GameObject.FindGameObjectsWithTag("Jack");
        foreach(var p in _ListPins)
        {
            ret += p.GetComponent<PinBehaviour>().point;
        }
        

        return ret;
    }

    public int getPoints(int player)
    {
        int ret = 1;
        
        ret = _pointsBehaviour.playersPoints[player];


        return ret;
    }

    private void addPoints()
    {
        int _currPoints = getPointsFromPins();
        _pointsBehaviour.addPoints(_currentPlayer, _currPoints);
    }

    public void StrikeEffect()
    {
        _currentPrefabExplositionsStrike = (GameObject)Instantiate(PrefabExplositionStrike, transform.position, Quaternion.identity);
        _currentPrefabMoveText = (GameObject)Instantiate(PrefabMoveText, _startPosPins, _pinCamera.transform.rotation );
        //_currentPrefabMoveText.transform.LookAt(_pinCamera.transform );
    }

    public void PointEffect(int Points)
    {
        _currentPrefabMoveText = (GameObject)Instantiate(PrefabMoveText, _startPosPins, _pinCamera.transform.rotation);
        _currentPrefabMoveText.GetComponent<TextMesh>().text = string.Format("{0} Points",Points);
    }

    private void switchPlayer()
    {
        _currentPlayer = (_currentPlayer == _players.Keys.First() ? _players.Keys.Last(): _players.Keys.First());
    }

    private void resetBallPins()
    {
        GameObject.Find("Ball").transform.position = _startPosBall;
        GameObject.Find("Ball").GetComponent<Rigidbody>().velocity = Vector3.zero;
        GameObject.Find("Ball").GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        Destroy(_currentPins);
        _currentPins = (GameObject)Instantiate(Pins, _startPosPins, Quaternion.identity);
        
        

        _pinCamera.enabled = false;
        _StartCamera.enabled = true;
    }
}
