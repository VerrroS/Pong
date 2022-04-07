using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Camera cam;
    public static float width;
    public static float height;
    public paddle paddle1;
    public paddle paddle2;
    public bound bound;
    public text text;
    int score_left;
    int score_right;

    text text_left;
    text text_right;


    // Start is called before the first frame update
    void Start()
    {

        cam = Camera.main;
        FindBoundries();

        bound bound1 = Instantiate(bound) as bound;
        bound bound2 = Instantiate(bound) as bound;
        bound bound3 = Instantiate(bound) as bound;
        bound bound4 = Instantiate(bound) as bound;

        bound1.Init(1);
        bound2.Init(2);
        bound3.Init(3);
        bound4.Init(4);

        text_right = Instantiate(text) as text;
        text_left = Instantiate(text) as text;

        text_right.Init(false);
        text_left.Init(true);

        text_right.writeScore(0);
        text_left.writeScore(0);

        paddle1.Init(true);
        paddle2.Init(false);	

    }

    void FindBoundries()
    {
        width = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 1)).x-.5f);
        height = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 1)).y - .5f);
    }

    public void setScore(bool isRight)
    {
        if (isRight)
        {
            score_right++;
            text_right.writeScore(score_right);
        }
        else
        {
            score_left++;
            text_left.writeScore(score_left);
        }
    }

    public void resetScore()
    {
        score_left = 0;
        score_right = 0;
        text_left.writeScore(score_left);
        text_right.writeScore(score_right);
    }


}
