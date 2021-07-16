using UnityEngine;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    private Vector2 direction { get; set; }
    private List<Transform> segments { get; set; }

    public Transform segmentPrefab;
    public int length { get; set; }


    private void Awake()
    {
        direction = Vector2.zero;
        segments = new List<Transform>();
        length = 0;
    }

    private void Start()
    {
        SetDefaultLength();
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && direction != Vector2.up)
        {
            direction = Vector2.down;
        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && direction != Vector2.down)
        {
            direction = Vector2.up;
        }
        else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && direction != Vector2.left)
        {
            direction = Vector2.right;
        }
        else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && direction != Vector2.right)
        {
            direction = Vector2.left;
        }
    }

    private void FixedUpdate()
    {
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y,
            0.0f);
    }

    private void SetDefaultLength()
    {
        segments.Add(this.transform);

        for (int i = 0; i < 3; i++)
        {
            Grow();
        }
    }

    public void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);

        var renderer = segment.GetComponent<SpriteRenderer>();
        renderer.color = new Color(segments.Count * 0.03f, renderer.color.g, renderer.color.b, renderer.color.a);

        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
        length++;
    }


    public void ResetState()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
            length--;
        }
        segments.Clear();

        SetDefaultLength();

        this.transform.position = Vector3.zero;
        direction = Vector2.zero;
    }


}
