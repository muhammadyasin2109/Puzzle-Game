using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropPuzzle : MonoBehaviour
{
    public int tempIndex;
    public int tempSpawner;

    public GameManager gameManager;
    public Transform targetPlace;
    public Transform initialPlace;
    public Vector3 mOffset;

    public bool setup;
    public bool locked;
    public bool status;

    float mZCoord;

    // Update is called once per frame
    void Update()
    {
        if (setup)
        {
            gameManager = GameObject.Find($"GameManager").GetComponent<GameManager>();
            targetPlace = GameObject.Find($"Target-{tempIndex}").GetComponent<Transform>();
            initialPlace = GameObject.Find($"Spawner-{tempSpawner}").GetComponent<Transform>();

            setup = false;
        }
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDown()
    {
        if (!locked)
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        }
    }

    private void OnMouseDrag()
    {
        if (!locked)
        {
            transform.position = GetMouseAsWorldPoint() + mOffset;
        }
    }

    private void OnMouseUp()
    {
        if (status)
        {
            transform.localScale = targetPlace.localScale;
            transform.position = new Vector2(targetPlace.position.x, targetPlace.position.y);
            gameManager.progressPuzzle++;

            locked = true;
        }
        else
        {
            transform.position = new Vector2(initialPlace.position.x, initialPlace.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == $"Target-{tempIndex}")
            status = true;
        else
            status = false;
    }
}
