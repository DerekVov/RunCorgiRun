using UnityEngine;
using System.Collections;
using UnityEditorInternal;

public class Corgi : MonoBehaviour
{
    public SpriteRenderer corgiSpriteRenderer;
    public Sprite DrunkSprite;
    public Sprite SoberSprite;
    private bool isDrunk = false;

    public void Awake()
    {
        corgiSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Move(Vector2 direction)
    {
        direction = ApplyDrunkness(direction);
        FaceCorrectDirection(direction);
        Vector2 movement= direction * GameParameters.CorgiMoveSpeed * Time.deltaTime;
        corgiSpriteRenderer.transform.Translate(movement);

        corgiSpriteRenderer.transform.position = SpriteTools.ConstrainToScreen(corgiSpriteRenderer);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Beer")
        {
            getDrunk();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Bone")
        {
            Destroy(other.gameObject);
            ScorePoint();
        }
        
    }

    private void ScorePoint()
    {
        print("MONEY");
    }

    private void getDrunk()
    {
        ChangeToDrunkSprite();
    }

    private void ChangeToDrunkSprite()
    {
        corgiSpriteRenderer.sprite = DrunkSprite;
    }

    private void StartSoberingUp()
    {
        StartCoroutine(CountdownUntilSober());
    }

    private Vector2 ApplyDrunkness(Vector2 direction)
    {
        if (isDrunk)
        {
            direction.x = direction.x * -1;
            direction.y = direction.y * -1;
        }

        return direction;
    }

    IEnumerator CountdownUntilSober()
    {
        yield return new WaitForSeconds(GameParameters.CorgiDrunkSeconds);
        SoberUp();
    }

    private void SoberUp()
    {
        isDrunk = false;
        corgiSpriteRenderer.sprite = SoberSprite;
    }

    public void FaceCorrectDirection(Vector2 direction)
    {
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
