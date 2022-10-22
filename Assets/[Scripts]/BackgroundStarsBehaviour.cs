using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundStarsBehaviour : MonoBehaviour
{
    public float verticalSpeed;
    public Boundary boundary;
    private GameController gameController;
    private void Start()
    {
      
        gameController = GameObject.FindObjectOfType<GameController>();        
    }
    // Update is called once per frame
    void Update()
    {        
        vMove();
        CheckBounds();
    }

    public void vMove()
    {
        switch (Screen.orientation)
        {
            case ScreenOrientation.Portrait:
                transform.position -= new Vector3(0.0f, verticalSpeed * Time.deltaTime);
                break;
            case ScreenOrientation.LandscapeLeft:
                transform.position -= new Vector3(verticalSpeed * Time.deltaTime, 0.0f);
                break;
            case ScreenOrientation.LandscapeRight:
                transform.position -= new Vector3(verticalSpeed * Time.deltaTime, 0.0f);
                break;
            case ScreenOrientation.PortraitUpsideDown:
                transform.position -= new Vector3(0.0f, verticalSpeed * Time.deltaTime);
                break;
        }
        
    }

    public void CheckBounds()
    {
        switch (Screen.orientation)
        {
            case ScreenOrientation.Portrait:
                if (transform.position.y < boundary.min)
                {
                    ResetStars();
                }
                break;
            case ScreenOrientation.LandscapeLeft:
                if (transform.position.x < boundary.min)
                {
                    ResetStars();
                }
                break;
            case ScreenOrientation.LandscapeRight:
                if (transform.position.x < boundary.min)
                {
                    ResetStars();
                }
                break;
            case ScreenOrientation.PortraitUpsideDown:
                if (transform.position.y < boundary.min)
                {
                    ResetStars();
                }
                break;
        }
      
    }

    public void ChangeOrientation()
    {       
        switch (Screen.orientation)
        {
            case ScreenOrientation.Portrait:
                //gameObject.transform.localRotation = Quaternion.EulerAngles(0, 0, 90);
                transform.eulerAngles = new Vector3(0, 0, 90);
                gameObject.transform.position = new Vector3(gameObject.transform.position.y, gameObject.transform.position.x, 0);
                //gameObject.transform.localScale = Vector3.one;
                break;
            case ScreenOrientation.LandscapeLeft:
                transform.eulerAngles = new Vector3(0, 0, 0);
                //gameObject.transform.localRotation = Quaternion.EulerAngles(0, 0, 0);
                gameObject.transform.position = new Vector3(gameObject.transform.position.y, gameObject.transform.position.x, 0);
                //gameObject.transform.localScale = Vector3.one * 1.5f;
                break;
            case ScreenOrientation.LandscapeRight:
                transform.eulerAngles = new Vector3(0, 0, 0);
                // gameObject.transform.localRotation = Quaternion.EulerAngles(0, 0, 0);
                gameObject.transform.position = new Vector3(gameObject.transform.position.y, gameObject.transform.position.x, 0);
                //gameObject.transform.localScale = Vector3.one * 1.5f;
                break;
            case ScreenOrientation.PortraitUpsideDown:
                transform.eulerAngles = new Vector3(0, 0, 90);
                //gameObject.transform.localRotation = Quaternion.EulerAngles(0, 0, 90);
                gameObject.transform.position = new Vector3(gameObject.transform.position.y, gameObject.transform.position.x, 0);
                //gameObject.transform.localScale = Vector3.one;
                break;
        }
    }

    public void ResetStars()
    {
        switch (Screen.orientation)
        {
            case ScreenOrientation.Portrait:
                transform.position = new Vector2(0.0f, boundary.max);
                break;
            case ScreenOrientation.LandscapeLeft:
                transform.position = new Vector2(boundary.max, 0.0f);
                break;
            case ScreenOrientation.LandscapeRight:
                transform.position = new Vector2(boundary.max, 0.0f);
                break;
            case ScreenOrientation.PortraitUpsideDown:
                transform.position = new Vector2(0.0f, boundary.max);
                break;
        }
        //transform.position = new Vector2( boundary.max, 0.0f);
    }
}
