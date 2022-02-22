using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Transform character;
    private Rigidbody2D rigid;
    [SerializeField] private float speed;
    private void Awake()
    {
        character = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        var move = new Vector3(Input.GetAxis("Horizontal") * Time.fixedDeltaTime,
            Input.GetAxis("Vertical") * Time.fixedDeltaTime) * speed;
        character.Translate(move);
    }
}
