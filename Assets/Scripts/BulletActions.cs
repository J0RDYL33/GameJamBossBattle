using System.Collections;
using UnityEngine;

public class BulletActions : MonoBehaviour
{
    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(DeleteMyself());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DeleteMyself()
    {

        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object we hit has a modifier script
        if (collision.gameObject.TryGetComponent(out BulletModifier modifier))
        {
            //Change Bullet Color
            modifier.UpdateProperties();
            sr.color = modifier.targetColor;
        }
    }
}
