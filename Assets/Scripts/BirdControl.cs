using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    public Transform Graphic;

    public float Speed;
    public Vector2 Force;
    Rigidbody2D rg;
    public static bool CanMoved=false;

    public ScoreShow scoreControl;
    public GameObject score,panel;
    
    void Awake()
    {
        rg = gameObject.GetComponent<Rigidbody2D>();
        rg.AddForce(Force, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMoved)
        {
            rg.velocity = new Vector2(Speed, rg.velocity.y);
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) rg.AddForce(Force, ForceMode2D.Impulse);
            Graphic.localRotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(-90, 45, Mathf.InverseLerp(-2, 2, rg.velocity.y)));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        scoreControl.SetUpScore();
        panel.SetActive(true);
        score.SetActive(false);
        Time.timeScale = 0;
        Destroy(this);
    }
    


    private void OnTriggerExit2D(Collider2D collision)
    {
        ScoreShow.score++;
    }
}
