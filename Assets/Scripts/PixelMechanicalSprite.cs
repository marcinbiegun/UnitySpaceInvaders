using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelMechanicalSprite : MonoBehaviour {

    public GameObject pixelPrefab;
    public int pixelSliceSize = 5;

    // Use this for initialization
    void Start () {
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
    }

    void CreateMechanicalPixel(float xPos, float yPos, int size, Color[] pixels) {
        var position = new Vector3(xPos, yPos, 0f);
        var pixel = Instantiate(pixelPrefab, position, Quaternion.identity);

        pixel.transform.SetParent(gameObject.transform);

        var pixelTexture = new Texture2D(size, size);
        pixelTexture.SetPixels(pixels);

        var pivot = new Vector2(0.5f, 0.5f);
        var pixelsPerUnit = 100f;
        var sprite = Sprite.Create(pixelTexture, new Rect(0.0f, 0.0f, pixelTexture.width, pixelTexture.height), pivot, pixelsPerUnit);

        pixel.GetComponent<SpriteRenderer>().sprite = sprite;
    }

}
