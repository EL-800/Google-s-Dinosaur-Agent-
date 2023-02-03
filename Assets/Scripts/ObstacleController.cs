using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime * (1 + ScoreController.scoreModifier);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }       
}
