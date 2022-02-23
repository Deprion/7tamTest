using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private Transform character;
    [SerializeField] private float speed, bombCD;
    [SerializeField] private GameObject bombPrefab;
    private float bombCDCount;
    private void Awake()
    {
        character = GetComponent<Transform>();
        bombCDCount = bombCD;
    }
    private void FixedUpdate()
    {
        MoveCharacter();
        Action();
    }

    private void Action()
    {
        if (Input.GetButton("Jump") && bombCDCount >= bombCD)
        {
            Instantiate(bombPrefab, gameObject.transform.localPosition, Quaternion.identity);
            bombCDCount = 0;
        }
        bombCDCount += Time.fixedDeltaTime;
    }

    private void MoveCharacter()
    {
        var move = new Vector3(Input.GetAxis("Horizontal") * Time.fixedDeltaTime,
            Input.GetAxis("Vertical") * Time.fixedDeltaTime) * speed;
        character.Translate(move);
    }
}
