using UnityEngine;

public class WeaponPosition : MonoBehaviour
{
    public Vector2 PointerPossition { get; set; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (PointerPossition - (Vector2)transform.position).normalized;
        transform.right = direction;
        PointerPossition = GetPointerInput();


        Vector2 scale = transform.localScale;
        if (direction.x < 0)
        {
            scale.y = -Mathf.Abs(scale.y);
        }
        else
        {
            scale.y = Mathf.Abs(scale.y);
        }
    }
    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
