using UnityEngine;

public class BoxMovement1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator animator;
    private float speed = 0f;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            speed += 0.1f;
            animator.SetFloat("BoxSpeed", speed);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            speed -= 0.1f;
            animator.SetFloat("BoxSpeed", speed);
        }
    }
}
