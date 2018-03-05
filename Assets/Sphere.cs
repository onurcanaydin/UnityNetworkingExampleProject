using UnityEngine;
using UnityEngine.Networking;

public class Sphere : NetworkBehaviour {

    bool isClicked = false;
    private Transform newObj;
    public Transform sphere;
    public Color mouseOverColor;
    private Color defaultColor;
    private Renderer r;
    private Vector3 pos;


    private void Start()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        r = GetComponent<Renderer>();
        defaultColor = r.material.color;
    }

    private void OnMouseEnter()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (isClicked == false)
        {
            r.material.color = mouseOverColor;
        }   
    }

    private void OnMouseExit()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        if (isClicked == false)
        {
            r.material.color = defaultColor;
        }
    }

    /*private void OnMouseDown()
    {
        if (isClicked == false)
        {
            isClicked = true;
            pos = transform.position + new Vector3(2, 0, 0);
            newObj = Instantiate(sphere, pos, Quaternion.identity);
            newObj.gameObject.GetComponent<Renderer>().material.color = defaultColor;
            r.material.color = defaultColor;
        }
    }*/

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    private void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (isClicked == false)
        {
            float x = Input.GetAxis("Horizontal") * Time.deltaTime * 5.0f;
            float y = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f;

            transform.Translate(x, y, 0);
        } 
    }
}