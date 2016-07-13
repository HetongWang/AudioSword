using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private int mScore = 0;

    public void addScore(int score)
    {
        mScore += score;
    }
}
