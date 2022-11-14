using UnityEngine;

public static class SpriteTools
{

    public static Vector3 ConstrainSpriteToScreen(SpriteRenderer spriteRenderer)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(spriteRenderer.transform.position);

        if (SpriteRight(spriteRenderer) > Screen.width)
            screenPosition.x = Screen.width - SpriteHalfWidth(spriteRenderer);

        if (SpriteLeft(spriteRenderer) < 0)
            screenPosition.x = SpriteHalfWidth(spriteRenderer);

        if (SpriteTop(spriteRenderer) > Screen.height)
            screenPosition.y = Screen.height - SpriteHalfHeight(spriteRenderer);

        if (SpriteBottom(spriteRenderer) < 0)
            screenPosition.y = SpriteHalfHeight(spriteRenderer);

        return Camera.main.ScreenToWorldPoint(screenPosition);
    }

    public static Vector3 ConstrainSpriteCenterToScreen(SpriteRenderer spriteRenderer)
    {

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(spriteRenderer.transform.position);

        if (screenPosition.x > Screen.width)
            screenPosition.x = Screen.width;
        if (screenPosition.x < 0)
            screenPosition.x = 1;
        if (screenPosition.y > Screen.height)
            screenPosition.y = Screen.height;
        if (screenPosition.y < 0)
            screenPosition.y = 1;

        return Camera.main.ScreenToWorldPoint(screenPosition);
    }

    public static void OrientSpriteHorizontally(SpriteRenderer spriteRenderer, float direction)
    {
        if (direction > 0)
            spriteRenderer.flipX = false;
        else
            spriteRenderer.flipX = true;
    }

    private static float SpriteRight(SpriteRenderer spriteRenderer)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(spriteRenderer.transform.position);
        return screenPosition.x + SpriteHalfWidth(spriteRenderer);
    }

    private static float SpriteLeft(SpriteRenderer spriteRenderer)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(spriteRenderer.transform.position);
        return screenPosition.x - SpriteHalfWidth(spriteRenderer);
    }

    private static float SpriteTop(SpriteRenderer spriteRenderer)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(spriteRenderer.transform.position);
        return screenPosition.y + SpriteHalfHeight(spriteRenderer);
    }

    private static float SpriteBottom(SpriteRenderer spriteRenderer)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(spriteRenderer.transform.position);
        return screenPosition.y - SpriteHalfHeight(spriteRenderer);
    }

    private static float SpriteHalfWidth(SpriteRenderer spriteRenderer)
    {
        return spriteRenderer.sprite.rect.width / 4;
    }

    private static float SpriteHalfHeight(SpriteRenderer spriteRenderer)
    {
        return spriteRenderer.sprite.rect.height / 4;
    }
}