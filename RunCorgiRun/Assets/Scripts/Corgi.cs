using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    public SpriteRenderer CorgiSpriteRenderer;
    public Sprite DrunkSprite;
    public Sprite NormalSprite;

    private bool isDrunk = false;
    private bool isPlastered = false;
    private int randMoveCount = 0;
    private int lastRandDirection = 0;

    public void Update()
    {
        if (isPlastered)
        {
            MoveRandomly();
        }
    }

    public void MoveManually(Vector2 direction)
    {
        if (isDrunk)
        {
            direction = ApplyDrunkenness(direction);
        }

        if (isPlastered)
        {
            return;
        }

        Move(direction);
    }

    private void MoveRandomly()
    {
        int direction = lastRandDirection;

        if (randMoveCount == 0)
        {
            direction = Random.Range(0, 3);            
            randMoveCount = Random.Range(GameParameters.CorgiMinNumRandomSteps, GameParameters.CorgiMaxNumRandomSteps);
            lastRandDirection = direction;
        }

        switch(direction)
        {
            case 0:
                // move right
                Move(new Vector2(1, 0));
                break;
            case 1:
                // move left
                Move(new Vector2(-1, 0));
                break;
            case 2:
                // move up
                Move(new Vector2(0, 1));
                break;
            case 3:
                // move down
                Move(new Vector2(0, -1));
                break;
        }
    }

    private void Move(Vector2 direction)
    {
        FaceCorrectDirection(direction);
        CorgiSpriteRenderer.transform.Translate(CalculateAmountToMove(direction));
        KeepOnScreen();
    }

    private Vector3 CalculateAmountToMove(Vector2 direction)
    {
        float amountX = direction.x * GameParameters.CorgiMoveAmount;
        float amountY = direction.y * GameParameters.CorgiMoveAmount;

        return new Vector3(amountX, amountY, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Beer")
        {
            GetDrunk();
        }

        if (collision.gameObject.tag == "Pill")
        {
            SoberUp();
        }

        if (collision.gameObject.tag == "Bone")
        {
            ScoreKeeper.AddToScore(GameParameters.BonePoints);
        }

        if (collision.gameObject.tag == "Moonshine")
        {
            GetPlastered();
        }

        if (collision.gameObject.tag == "Poop")
        {
            return;
        }

        Destroy(collision.gameObject);

    }

    private Vector2 ApplyDrunkenness(Vector2 directions)
    {
        directions.x *= -1;
        directions.y *= -1;

        return directions;
    }

    private void GetDrunk()
    {
        isDrunk = true;
        Inebriate();
    }

    private void GetPlastered()
    {
        isPlastered = true;
        Inebriate();
    }

    private void SoberUp()
    {
        SwitchToNormalSprite();
        isDrunk = false;
        isPlastered = false;
    }

    private void Inebriate()
    {
        SwitchToDrunkSprite();
        StartSoberUpTimer();
    }

    private void SwitchToDrunkSprite()
    {
        CorgiSpriteRenderer.sprite = DrunkSprite;
    }

    private void SwitchToNormalSprite()
    {
        CorgiSpriteRenderer.sprite = NormalSprite;
    }

    private void StartSoberUpTimer()
    {
        StartCoroutine(CountdownUntilSoberedUp());
    }

    IEnumerator CountdownUntilSoberedUp()
    {
        yield return new WaitForSeconds(GameParameters.CorgiTimeUntilSoberedUp);
        SoberUp();
    }

    private void FaceCorrectDirection(Vector2 direction)
    {
        if (direction.x == 1) // face right
        {
            CorgiSpriteRenderer.flipX = false;
        }
        else if (direction.x == -1) // face left
        {
            CorgiSpriteRenderer.flipX = true;
        }
    }

    private void KeepOnScreen()
    {
        CorgiSpriteRenderer.transform.position = SpriteTools.ConstrainToScreen(CorgiSpriteRenderer);
    }

}
