using UnityEngine;
using UnityEngine.AI;

public class PlayerMover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform target;
    private NavMeshAgent agent;
    private Animator animator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animator.SetFloat("Velocity", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    agent.destination = hit.point;
                    agent.speed = Input.GetKey(KeyCode.LeftShift) ? 5f : 1.5f;
                    Debug.Log("Speed: " + agent.speed);
                }
            }
        }

        float speed = agent.velocity.magnitude;
        animator.SetFloat("Velocity", speed);

        // Parada estable sin orbitar
        if (!agent.pathPending && agent.hasPath)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.ResetPath();
                agent.velocity = Vector3.zero;
                animator.SetFloat("Velocity", 0f);
            }
        }
    }
}
