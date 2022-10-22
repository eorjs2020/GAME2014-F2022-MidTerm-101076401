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
    // Start is called before the first frame update
    void Start()
    {
        switch (Screen.orientation)
        {
            case ScreenOrientation.Portrait:
                screenOrientation = Orientation.Portrait;
                break;
            case ScreenOrientation.LandscapeLeft:
                screenOrientation=Orientation.LandscapeLeft;
                break;
            case ScreenOrientation.LandscapeRight:
                screenOrientation = Orientation.LandscapeRight;
                break;
            case ScreenOrientation.PortraitUpsideDown:
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
                   
                    foreach (BackgroundStarsBehaviour go in Resources.FindObjectsOfTypeAll(typeof(BackgroundStarsBehaviour)) as BackgroundStarsBehaviour[])
                    {
                        go.ChangeOrientation();
                    }
                    foreach (BulletBehaviour go in Resources.FindObjectsOfTypeAll(typeof(BulletBehaviour)) as BulletBehaviour[])
                    {
                        if (go.bulletType == BulletType.PLAYER)
                        {
                            go.SetDirection(BulletDirection.UP);
                            go.SetOrient();
                        }
                        else
                        {
                            go.SetDirection(BulletDirection.DOWN);
                            go.SetOrient();
                        }


                    }
                    PlayerBehaviour p = GameObject.FindObjectOfType<PlayerBehaviour>();
                    p.changeOrientation();
                    Camera cam = Camera.main;
                    cam.orthographicSize = 5;
                    bulletManager.ChangeOrientation();
                    screenOrientation = Orientation.Portrait;

                }
                break;
            case ScreenOrientation.LandscapeRight:
                if (screenOrientation != Orientation.LandscapeRight)
                {                    
                    
                    foreach (BackgroundStarsBehaviour go in Resources.FindObjectsOfTypeAll(typeof(BackgroundStarsBehaviour)) as BackgroundStarsBehaviour[])
                    {
                        go.ChangeOrientation();
                    }
                    foreach (BulletBehaviour go in Resources.FindObjectsOfTypeAll(typeof(BulletBehaviour)) as BulletBehaviour[])
                    {
                        if (go.bulletType == BulletType.PLAYER)
                        {
                            go.SetDirection(BulletDirection.RIGHT);
                            go.SetOrient();
                        }
                        else
                        {
                            go.SetDirection(BulletDirection.LEFT);
                            go.SetOrient();
                        }


                    }
                    PlayerBehaviour p = GameObject.FindObjectOfType<PlayerBehaviour>();
                    p.changeOrientation();
                    Camera cam = Camera.main;
                    cam.orthographicSize = 2.5f;
                    screenOrientation = Orientation.LandscapeRight;
                }
                break;
            case ScreenOrientation.LandscapeLeft:
                if (screenOrientation != Orientation.LandscapeLeft)
                {
                   
                    foreach (BackgroundStarsBehaviour go in Resources.FindObjectsOfTypeAll(typeof(BackgroundStarsBehaviour)) as BackgroundStarsBehaviour[])
                    {
                        go.ChangeOrientation();
                    }
                    foreach (BulletBehaviour go in Resources.FindObjectsOfTypeAll(typeof(BulletBehaviour)) as BulletBehaviour[])
                    {
                        if (go.bulletType == BulletType.PLAYER)
                        {
                            go.SetDirection(BulletDirection.RIGHT);
                            go.SetOrient();
                        }
                        else
                        {
                            go.SetDirection(BulletDirection.LEFT);
                            go.SetOrient();
                        }

                    }
                    PlayerBehaviour p = GameObject.FindObjectOfType<PlayerBehaviour>();
                    p.changeOrientation();
                    Camera cam = Camera.main;
                    cam.orthographicSize = 2.5f;
                    screenOrientation = Orientation.LandscapeLeft;
                }
                break;
            case ScreenOrientation.PortraitUpsideDown:
                if(screenOrientation != Orientation.PortraitUpsideDown)
                {                 
                    foreach (BackgroundStarsBehaviour go in Resources.FindObjectsOfTypeAll(typeof(BackgroundStarsBehaviour)) as BackgroundStarsBehaviour[])
                    {
                        go.ChangeOrientation();
                    }                    
                    
                    PlayerBehaviour p = GameObject.FindObjectOfType<PlayerBehaviour>();
                    p.changeOrientation();
                    Camera cam = Camera.main;
                    cam.orthographicSize = 5;
                    screenOrientation = Orientation.PortraitUpsideDown;
                }
                break;


        }
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
