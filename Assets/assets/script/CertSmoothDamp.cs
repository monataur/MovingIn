using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CertSmoothDamp : MonoBehaviour
{
    float smoothTime = 0.3f;
    float yVelocity = 0.0f;
    public int screenX = Screen.width;
    public int screenY = Screen.height;
    void Update()
    {
        var newX = screenX / 2;
        var newY = screenY / 2;

        float newPosition = Mathf.SmoothDamp(transform.position.y, newY, ref yVelocity, smoothTime);
        transform.position = new Vector2(newX, newPosition);
    }
}
