using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public abstract class Character : MonoBehaviour
{
    protected bool isStun = false;
    protected abstract void Move();
    public virtual void Stun(float s)
    {
        StopAllCoroutines();
        StartCoroutine(CoroutineStun(s));
    }
    protected virtual IEnumerator CoroutineStun(float s)
    {
        isStun = true;
        while (s >= 0)
        {
            yield return new WaitForEndOfFrame();
            s -= Time.deltaTime;
        }
        isStun = false;
    }
}