using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Orientation
{
    Portrait,
    LandscapeLeft,
    LandscapeRight,
    PortraitUpsideDown
}

public class GameController : MonoBehaviour
{
    [Range(1, 4)]
    public int enemyNumber = 3;
    public Orientation screenOrientation;
    private List<GameObject> enemyList;
    private GameObject enemyPrefab;
    private BulletManager bulletManager;
    private bool checker = false;
    private Vector3 scorePortrait, scoreLandscape;
    private GameObject scoreLable;
    // Start is called before the first frame update
    void Start()
    {
        scorePortrait = new Vector3(-365.6f, 1236, 0);
        scoreLandscape = new Vector3(-1152, 578, 0);
        scoreLable = GameObject.Find("ScoreLabel");
        switch (Screen.orientation)
        {
            case ScreenOrientation.Portrait:                                         
                Camera.main.orthographicSize = 5f;
                scoreLable.transform.localPosition = scorePortrait;
                screenOrientation = Orientation.Portrait;

                break;
            case ScreenOrientation.LandscapeLeft:                
                Camera.main.orthographicSize = 2.5f;
                scoreLable.transform.localPosition = scoreLandscape;
                screenOrientation =Orientation.LandscapeLeft;
                break;
            case ScreenOrientation.LandscapeRight:               
                Camera.main.orthographicSize = 2.5f;
                scoreLable.transform.localPosition = scoreLandscape;
                screenOrientation = Orientation.LandscapeLeft;
                break;
            case ScreenOrientation.PortraitUpsideDown:                
                Camera.main.orthographicSize = 5f;
                scoreLable.transform.localPosition = scorePortrait;
                screenOrientation = Orientation.PortraitUpsideDown;
                break;
        }       
        bulletManager = gameObject.GetComponent<BulletManager>();
        enemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy");
        BuildEnemyList();
    }

    private void Update()
    {
        switch(Screen.orientation)
        {
            case ScreenOrientation.Portrait:
                if (screenOrientation != Orientation.Portrait)
                {

                    ChangeOrientation();
                    scoreLable.transform.localPosition = scorePortrait;
                    Camera cam = Camera.main;
                    cam.orthographicSize = 5;                    
                    screenOrientation = Orientation.Portrait;

                }
                break;
            case ScreenOrientation.LandscapeRight:
                if (screenOrientation != Orientation.LandscapeRight)
                {
                    ChangeOrientation();
                    Camera cam = Camera.main;
                    cam.orthographicSize = 2.5f;
                    scoreLable.transform.localPosition = scoreLandscape;
                    screenOrientation = Orientation.LandscapeRight;
                }
                break;
            case ScreenOrientation.LandscapeLeft:
                if (screenOrientation != Orientation.LandscapeLeft)
                {
                    ChangeOrientation();
                    scoreLable.transform.localPosition = scoreLandscape;
                    Camera cam = Camera.main;
                    cam.orthographicSize = 2.5f;
                    screenOrientation = Orientation.LandscapeLeft;
                }
                break;
            case ScreenOrientation.PortraitUpsideDown:
                if(screenOrientation != Orientation.PortraitUpsideDown)
                {
                    ChangeOrientation();
                    scoreLable.transform.localPosition = scorePortrait;
                    Camera cam = Camera.main;
                    cam.orthographicSize = 5;
                    screenOrientation = Orientation.PortraitUpsideDown;
                }
                break;


        }
    }
    void ChangeOrientation()
    {
        foreach (BackgroundStarsBehaviour go in Resources.FindObjectsOfTypeAll(typeof(BackgroundStarsBehaviour)) as BackgroundStarsBehaviour[])
        {
            go.ChangeOrientation();
        }
        foreach (BulletBehaviour go in Resources.FindObjectsOfTypeAll(typeof(BulletBehaviour)) as BulletBehaviour[])
        {
            
            go.SetOrient();
        }
        foreach (EnemyBehaviour go in Resources.FindObjectsOfTypeAll(typeof(EnemyBehaviour)) as EnemyBehaviour[])
        {
            go.ChangeOrientation();
        }
        bulletManager.ChangeOrientation();
        PlayerBehaviour p = GameObject.FindObjectOfType<PlayerBehaviour>();
        p.changeOrientation();
    }

    public void BuildEnemyList()
    {
        enemyList = new List<GameObject>();

        for (var i = 0; i < enemyNumber; i++)
        {
            var enemy = Instantiate(enemyPrefab);
            enemyList.Add(enemy);
        }
    }
}
