using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public struct ScreenBounds
{
    public Boundary horizontal;
    public Boundary vertical;
}


public class BulletBehaviour: MonoBehaviour
{
    [Header("Bullet Properties")]
    public BulletDirection bulletDirection;
    public float speed;
    public ScreenBounds bounds;
    public BulletType bulletType;

    private Vector3 velocity;
    private BulletManager bulletManager;

    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    void Update()
    {
        Move();
        CheckBounds();
    }

    void Move()
    {
        transform.position += velocity * Time.deltaTime;
    }

    void CheckBounds()
    {
        switch (Screen.orientation)
        {
            case ScreenOrientation.Portrait:
                if ((transform.position.x > bounds.horizontal.max) ||
                    (transform.position.x < bounds.horizontal.min) ||
                    (transform.position.y > bounds.vertical.max) ||
                    (transform.position.y < bounds.vertical.min))
                {
                    bulletManager.ReturnBullet(this.gameObject, bulletType);
                }
                break;
            case ScreenOrientation.LandscapeLeft:
                if ((transform.position.x > bounds.vertical.max) ||
                    (transform.position.x < bounds.vertical.min) ||
                    (transform.position.y > bounds.horizontal.max)||
                    (transform.position.y < bounds.horizontal.min))
                {
                    bulletManager.ReturnBullet(this.gameObject, bulletType);
                }
                break;
            case ScreenOrientation.LandscapeRight:
                if ((transform.position.x > bounds.vertical.max) ||
                    (transform.position.x < bounds.vertical.min) ||
                    (transform.position.y > bounds.horizontal.max)||
                    (transform.position.y < bounds.horizontal.min))
                {
                    bulletManager.ReturnBullet(this.gameObject, bulletType);
                }
                break;
            case ScreenOrientation.PortraitUpsideDown:
                if ((transform.position.x > bounds.horizontal.max) ||
                    (transform.position.x < bounds.horizontal.min) ||
                    (transform.position.y > bounds.vertical.max) ||
                    (transform.position.y < bounds.vertical.min))
                {
                    bulletManager.ReturnBullet(this.gameObject, bulletType);
                }
                break;
        }
        
    }

    public void SetDirection(BulletDirection direction)
    {
        switch (direction)
        {
            case BulletDirection.UP:
                velocity = Vector3.up * speed;
                break;
            case BulletDirection.RIGHT:
                velocity = Vector3.right * speed;
                break;
            case BulletDirection.DOWN:
                velocity = Vector3.down * speed;
                break;
            case BulletDirection.LEFT:
                velocity = Vector3.left * speed;
                break;
        }
    }

    public void SetOrient()
    {
        switch (Screen.orientation)
        {
            case ScreenOrientation.Portrait:
                transform.eulerAngles = new Vector3(0, 0, 0);
                gameObject.transform.position = new Vector3(gameObject.transform.position.y, gameObject.transform.position.x, 0);
                if (bulletType == BulletType.PLAYER)
                {
                    SetDirection(BulletDirection.UP);
                }
                else
                {
                    SetDirection(BulletDirection.DOWN);
                }
                break;
            case ScreenOrientation.LandscapeLeft:
                transform.eulerAngles = new Vector3(0, 0, -90);                
                gameObject.transform.position = new Vector3(gameObject.transform.position.y, gameObject.transform.position.x, 0);
                if (bulletType == BulletType.PLAYER)
                {
                    SetDirection(BulletDirection.RIGHT);
                }
                else
                {
                    SetDirection(BulletDirection.LEFT);
                }
                break;
            case ScreenOrientation.LandscapeRight:
                transform.eulerAngles = new Vector3(0, 0, -90);                
                gameObject.transform.position = new Vector3(gameObject.transform.position.y, gameObject.transform.position.x, 0);
                if (bulletType == BulletType.PLAYER)
                {
                    SetDirection(BulletDirection.RIGHT);
                }
                else
                {
                    SetDirection(BulletDirection.LEFT);
                }
                break;
            case ScreenOrientation.PortraitUpsideDown:
                transform.eulerAngles = new Vector3(0, 0, 0);                
                gameObject.transform.position = new Vector3(gameObject.transform.position.y, gameObject.transform.position.x, 0);
                if (bulletType == BulletType.PLAYER)
                {
                    SetDirection(BulletDirection.UP);
                }
                else
                {
                    SetDirection(BulletDirection.DOWN);
                }
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((bulletType == BulletType.PLAYER) ||
            (bulletType == BulletType.ENEMY && other.gameObject.CompareTag("Player")))
        {
            bulletManager.ReturnBullet(this.gameObject, bulletType);
        }
        
    }

}