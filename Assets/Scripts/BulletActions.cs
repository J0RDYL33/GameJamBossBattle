using System.Collections;
using UnityEngine;

public class BulletActions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
