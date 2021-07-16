using UnityEngine;

public class Apple : MonoBehaviour
{
    public BoxCollider2D gridArea;

    private void Start()
    {
        RandomizePosition();
    }

    public void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

}
