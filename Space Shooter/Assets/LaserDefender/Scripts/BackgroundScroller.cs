using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 0.02f;
    [SerializeField] Material material;
    Vector2 offset;

    private void Start()
    {
        offset = new Vector2(0f, backgroundScrollSpeed);
    }

    private void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
