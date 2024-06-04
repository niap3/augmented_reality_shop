using UnityEngine;

public class MarkerInteraction : MonoBehaviour
{
    public GameObject objectToShow;

    void Start()
    {
        if (objectToShow != null)
        {
            objectToShow.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
                {
                    if (objectToShow != null)
                    {
                        objectToShow.SetActive(true);
                        objectToShow.transform.position = transform.position;
                    }
                }
            }
        }
    }
}
