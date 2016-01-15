using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityStandardAssets.Utility;
using Cave;
using UnityEngine.UI;

public class GameBehaviour : MonoBehaviour {


    public GameObject Pins;
    public GameObject PrefabExplositionStrike;
    public GameObject PrefabMoveText;
    public GameObject Ball;
    //public GameObject VirtualHand;
    //public GameObject VirtualHandContainer;


    public Vector3 startPosBall = new Vector3(10.46f, 0.75f, 0f);
    public Vector3 startRotBall = new Vector3(0f, 270f, 0f);
    public Vector3 startPosPins = new Vector3(-12.5f, 0f, 0.9f);
    //public Vector3 startPosVirtualHand = new Vector3(0f, 0.719f,0f);
    //public Vector3 startPosVirtualHandContainer = new Vector3(10.46f, 1.31f, 0f);
    //public Quaternion startRotVirtualHandContainer = Quaternion.Euler(0f, 270f, 0f);

    private GameObject _currentPins;
    private GameObject _currentPrefabExplositionsStrike;
    private GameObject _currentPrefabMoveText;

    private GameObject _currentBall;
    private Rigidbody _currentBallRigibody;
    private bool _isThrowing;
    //private FixedJoint _currentFixedJoint;
    //private GameObject _currentVirtualHand;
    //private GameObject _currentVirtualHandContainer;

    private Text _playerPointsText;

    private Camera _StartCamera;
    private Camera _pinCamera;

    private Dictionary<int, string> _players;
    private int _currentPlayer = 0;
    private int _currentThrow = 1;

    private PointsBehaviour _pointsBehaviour;
    //private VirtualHand _virtualHand;

    private List<float> _velocityList;


    // Use this for initialization
    void Start () {

        _velocityList = new List<float>();

        //_currentVirtualHandContainer = (GameObject)Instantiate(VirtualHandContainer, startPosVirtualHandContainer, startRotVirtualHandContainer);
        //_virtualHand = _currentVirtualHandContainer.GetComponent<VirtualHand>();
        _currentBall = (GameObject)Instantiate(Ball, startPosBall, Quaternion.Euler(startRotBall));
        //GameObject.FindGameObjectWithTag("Ball");
        _currentBallRigibody = _currentBall.GetComponent<Rigidbody>();

        //_currentVirtualHand = GameObject.FindGameObjectWithTag("VirtualHand");
        //_currentFixedJoint =  _currentVirtualHand.GetComponent<FixedJoint>();


        _currentPins = (GameObject)Instantiate(Pins, startPosPins, Quaternion.identity);
        

        _StartCamera = Camera.main;
        _pinCamera = (Camera)GameObject.FindWithTag("PinCamera").GetComponent<Camera>();

        _pointsBehaviour = GameObject.Find("ScriptContainer").GetComponent<PointsBehaviour>();

        _playerPointsText = GameObject.Find("PointText").GetComponent<Text>();

        _players = new Dictionary<int, string>();

        createPlayers();
        _currentPlayer = _players.Keys.First();

        _currentPrefabMoveText = (GameObject)Instantiate(PrefabMoveText, transform.position, _StartCamera.transform.rotation);
        _currentPrefabMoveText.GetComponent<TextMesh>().text = string.Format("Spieler {0} ist an der Reihe, Wurf {1}", _currentPlayer, _currentThrow);

        _isThrowing = false;

    }

    private void createPlayers()
    {
        _players.Add(1, "Player 1");
        _players.Add(2, "Player 2");
        _pointsBehaviour.addPoints(1, 0,99);
        _pointsBehaviour.addPoints(2, 0,99);
    }
	
	// Update is called once per frame
	void Update () {

        if (_velocityList.Count > 10)
        {
            _velocityList.RemoveRange(0, _velocityList.Count - 10);
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            resetBallPins();
            //switchPlayer();
        }
        if(Input.GetKeyDown(KeyCode.N)) // next throw
        {
            resetBallPins();
            addPoints();
          
            //switchPlayer();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            switchPlayer();
        }
        if (Input.GetKeyUp(KeyCode.Return) && !_isThrowing)
        {


            //debug
            float average = 1f;
            //float average = _velocityList[_velocityList.Count - 1] - _velocityList[0];


            //Debug.Log(average);
            _currentBallRigibody.useGravity = true;
            //Destroy(_currentFixedJoint);
            _currentBallRigibody.AddRelativeForce(Vector3.forward * (average) * 30f * 1.5f, ForceMode.Impulse);
            _isThrowing = true;
            StartCoroutine(resetAfter10Seconds());
        }

        //can be null because destroy and new initialise
        if(_currentBall != null) {


            //_currentBall.transform.localPosition = API.Instance.Wand.transform.localPosition;
           //API.Instance.Cave.WandSettings.RotationSmoothing.EnableOneEuroSmoothing = false;
        }
        //Debug.Log(string.Format("Player 1 Points: {0}, Player 2 Points: {1}", getPoints(1), getPoints(2)));

    }

