using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] public float speed = 5f;  
    
    private int direction = 1;
    private bool isMoving = false;
    private Transform characterSprite;
    private float characterSpriteScale;

    [SerializeField] private float borderRight;
    [SerializeField] private float borderLeft;

    private void Start()
    {
        characterSprite = transform.parent.Find("CharacterSprite");
        characterSpriteScale = characterSprite.localScale.x;
    }

    void Update()
    {
        if (isMoving)
        {
            characterSprite.Translate(Vector2.right * speed * Time.deltaTime * direction);
        }
    }

    public void Move()
    {
        isMoving = true;
    }

    public void Stop()
    {
        isMoving = false;
    }

    public void SetDirection(int newDirection)
    {
        direction = newDirection;
    }

    public void RotateCharacterSprite()
    {
        if (characterSprite != null)
        {
            characterSprite.localScale = new Vector3(Mathf.Sign(direction) * characterSpriteScale, characterSpriteScale, characterSpriteScale);
        }
    }

    public int GetDirection()
    {
        return direction;
    }

}