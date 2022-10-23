using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Boundary horizontalBoundary;
    public Boundary verticalBoundary;
    public Boundary screenBounds;
    public float horizontalSpeed;
    public float verticalSpeed;
    public Color randomColor;

    [Header("Bullet Properties")]
    public Transform bulletSpawnPoint;
    public float fireRate = 0.2f;
    
    
    private BulletManager bulletManager;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        bulletManager = FindObjectOfType<BulletManager>();
        ResetEnemy();
        InvokeRepeating("FireBullets", 0.3f, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    public void Move()
    {
        var horizontalLength = horizontalBoundary.max - horizontalBoundary.min;
        switch (Screen.orientation)
        {
            case ScreenOrientation.Portrait:              
                transform.position = new Vector3(Mathf.PingPong(Time.time * horizontalSpeed, horizontalLength) - horizontalBoundary.max,
                transform.position.y - verticalSpeed * Time.deltaTime, transform.position.z);
                break;
            case ScreenOrientation.LandscapeLeft:
                transform.position = new Vector3(transform.position.x - verticalSpeed * Time.deltaTime,
                    Mathf.PingPong(Time.time * horizontalSpeed, horizontalLength) - horizontalBoundary.max, transform.position.z);
                break;
            case ScreenOrientation.LandscapeRight:                
                transform.position = new Vector3(transform.position.x - verticalSpeed * Time.deltaTime,
                    Mathf.PingPong(Time.time * horizontalSpeed, horizontalLength) - horizontalBoundary.max, transform.position.z);
                break;
            case ScreenOrientation.PortraitUpsideDown:                
                transform.position = new Vector3(Mathf.PingPong(Time.time * horizontalSpeed, horizontalLength) - horizontalBoundary.max,
                transform.position.y - verticalSpeed * Time.deltaTime, transform.position.z);
                break;
        }
        
    }

    public void CheckBounds()
    {
        switch (Screen.orientation)
        {
            case ScreenOrientation.Portrait:
                if (transform.position.y < screenBounds.min)
                {
                    ResetEnemy();
                }
                break;
            case ScreenOrientation.LandscapeLeft:
                if (transform.position.x < screenBounds.min)
                {
                    ResetEnemy();
                }
                break;
            case ScreenOrientation.LandscapeRight:
                if (transform.position.x < screenBounds.min)
                {
                    ResetEnemy();
                }
                break;
            case ScreenOrientation.PortraitUpsideDown:
                if (transform.position.y < screenBounds.min)
                {
                    ResetEnemy();
                }
                break;
        }
        
    }

    public void ChangeOrientation()
    {
        switch (Screen.orientation)
        {
            case ScreenOrientation.Portrait:
                transform.eulerAngles = new Vector3(0, 0, 0);
                Debug.Log(Screen.orientation);
                gameObject.transform.position = new Vector3(gameObject.transform.position.y, gameObject.transform.position.x, 0);
                break;
            case ScreenOrientation.LandscapeLeft:
                transform.eulerAngles = new Vector3(0, 0, -90);
                Debug.Log(Screen.orientation);
                gameObject.transform.position = new Vector3(gameObject.transform.position.y, gameObject.transform.position.x, 0);
                break;
            case ScreenOrientation.LandscapeRight:
                transform.eulerAngles = new Vector3(0, 0, -90);
                Debug.Log(Screen.orientation);
                gameObject.transform.position = new Vector3(gameObject.transform.position.y, gameObject.transform.position.x, 0);
                break;
            case ScreenOrientation.PortraitUpsideDown:
                transform.eulerAngles = new Vector3(0, 0, 0);
                Debug.Log(Screen.orientation);
                gameObject.transform.position = new Vector3(gameObject.transform.position.y, gameObject.transform.position.x, 0);
                break;
        }
    }

    public void ResetEnemy()
    {
        var RandomXPosition = Random.Range(horizontalBoundary.min, horizontalBoundary.max);
        var RandomYPosition = Random.Range(verticalBoundary.min, verticalBoundary.max);
        switch (Screen.orientation)
        {
            case ScreenOrientation.Portrait:
                RandomXPosition = Random.Range(horizontalBoundary.min, horizontalBoundary.max);
                RandomYPosition = Random.Range(verticalBoundary.min, verticalBoundary.max);
                horizontalSpeed = Random.Range(1.0f, 6.0f);
                verticalSpeed = Random.Range(1.0f, 3.0f);
                break;
            case ScreenOrientation.LandscapeLeft:
                RandomYPosition = Random.Range(horizontalBoundary.min, horizontalBoundary.max);
                RandomXPosition = Random.Range(verticalBoundary.min, verticalBoundary.max);
                verticalSpeed = Random.Range(1.0f, 6.0f);
                horizontalSpeed = Random.Range(1.0f, 3.0f);
                break;
            case ScreenOrientation.LandscapeRight:
                RandomYPosition = Random.Range(horizontalBoundary.min, horizontalBoundary.max);
                RandomXPosition = Random.Range(verticalBoundary.min, verticalBoundary.max);
                verticalSpeed = Random.Range(1.0f, 6.0f);
                horizontalSpeed = Random.Range(1.0f, 3.0f);
                break;
            case ScreenOrientation.PortraitUpsideDown:
                RandomXPosition = Random.Range(horizontalBoundary.min, horizontalBoundary.max);
                RandomYPosition = Random.Range(verticalBoundary.min, verticalBoundary.max);
                horizontalSpeed = Random.Range(1.0f, 6.0f);
                verticalSpeed = Random.Range(1.0f, 3.0f);
                break;
        }
        
        
        transform.position = new Vector3(RandomXPosition, RandomYPosition, 0.0f);

        List<Color> colorList = new List<Color>() {Color.red, Color.yellow, Color.magenta, Color.cyan, Color.white, Color.white};

        randomColor = colorList[Random.Range(0, 6)];
        spriteRenderer.material.SetColor("_Color", randomColor);
    }

    void FireBullets()
    {
        var bullet = bulletManager.GetBullet(bulletSpawnPoint.position, BulletType.ENEMY);
    }
}
