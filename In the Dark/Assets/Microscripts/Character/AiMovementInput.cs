using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Seeker))]
[RequireComponent(typeof(IFindTarget))]
public abstract class AiMovementInput : MonoBehaviour, IHaveDirection
{
    private Seeker seeker;
    protected IFindTarget targetSystem;

    protected Path currentPath;
    protected int currentWaypoint;
    private float currentPathUpdateCooldown;
    private float pathUpdateCooldown;
    private Vector3 previousTargetPosition;

    [SerializeField] private Vector2 pathUpdateCooldownRange = new Vector2(0.25f, 0.35f);
    [SerializeField] private float nextWaypointDistance = 2f;


    public Vector2 Direction { get; protected set; }


    private void Awake()
    {
        seeker = GetComponent<Seeker>();
        targetSystem = GetComponent<IFindTarget>();
    }

    private void OnEnable()
    {
        pathUpdateCooldown = Random.Range(pathUpdateCooldownRange.x, pathUpdateCooldownRange.y);
    }

    protected virtual void FixedUpdate()
    {
        if (!NeedsNewPath())
        {
            UpdateDirection();
            UpdateWaypoint();
        }
    }

    private bool NeedsNewPath()
    {
        if (targetSystem.Target == null || !targetSystem.Target.gameObject.activeSelf)
        {
            targetSystem.FindTarget();
            GetNewPath();
            return true;
        }
        else if (currentPath == null || currentWaypoint >= currentPath.vectorPath.Count)
        {
            GetNewPath();
            return true;
        }
        else if (targetSystem.Target.position != previousTargetPosition && Time.time > currentPathUpdateCooldown)
        {
            currentPathUpdateCooldown = Time.time + pathUpdateCooldown;
            GetNewPath();
            return true;
        }

        return false;
    }

    protected abstract void UpdateDirection();

    private void UpdateWaypoint()
    {
        if (transform.WithinDistanceOf(currentPath.vectorPath[currentWaypoint], nextWaypointDistance))
        {
            currentWaypoint++;
        }
    }

    private void GetNewPath()
    {
        if (targetSystem.Target != null)
        {
            if (seeker.IsDone())
            {
                previousTargetPosition = targetSystem.Target.position;
                seeker.StartPath(transform.position, targetSystem.Target.position, OnPathComplete);
            }
        }
        else
        {
            Direction = Vector2.zero;
        }
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            currentPath = p;
            currentWaypoint = 0;
        }
    }
}
