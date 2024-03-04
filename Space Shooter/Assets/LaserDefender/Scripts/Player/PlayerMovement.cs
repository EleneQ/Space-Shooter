using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    [Header("Movement Bounds")]
    [SerializeField] float boundsOffset = 1f;
    float xMin, xMax;
    float yMin, yMax;

    private void Start()
    {
        SetUpMoveBoundaries();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float deltaY = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
        float deltaX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed; 

        float posX = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        float posY = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(posX, posY);
    }

    private void SetUpMoveBoundaries()
    {
        Camera cam = Camera.main;

        #region Explanation
        //viewportToWorldPoint converts the screen boundary positions from screen space to world space. using it so
        //that if I change the size of the camera, I don't have to also change the min and max values all the time.
        #endregion
        xMin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + boundsOffset;
        xMax = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - boundsOffset; 

        yMin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + boundsOffset;
        yMax = cam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - boundsOffset;
    }
}
