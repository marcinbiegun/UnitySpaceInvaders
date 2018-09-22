using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PixelMechanicalSprite : MonoBehaviour {

    public GameObject pixelPrefab;
    public int pixelSliceSize = 5;
    private Vector3 originalScale = new Vector3(0f, 0f, 0f);

    // Use this for initialization
    void Start () {
        originalScale = gameObject.transform.localScale;
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);

        var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        var texture = spriteRenderer.sprite.texture;
        var textureRect = spriteRenderer.sprite.textureRect;
        var bounds = spriteRenderer.sprite.bounds;

        for (int x = 0; x < texture.width; x++) {
            if (x % pixelSliceSize != 0)
                continue;
            for (int y = 0; y < texture.height; y++) {
                if (y % pixelSliceSize != 0)
                    continue;
                float xPos = bounds.min.x + ((float)x / ((float)texture.width - 1f) * bounds.size.x);
                float yPos = bounds.min.y + ((float)y / ((float)texture.height - 1f) * bounds.size.y);

                var pixels = texture.GetPixels(x, y, pixelSliceSize, pixelSliceSize);

                CreateMechanicalPixel(xPos, yPos, pixelSliceSize, pixels);
            }
        }

        spriteRenderer.enabled = false;
        gameObject.transform.localScale = originalScale;


    }

    void CreateMechanicalPixel(float xPos, float yPos, int size, Color[] pixels) {
        // Don't create if average alpha for colors is small
        if (pixels.Average(p => p.a) < 0.01)
            return;

        var position = new Vector3(xPos, yPos, 0f);
        var pixel = Instantiate(pixelPrefab, position, Quaternion.identity);

        pixel.transform.SetParent(gameObject.transform);

        var pixelTexture = new Texture2D(size, size);
        pixelTexture.SetPixels(pixels);

        var pivot = new Vector2(0.5f, 0.5f);
        var pixelsPerUnit = 100f;
        var sprite = Sprite.Create(pixelTexture, new Rect(0.0f, 0.0f, pixelTexture.width, pixelTexture.height), pivot, pixelsPerUnit);

        pixel.GetComponent<SpriteRenderer>().sprite = sprite;

        var boxCollider = pixel.GetComponent<BoxCollider2D>();
        var spriteBounds = sprite.bounds;
        boxCollider.size = spriteBounds.size;
    }

}
