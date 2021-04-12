using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class drag : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 mOffset;
    private float mZCoord;
    private float doingAnything;
    private bool carLaunched;

    public int force = 200;

    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (carLaunched && GetComponent<Rigidbody>().velocity.magnitude <= 0.1)
        {
            doingAnything += Time.deltaTime;
        }
        if(doingAnything >3)
        { 
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    void OnMouseDown()

    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPoint();
    }

    private void OnMouseUp()
    {
        Vector3 directionToInitialPosition = initialPosition - transform.position;
        GetComponent<Rigidbody>().AddForce(directionToInitialPosition *force);
        GetComponent<Rigidbody>().useGravity = true;
        carLaunched = true;
    }

    private Vector3 GetMouseWorldPoint()

    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }



    void OnMouseDrag()

    {
        transform.position = new Vector3(GetMouseWorldPoint().x + mOffset.x, transform.position.y, transform.position.z);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "CubeBlock")
        {

        }
    }
       
}
