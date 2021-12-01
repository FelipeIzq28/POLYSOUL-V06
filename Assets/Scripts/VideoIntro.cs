using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class VideoIntro : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer video;

    [SerializeField] GameManager gm;
    private void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
     
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CheckOver(VideoPlayer vp)
    {
        SceneManager.LoadScene(2);
    }
}
