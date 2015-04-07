using Pathfinding;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Seeker))]
//[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody2D))]
public class ReceptorAI : MonoBehaviour
{
    #region Public Fields + Properties + Events + Delegates

    public float directionChangeInterval = 1;
    public ForceMode2D fMode;

    public float maxHeadingChange = 30;

    //The max distance form the AI to a waypoint for it to continue to the next waypoint
    public float nextWaypointDisance = 3f;

    //The Calculated Path
    public Path path;

    [HideInInspector]
    public bool pathfinding = false;

    public float seekTime = 1f;

    //The AI's Speed [per second]
    public float speed = 300f;

    //What to seek
    public Transform target;

    //How many times each second we update our path
    public float updateRate = 2f;

    #endregion Public Fields + Properties + Events + Delegates

    //private CharacterController controller;

    #region Private Fields + Properties + Events + Delegates

    //The waypoint we are currently moving towards;
    private int currentWaypoint = 0;

    private bool pathIsEnded = false;
    private Rigidbody2D rb;

    private bool searchingForItem = false;

    //Caching
    private Seeker seeker;

    #endregion Private Fields + Properties + Events + Delegates

    #region Public Methods

    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    #endregion Public Methods

    #region Private Methods

    private void FixedUpdate()
    {
        if (target == null)
        {
            if (!searchingForItem)
            {
                searchingForItem = true;
                StartCoroutine(SearchForObject());
            }

            return;
        }

        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return;
            }

            pathIsEnded = true;
        }

        pathIsEnded = false;

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;

        dir *= speed * Time.fixedDeltaTime;

        //Move the AI:
        rb.AddForce(dir, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);

        if (dist < nextWaypointDisance)
        {
            currentWaypoint++;
            return;
        }
    }

    private IEnumerator SearchForObject()
    {
        
        GameObject[] gos = GameObject.FindGameObjectsWithTag("ExternalReceptor");
         
        bool FoundObject = false;

        foreach (GameObject go in gos)
        {

            ExtraCellularProperties objProps = (ExtraCellularProperties)go.GetComponent("ExtraCellularProperties");

                if (!objProps.isActive)
                {
                    objProps = null;
                    continue;

                }
                else
                {
                    objProps = null;
                    searchingForItem = false;
                    target = go.transform;
                    StartCoroutine(UpdatePath());
                    break;
                }
        };

        gos = null;

        if (!FoundObject)
        {
                    yield return new WaitForSeconds(seekTime);
                    StartCoroutine(SearchForObject());
        }



    }

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (target == null)
        {
            if (!searchingForItem)
            {
                searchingForItem = true;
                StartCoroutine(SearchForObject());
            }

            return;
        }

        StartCoroutine(UpdatePath());
    }

    private IEnumerator UpdatePath()
    {
        if (target == null)
        {
            if (!searchingForItem)
            {
                searchingForItem = true;
                StartCoroutine(SearchForObject());
            }
        }
        else
        {
            ExtraCellularProperties objProps = (ExtraCellularProperties)target.GetComponent("ExtraCellularProperties");

            if (!objProps.isActive)
            {
                searchingForItem = true;
                StartCoroutine(SearchForObject());
            }
            else
            {
                seeker.StartPath(transform.position, target.position, OnPathComplete);

                yield return new WaitForSeconds(1 / updateRate);

                StartCoroutine(UpdatePath());
            }

            objProps = null;

        }
    }

    #endregion Private Methods
}