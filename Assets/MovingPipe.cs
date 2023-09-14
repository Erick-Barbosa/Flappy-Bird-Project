using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPipe : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float xLimit;
    [SerializeField] private float yLimitUp, yLimitDown;

    void Update()
    {
        if (transform.position.x < -xLimit) {
            float newRandomHeight = Random.Range(yLimitUp, yLimitDown);
            transform.position = new Vector2(xLimit, newRandomHeight);
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
