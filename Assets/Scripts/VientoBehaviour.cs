using UnityEngine;
using UnityEngine.InputSystem;

public class VientoBehaviour : MonoBehaviour
{
    // Update is called once per frame
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            animator.SetBool("Viento", true);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            animator.SetBool("Viento", false);
        }
    }
}
