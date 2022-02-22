using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject stonePrefab;
    [SerializeField] private Transform levelParent;
    [SerializeField] private float posX, posY, offsetX;
    private void Awake()
    {
        SpawnStones();
    }

    private void SpawnStones()
    {
        float tempX = posX;
        for (int i = 0; i < 4; i++) // rows
        {
            for (int j = 0; j < 8; j++) // columns
            {
                var obj = Instantiate(stonePrefab, levelParent, false);
                obj.transform.localPosition = new Vector2(tempX, posY);
                tempX += 2.2f; // distance between stones on X axis
            }
            posY -= 2f; // distance between stones on Y axis
            posX -= offsetX;
            tempX = posX;
        }
    }
}
