using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private int mScore = 0;
    private int mCombo = 0;

    public void addScore(int score)
    {
        mScore += score;
    }

    public void incCombo()
    {
        mCombo += 1;
    }

    protected void missTune()
    {
        mCombo = 0;
    }
}
