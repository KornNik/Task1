using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using maxstAR;

public class ImageShown : MonoBehaviour
{
    private Dictionary<string, ImageTrackableBehaviour> imageTrackablesMap =
    new Dictionary<string, ImageTrackableBehaviour>();

    private void Start()
    {
        TrackerManager.GetInstance().StartTracker(TrackerManager.TRACKER_TYPE_IMAGE);
    }
    void Update()
    {
    TrackingState state = TrackerManager.GetInstance().UpdateTrackingState();
        TrackingResult trackingResult = state.GetTrackingResult();

        for (int i = 0; i < trackingResult.GetCount(); i++)
        {
            Trackable trackable = trackingResult.GetTrackable(i);
            imageTrackablesMap[trackable.GetName()].OnTrackSuccess(trackable.GetId(), trackable.GetName(), trackable.GetPose());
        }
    }

    void OnApplicationPause(bool pause)
    {
        TrackerManager.GetInstance().StopTracker();
    }

    void OnDestroy()
    {
        TrackerManager.GetInstance().StopTracker();
        TrackerManager.GetInstance().DestroyTracker();
    }

}
