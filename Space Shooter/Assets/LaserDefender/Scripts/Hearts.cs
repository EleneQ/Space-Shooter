using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    [SerializeField] Image[] heartsArray;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;

    public void DecreaseHealth(int health)
    {
        foreach(Image heart in heartsArray)
        {
            heart.sprite = emptyHeart;
        }
        for(int i = 0; i < health; i++)
        {
            heartsArray[i].sprite = fullHeart;
        }
    }
}
