using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer sr;

    private Vector3 direction;

    public float gravity = -9.8f;
    public float strength = 5f;
    public float tilt = 5f;

    // Array including sprites for different states of bird
    public Sprite[] sprites;
    private int spriteIndex;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }


    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }


    private void OnEnable()
    {
        Vector3 position = transform.position;

        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }


    // Update is called once per frame
    void Update()
    {
        // Taking input using space button and left mouse button
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        // Taking input for touchscreen
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;
    }


    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        if (spriteIndex < sprites.Length && spriteIndex >= 0)
        {
            sr.sprite = sprites[spriteIndex];
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacles"))
        {
            FindObjectOfType<GameManager>().GameOver();
        }

        else if (other.gameObject.CompareTag("Scoring"))
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
