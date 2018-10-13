using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling_Parallax : MonoBehaviour {

    /// <summary>
    /// Olá, esse script vai servir para alinhar as coisas, com o tempo e com os pontos que o player vai ganhar^^
    /// </summary>

    public float speed = 1;
    public List<SpriteRenderer> sprites = new List<SpriteRenderer>();
    public Direction dir = Direction.Right;


    private float heightCamera;
    private float widthCamera;

    private Vector3 positionCam;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
        heightCamera = 2f * cam.orthographicSize;
        widthCamera = heightCamera * cam.aspect;
    }

    void Update()
    {
        foreach (var item in sprites)
        {
            if (dir == Direction.Left)
            {
                if (item.transform.position.x + item.bounds.size.x / 2 < cam.transform.position.x - widthCamera / 2)
                {
                    SpriteRenderer sprite = sprites[0];
                    foreach (var i in sprites)
                    {
                        if (i.transform.position.x > sprite.transform.position.x)
                            sprite = i;
                    }

                    item.transform.position = new Vector2((sprite.transform.position.x + (sprite.bounds.size.x / 2) + (item.bounds.size.x / 2)), sprite.transform.position.y);
                }
            }
            else if (dir == Direction.Right)
            {
                if (item.transform.position.x - item.bounds.size.x / 2 > cam.transform.position.x + widthCamera / 2)
                {
                    SpriteRenderer sprite = sprites[0];
                    foreach (var i in sprites)
                    {
                        if (i.transform.position.x < sprite.transform.position.x)
                            sprite = i;
                    }

                    item.transform.position = new Vector2((sprite.transform.position.x - (sprite.bounds.size.x / 2) - (item.bounds.size.x / 2)), sprite.transform.position.y);
                }
            }

            if (dir == Direction.Left)
                item.transform.Translate(new Vector2(Time.deltaTime * speed * -1, 0));
            else if (dir == Direction.Right)
                item.transform.Translate(new Vector2(Time.deltaTime * speed, 0));
        }

    }
}

public enum Direction
{
    Left,
    Right
}

