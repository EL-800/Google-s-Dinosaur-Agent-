using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMovement : MonoBehaviour
{
    [SerializeField] private Vector2 speed;    
    private Vector2 offset;
    private Material material;    

    private void Awake()
    {
        material = gameObject.GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        offset = speed * Time.deltaTime * (1 + ScoreController.scoreModifier);
        material.mainTextureOffset += offset;
    }
}
