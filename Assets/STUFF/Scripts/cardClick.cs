using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CardClickHandler : MonoBehaviour
{
    public Dictionary<string, GameObject> tagToCanvasMap;
    public GameObject[] canvases;
    public GameObject button;
    private Button button_;
    private GameObject activeCanvas;
    public VideoPlayer videoMB;
    public VideoPlayer videoMY;

    void Start() 
    {
        button_ = button.GetComponent<Button>();
        tagToCanvasMap = new Dictionary<string, GameObject>();

        button.SetActive(false);

        // Populate the dictionary
        foreach (var canvas in canvases) 
        {
            canvas.SetActive(false);
            string canvasTag = canvas.tag;
            if (!tagToCanvasMap.ContainsKey(canvasTag))
            {
                tagToCanvasMap.Add(canvasTag, canvas);
            }
        }

        // Add listener to the button click event
        button_.onClick.AddListener(OnButtonClick);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out RaycastHit hit)) 
                {
                    string hitTag = hit.collider.tag;
                    if (tagToCanvasMap.ContainsKey(hitTag))
                    {
                        if (hitTag == "MBVideo") {
                            videoMB.Play();
                            ShowCanvas(hitTag);
                        }
                        else if (hitTag == "MYVideo") {
                            videoMY.Play();
                            ShowCanvas(hitTag);
                        }
                        else {
                            ShowCanvas(hitTag);
                        }
                    }
                }
            }
        }
    }

    void ShowCanvas(string tag)
    {
        // Deactivate all canvases first
        foreach (var pair in tagToCanvasMap)
        {
            pair.Value.SetActive(false);
        }

        // Activate the canvas with the given tag
        if (tagToCanvasMap.ContainsKey(tag))
        {
            tagToCanvasMap[tag].SetActive(true);
            button.SetActive(true);
            activeCanvas = tagToCanvasMap[tag];
        }
    }

    public void OnButtonClick()
    {
        if (activeCanvas != null)
        {
            activeCanvas.SetActive(false);
            button.SetActive(false);
            videoMB.Stop();
            videoMY.Stop();
        }
    }
}
