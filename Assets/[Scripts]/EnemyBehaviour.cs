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
        switch (Screen.orientation)
        {
            case ScreenOrientation.Portrait:
                
                break;
            case ScreenOrientation.LandscapeLeft:
               
                break;
            case ScreenOrientation.LandscapeRight:
                
                break;
            case ScreenOrientation.PortraitUpsideDown:
                
                break;
        }
        var horizontalLength = horizontalBoundary.max - horizontalBoundary.min;
        transform.position = new Vector3(Mathf.PingPong(Time.time * horizontalSpeed, horizontalLength) - horizontalBoundary.max,
            transform.position.y - verticalSpeed * Time.deltaTime, transform.position.z);
    }

    public void CheckBounds()
    {
        if (transform.position.y < screenBounds.min)
        {
            ResetEnemy();
        }
    }

    public void ChangeOrientation()
    {

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
