using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score = 0.0f;

    //private bool isDead = false;
    
    public Text scoreText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (isDead)
            //return;
        
        score += Time.deltaTime;
        scoreText.text = ((int)score).ToString();
    }

    /*public void OnDeath()
    {
        isDead = true;
    }*/
}
