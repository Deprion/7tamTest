using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class Bomb : MonoBehaviour
{
    [SerializeField] private float timeToActivation, timeToDetonate, timeStun;
    private Rigidbody2D rigidbodyComponent;
    private void Awake()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        StartCoroutine(Activation());
        StartCoroutine(Detonate());
    }

    private IEnumerator Activation()
    {
        rigidbodyComponent.simulated = false;
        while (timeToActivation >= 0)
        {
            yield return new WaitForEndOfFrame();
            timeToActivation -= Time.deltaTime;
        }
        rigidbodyComponent.simulated = true;
    }

    private IEnumerator Detonate()
    {
        yield return new WaitForSeconds(timeToDetonate);
        DestroyObj();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Character>().Stun(timeStun);
        }
        DestroyObj();
    }
    private void DestroyObj()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }
}
