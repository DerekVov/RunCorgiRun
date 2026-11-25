using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Corgi : MonoBehaviour
{
    public Sprite NormalSprite;
    public Sprite DrunkSprite;
    public UI Ui;
    public StartScreen StartScreen;
    
    
    private SpriteRenderer corgiSpriteRenderer;
    private Coroutine soberUpCoroutine;
    private bool isDrunk = false;
    private bool isPlastered = false;

    private int randomMoveCounter = 0;
    private int lastRandomDirection = 0;

    public void Awake()
    {
        corgiSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (isPlastered)
        {
            MoveRandomly();
        }
    }

    public void Reset()
    {
        isPlastered = false;
        isDrunk = false;
        ChangeToNormalSprite();
        corgiSpriteRenderer.flipX = false;
        transform.position = Vector3.zero;
    }

    private void MoveRandomly()
    {
        int direction = lastRandomDirection;
        
        if (randomMoveCounter == 0)
        {
            // Pick a new direction
            direction = Random.Range(0, 4);
            randomMoveCounter = Random.Range(GameParameters.CorgiMinimumRandomMoveLength, GameParameters.CorgiMaximumRandomMoveLength);
            lastRandomDirection = direction;
        }

        switch (direction)
        {
            case 0:
                Move(new Vector2(1, 0));
                break;
            case 1:
                Move(new Vector2(-1, 0));
                break;
            case 2:
                Move(new Vector2(0, 1));
                break;
            case 3:
                Move(new Vector2(0, -1));
                break;
        }
    }
    public void MoveManually(Vector2 direction){
        if (!StartScreen.isPlaying())
        {
            return;
        }
        if (isPlastered)
        {
            return;
        }
        Move(direction);
    }
    public void Move(Vector2 direction)
    {
        direction = ApplyDrunkenness(direction);
        
        FaceCorrectDirection(direction);
        
        Vector2 movement = direction * GameParameters.CorgiMoveSpeed * Time.deltaTime;
        corgiSpriteRenderer.transform.Translate(movement);
        
        corgiSpriteRenderer.transform.position = SpriteTools.ConstrainToScreen(corgiSpriteRenderer);
    }

    private Vector2 ApplyDrunkenness(Vector2 direction)
    {
        if (!isDrunk)
        {
            return direction;
        }

        direction.x = direction.x * -1;
        direction.y = direction.y * -1;
        
        return direction;
    }
    
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Moonshine")
        {
            Destroy(other.gameObject);
            GetPlastered();
        }
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Beer")
        {
            GetDrunk();
            Destroy(other.gameObject);
        }

        if (other.tag == "Bone")
        {
            AddPointToScore();
            Destroy(other.gameObject);
        }

        if (other.tag == "Pill")
        {
            SoberUp();
            Destroy(other.gameObject);
        }
    }

    private void AddPointToScore()
    {
        ScoreKeeper.AddPoint();
        Ui.ShowScore();
    }
    
    private void Inebriate()
    {
        ChangeToDrunkSprite();
        StartSoberingUp();
    }
    
    private void GetPlastered()
    {
        isPlastered = true;
        Inebriate();
    }
    
    private void GetDrunk()
    {
        isDrunk = true;
        Inebriate();
    }

    private void StartSoberingUp()
    {
        if (soberUpCoroutine != null)
        {
            StopCoroutine(soberUpCoroutine);
        }
        
        soberUpCoroutine = StartCoroutine(CountdownUntilSober());
    }

    IEnumerator CountdownUntilSober()
    {
        yield return new WaitForSeconds(GameParameters.CorgiDrunkSeconds);
        SoberUp();
    }

    private void SoberUp()
    {
        isDrunk = false;
        isPlastered = false;
        randomMoveCounter = 0;
        ChangeToNormalSprite();
    }

    private void ChangeToNormalSprite()
    {
        corgiSpriteRenderer.sprite = NormalSprite;
    }
    
    private void ChangeToDrunkSprite()
    {
        corgiSpriteRenderer.sprite = DrunkSprite;
    }
    
    private void FaceCorrectDirection(Vector2 direction) 
    {
        // If moving right
        if (direction.x > 0) 
        {
            corgiSpriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            corgiSpriteRenderer.flipX = true;
        }
    }
}