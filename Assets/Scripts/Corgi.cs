using UnityEngine;

public class Corgi : MonoBehaviour
{
    public SpriteRenderer corgiSpriteRenderer;
    

    public void Awake()
    {
        corgiSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Move(Vector2 direction)
    {
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
            print("uhhh, alcohol");
        }

        if (other.gameObject.tag == "Bone")
        {
            print("mmmm, bone");
        }
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
