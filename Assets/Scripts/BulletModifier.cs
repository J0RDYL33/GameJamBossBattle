using UnityEngine;

public class BulletModifier : MonoBehaviour
{
    public Color targetColor = Color.green;
    private SpriteRenderer sr;

    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void UpdateProperties()
    {
        targetColor = sr.color;
        //GetComponent<SpriteRenderer>().color = newCol;
    }
}
