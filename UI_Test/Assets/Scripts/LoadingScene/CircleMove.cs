using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleMove : MonoBehaviour
{
    [SerializeField] 
    private Image image;

    private float speed;
    private float radius;
    private float runningTime;
 
    private void Start() => ObjectInitialize();

    void Update() => MoveCircle();

    void ObjectInitialize()
    {
        speed = 5;
        radius = 0.5f;
        runningTime = 0;

        image.color = Color.gray;
        transform.localScale = Vector3.one / 2;
        transform.position = Vector3.zero;
        transform.localPosition = new Vector3(0, -300, 0);
    }

    void MoveCircle()
    {
        runningTime += Time.deltaTime * speed;
        transform.position = SetPosition();
        transform.localPosition = transform.localPosition - new Vector3(0, 350, 0);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
    }

    Vector3 SetPosition()
    {
        float x = -radius * Mathf.Cos(runningTime);
        float y = radius * Mathf.Sin(runningTime);
        return new Vector3(x, y, transform.localPosition.z);
    }
}
