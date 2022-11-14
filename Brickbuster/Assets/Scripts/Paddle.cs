using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    private SpriteRenderer SpriteRenderer;

    private void Awake()
    {
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        Cursor.visible = false;
    }

    public void Reset()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(0f, 0f, 0f);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        Move();
        ConstrainToScreen();
    }

    private void Move()
    {
        SpriteRenderer.transform.position = new Vector3(GetMousePositionX(), SpriteRenderer.transform.position.y, 
            SpriteRenderer.transform.position.z);


    }

    private float GetMousePositionX()
    {
        Vector3 mouseScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        return mouseWorldPosition.x;
    }

    private void ConstrainToScreen()
    {
        SpriteRenderer.transform.position = SpriteTools.ConstrainSpriteToScreen(SpriteRenderer);
    }
}
