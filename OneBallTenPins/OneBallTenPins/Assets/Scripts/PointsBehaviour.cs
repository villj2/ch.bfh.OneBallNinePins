using UnityEngine; 
using System.Collections;
using System.Collections.Generic;

public class PointsBehaviour : MonoBehaviour {

    // Use this for initialization

    public Dictionary<int, int> playersPoints;

    private Dictionary<int, bool> playerHasStrike;
    private Dictionary<int, bool> playerHasSpare;



	void Awake () {

        playersPoints = new Dictionary<int, int>();
        playerHasSpare = new Dictionary<int, bool>();
        playerHasStrike = new Dictionary<int, bool>();


	}
	

    public void addPoints( int player, int points, int currentThrow)
    {
        if(playersPoints.Equals(null)){ playersPoints = new Dictionary<int, int>(); }
        if (playerHasStrike.Equals(null)) { playerHasStrike = new Dictionary<int, bool>(); }
        if(playerHasSpare.Equals(null)) { playerHasSpare = new Dictionary<int, bool>(); }
        if(!playersPoints.ContainsKey(player)) { playersPoints.Add(player, 0); }
        if(!playerHasStrike.ContainsKey(player)) { playerHasStrike.Add(player, false); }
        if(!playerHasSpare.ContainsKey(player)) { playerHasSpare.Add(player, false); }

        if(currentThrow == 1 && points == 10) { playerHasStrike[player] = true; }
        if(currentThrow == 1 && points != 10) { playerHasStrike[player] = false; }
        if(currentThrow == 2 && points == 10) { playerHasSpare[player] = true; }
        if(currentThrow == 2 && points != 10) { playerHasSpare[player] = false; playerHasStrike[player] = false; }

        if(playerHasStrike[player]) { points = points * 2; }
        if(playerHasSpare[player] && currentThrow == 2) { points = points * 2; }

        playersPoints[player] += points;

        

    }

    public int getPoint(int player)
    {
        return playersPoints[player];
    }




}
