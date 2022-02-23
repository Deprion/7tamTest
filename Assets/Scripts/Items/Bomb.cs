using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Bomb : MonoBehaviour
{
    [SerializeField] private float timeToActivation;
    private IEnumerator coroutineDetonate, coroutineActivation;
    private BoxCollider2D boxCollider;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        coroutineActivation = Activation();
        coroutineDetonate = Detonate();
        StartCoroutine(coroutineActivation);
        StartCoroutine(coroutineDetonate);
    }

    private IEnumerator Activation()
    {
        while (timeToActivation >= 0)
        {
            yield return new WaitForEndOfFrame();
            timeToActivation -= Time.deltaTime;
        }
        boxCollider.enabled = true;
    }

    private IEnumerator Detonate()
    {
        yield return new WaitForSeconds(5f);
        DestroyObj();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Character>().Stun(2);
        }
        DestroyObj();
    }
    private void DestroyObj()
    {
        StopCoroutine(coroutineDetonate);
        StopCoroutine(coroutineActivation);
        Destroy(gameObject);
    }
}