    IEnumerator resetAfter10Seconds()
    {
        yield return new WaitForSeconds(10);
        resetBallPins();
        if (_currentThrow < 2) { addPoints(); }
        else{ switchPlayer(); }
        _isThrowing = false;
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

    //public int getPoints(int player)
    //{
    //    int ret = 1;
        
    //    ret = _pointsBehaviour.playersPoints[player];


    //    return ret;
    //}

    private void addPoints()
    {
        int _currPoints = getPointsFromPins();
        _pointsBehaviour.addPoints(_currentPlayer, _currPoints, _currentThrow);
       
        if(_currPoints == 10)
        {
            switchPlayer();
        }
        else
        {

            if (_currentThrow < 2)
            {
                _currentPrefabMoveText = (GameObject)Instantiate(PrefabMoveText, transform.position, _StartCamera.transform.rotation);
                _currentPrefabMoveText.GetComponent<TextMesh>().text = string.Format("Spieler {0} ist an der Reihe, Wurf {1}", _currentPlayer, _currentThrow);
            }
            _currentThrow += 1;
            _playerPointsText.text = string.Format("Punkte Spieler1: {0}\nPunkte Spieler2: {1}", _pointsBehaviour.getPoint(1), _pointsBehaviour.getPoint(2));

        }


    }

    public void StrikeEffect()
    {
        _currentPrefabExplositionsStrike = (GameObject)Instantiate(PrefabExplositionStrike, transform.position, Quaternion.identity);
        _currentPrefabMoveText = (GameObject)Instantiate(PrefabMoveText, startPosPins, _pinCamera.transform.rotation );
        //_currentPrefabMoveText.transform.LookAt(_pinCamera.transform );
       
    }

    public void PointEffect(int Points)
    {
        _currentPrefabMoveText = (GameObject)Instantiate(PrefabMoveText, startPosPins, _pinCamera.transform.rotation);
        _currentPrefabMoveText.GetComponent<TextMesh>().text = string.Format("{0} Points",Points);
    }

    public void switchPlayer()
    {

        _playerPointsText.text =  string.Format("Punkte Spieler1: {0}\nPunkte Spieler2: {1}", _pointsBehaviour.getPoint(1), _pointsBehaviour.getPoint(2));
        _currentPlayer = (_currentPlayer == _players.Keys.First() ? _players.Keys.Last(): _players.Keys.First());
        _currentThrow = 1;
        _currentPrefabMoveText = (GameObject)Instantiate(PrefabMoveText, transform.position, _StartCamera.transform.rotation);
        _currentPrefabMoveText.GetComponent<TextMesh>().text = string.Format("Spieler {0} ist an der Reihe, Wurf {1}", _currentPlayer, _currentThrow);


    }

    public void resetBallPins()
    {
        
        Destroy(_currentPins);
        _currentPins = (GameObject)Instantiate(Pins, startPosPins, Quaternion.identity);


        //Destroy(_currentVirtualHandContainer);
        //Destroy(_virtualHand);
        //_currentVirtualHandContainer = (GameObject)Instantiate(VirtualHandContainer, startPosVirtualHandContainer, Quaternion.identity);
        //_virtualHand = _currentVirtualHandContainer.GetComponent<VirtualHand>();

        //_currentBall = _currentVirtualHandContainer.GetCompo.Find("Ball").parent;

        Destroy(_currentBall);
        _currentBall = (GameObject)Instantiate(Ball, startPosBall, Quaternion.Euler(startRotBall));
        //_currentBall.AddComponent<Rigidbody>();
        _currentBallRigibody = _currentBall.GetComponent<Rigidbody>();
        _currentBallRigibody.useGravity = false;

        _currentBallRigibody.velocity = Vector3.zero;
        _currentBallRigibody.angularVelocity = Vector3.zero;

        //_currentVirtualHand = GameObject.FindGameObjectWithTag("VirtualHand");
        //_currentVirtualHand.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //_currentVirtualHand.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;


        //_currentFixedJoint = _currentVirtualHand.AddComponent<FixedJoint>();
        //_currentFixedJoint.breakForce = float.MaxValue;
        //_currentFixedJoint.breakTorque = float.MaxValue;

        //_currentFixedJoint.connectedBody = _currentBallRigibody;
        
   
        _pinCamera.enabled = false;
        _StartCamera.enabled = true;

       //_StartCamera.GetComponent<SmoothFollow>().enabled = true;
    }
}
