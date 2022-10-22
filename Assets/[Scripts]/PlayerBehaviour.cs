using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Player Properties")]
    public float speed = 2.0f;
    public Boundary boundary;
    public float verticalPosition;
    public float verticalSpeed = 10.0f;
    public bool usingMobileInput = false;

    [Header("Bullet Properties")] 
    public Transform bulletSpawnPoint;
    public float fireRate = 0.2f;

    private bool oCheck = false;
    private Camera camera;
    private ScoreManager scoreManager;
    private BulletManager bulletManager;

    void Start()
    {
        //changeOrientation();
        bulletManager = FindObjectOfType<BulletManager>();

        camera = Camera.main;

        usingMobileInput = Application.platform == RuntimePlatform.Android ||
                           Application.platform == RuntimePlatform.IPhonePlayer;

        scoreManager = FindObjectOfType<ScoreManager>();

        InvokeRepeating("FireBullets", 0.0f, fireRate);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (usingMobileInput)
        {
            MobileInput();
        }
        else
        {
            ConventionalInput();
        }*/
        MobileInput();
        Move();

        if (Input.GetKeyDown(KeyCode.K))
        {
            scoreManager.AddPoints(10);
        }

    }

    public void MobileInput()
    {
        foreach (var touch in Input.touches)
        {
            var destination = camera.ScreenToWorldPoint(touch.position);
            transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime * verticalSpeed);
        }
    }

    public void ConventionalInput()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        transform.position += new Vector3(x, 0.0f, 0.0f);
    }
    
    public void Move()
    {
        float clampedPosition;
        switch (Screen.orientation)
        {
            case ScreenOrientation.Portrait:
                clampedPosition = Mathf.Clamp(transform.position.x, boundary.min, boundary.max);
                transform.position = new Vector2(clampedPosition, verticalPosition);
                break;
            case ScreenOrientation.LandscapeLeft:
                clampedPosition = Mathf.Clamp(transform.position.y, boundary.min, boundary.max);
                transform.position = new Vector2(verticalPosition, clampedPosition);
                break;
            case ScreenOrientation.LandscapeRight:
                clampedPosition = Mathf.Clamp(transform.position.y, boundary.min, boundary.max);
                transform.position = new Vector2(verticalPosition, clampedPosition);
                break;
            case ScreenOrientation.PortraitUpsideDown:
                clampedPosition = Mathf.Clamp(transform.position.x, boundary.min, boundary.max);
                transform.position = new Vector2(clampedPosition, verticalPosition);
                break;
        }
        
    }

    public void changeOrientation()
    {
        switch (Screen.orientation)
        {
            case ScreenOrientation.Portrait:
                //gameObject.transform.localRotation = Quaternion.EulerAngles(0, 0, 90);
                transform.eulerAngles = new Vector3(0, 0, 0);
                gameObject.transform.position = new Vector3(gameObject.transform.position.y, -4, 0);
                //gameObject.transform.localScale = Vector3.one;
                break;
            case ScreenOrientation.LandscapeLeft:
                transform.eulerAngles = new Vector3(0, 0, -90);
                //gameObject.transform.localRotation = Quaternion.EulerAngles(0, 0, 0);
                gameObject.transform.position = new Vector3(-4f, gameObject.transform.position.x, 0);
                //gameObject.transform.localScale = Vector3.one * 1.5f;
                break;
            case ScreenOrientation.LandscapeRight:
                transform.eulerAngles = new Vector3(0, 0, -90);
                // gameObject.transform.localRotation = Quaternion.EulerAngles(0, 0, 0);
                gameObject.transform.position = new Vector3(-4f, gameObject.transform.position.x, 0);
                //gameObject.transform.localScale = Vector3.one * 1.5f;
                break;
            case ScreenOrientation.PortraitUpsideDown:
                transform.eulerAngles = new Vector3(0, 0, 0);
                //gameObject.transform.localRotation = Quaternion.EulerAngles(0, 0, 90);
                gameObject.transform.position = new Vector3(gameObject.transform.position.y, -4, 0);
                //gameObject.transform.localScale = Vector3.one;
                break;
        }
    }

    void FireBullets()
    {
        var bullet = bulletManager.GetBullet(bulletSpawnPoint.position, BulletType.PLAYER);
    }
}
