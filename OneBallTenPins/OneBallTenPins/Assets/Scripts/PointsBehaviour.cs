using UnityEngine; 
using System.Collections;
using System.Collections.Generic;

public class PointsBehaviour : MonoBehaviour {

    // Use this for initialization

    public Dictionary<int, int> playersPoints;

	void Awake () {

        playersPoints = new Dictionary<int, int>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addPoints( int player, int points)
    {
        if(playersPoints.Equals(null)){ playersPoints = new Dictionary<int, int>(); }
        if (!playersPoints.ContainsKey(player)) { playersPoints.Add(player, 0); }
        playersPoints[player] += points;

    }




}
