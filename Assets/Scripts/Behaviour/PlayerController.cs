using UnityEngine;

public class PlayerController : Character
{
    [SerializeField] private float speed, bombCD;
    [SerializeField] private GameObject bombPrefab;
    private Transform character;
    private float bombCDCount;
    private void Awake()
    {
        character = GetComponent<Transform>();
        bombCDCount = bombCD;
    }
    private void FixedUpdate()
    {
        bombCDCount += Time.fixedDeltaTime;

        if (isStun) return;

        Move();
        Action();
    }

    private void Action()
    {
        if (Input.GetButton("Jump") && bombCDCount >= bombCD)
        {
            Instantiate(bombPrefab, gameObject.transform.localPosition, Quaternion.identity);
            bombCDCount = 0;
        }
    }

    protected override void Move()
    {
        var move = new Vector3(Input.GetAxis("Horizontal") * Time.fixedDeltaTime,
            Input.GetAxis("Vertical") * Time.fixedDeltaTime) * speed;
        character.Translate(move);
    }
}
