using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
 
[RequireComponent (typeof (VideoPlayer))]
public class VideoGallery : MonoBehaviour
{
    // let's add another method to our enum
    public enum VideoLocation {AssignedInEditor, LoadFromResources, StreamFromStreamingAssets}
 
    [SerializeField] VideoLocation locationType;
    [SerializeField] VideoClip [] clips;
 
    // video urls (from streaming assets)
    string [] urls;
 
    [SerializeField] Button clipButton;
    VideoPlayer player;
 
    void Awake ()
    {
        player = GetComponent<VideoPlayer>();
 
        // number of video clips, we hold it as a reference, as we now handle clips and urls
        int videoCount = clips.Length;
 
        // if using streaming asset, find all mp4 files in streaming assets directory
        if (locationType == VideoLocation.StreamFromStreamingAssets)
        {
            urls = System.IO.Directory.GetFiles(Application.streamingAssetsPath, "*.mp4");
            videoCount = urls.Length;
        }
        else if (locationType == VideoLocation.LoadFromResources)
        {
            clips = Resources.LoadAll<VideoClip>("");
            videoCount = clips.Length;
        }
 
        if (videoCount > 0)
        {
            for (int i = 0 ; i < videoCount ; i++)
            {
                GameObject g = GameObject.Instantiate (clipButton.gameObject, clipButton.transform.parent);
                Button b = g.GetComponent<Button>();
                int index = i;
 
                if (locationType == VideoLocation.StreamFromStreamingAssets)
                {
                    // adding a listener to the button to call PlayVideo method
                    b.onClick.AddListener (() => {this.PlayVideo(urls[index]);});
 
                    // assign the name of the clip to the text property of the text component found on the button
                    // UNSAFE : Button may not have a Text children object
                    b.GetComponentInChildren<Text>().text = System.IO.Path.GetFileNameWithoutExtension(urls[index]);
                }
                else
                {
                    // adding a listener to the button to call PlayVideo method
                    b.onClick.AddListener (() => {this.PlayVideo(index);});
 
                    // assign the name of the clip to the text property of the text component found on the button
                    // UNSAFE : Button may not have a Text children object
                    b.GetComponentInChildren<Text>().text = clips[index].name;
                }
            }
 
            clipButton.gameObject.SetActive(false);
            clipButton.transform.parent.GetComponentInChildren<Button>(false).Select();
        }
    }
 
    // Start Video Playback from Url.
    public void PlayVideo (string url)
    {
        bool wasPlaying = player.isPlaying;
 
        if (player.isPlaying)
            player.Stop();
 
        player.url = url; // changing url instead
 
        if (wasPlaying)
            player.Play();
    }
 
    public void PlayVideo (int index)
    {
        if (index >= clips.Length || index < 0)
            return; // exit method
 
        bool wasPlaying = player.isPlaying;
 
        if (player.isPlaying)
            player.Stop();
 
        player.clip = clips[index];
 
        if (wasPlaying)
            player.Play();
    }
}