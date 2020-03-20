using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerActivator : MonoBehaviour
{
    [SerializeField] private OVRPlayerController walkable;

    [SerializeField] private WheelchairController drivable;

    [SerializeField] private GameObject wheelchairModel;
    [SerializeField] private Collider wheelchairCollider;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float massWheelChain;
    [SerializeField] private float massPlayer;

    [SerializeField] private CharacterController dataPlayer;
    [SerializeField] private float heightPlayerWheelChair;
    [SerializeField] private float heightPlayerWalk;
    
    [SerializeField] private Transform placeToSpawnDrive;
    [SerializeField] private Transform placeToSpawnWalk;
    [SerializeField] private float timeTransition;
    [SerializeField] private PostProcessVolume postProcess;
    private Vignette vignette;
    private float startingIntensity;

    // Start is called before the first frame update
    void Start()
    {
        if(postProcess == null)
            Debug.LogError("postProcess est null ! Initailise le dans l'éditeur stp");
        vignette = postProcess.profile.GetSetting<Vignette>();
        if(vignette == null)
            Debug.LogError("Ayaaaah le post process contient pas de vignette c chaud frer");
        startingIntensity = vignette.intensity;
        if(walkable == null)
            Debug.LogError("Walkable est null ! Initailise le dans l'éditeur stp");
        if(drivable == null)
            Debug.LogError("drivable est null ! Initailise le dans l'éditeur stp");
        if(wheelchairModel == null)
            Debug.LogError("wheelchairModel est null ! Initailise le dans l'éditeur stp");
        if(dataPlayer == null)
            Debug.LogError("dataPlayer est null ! Initailise le dans l'éditeur stp");
        if(placeToSpawnDrive == null)
            Debug.LogError("placeToSpawnDrive est null ! Initailise le dans l'éditeur stp");
        if(placeToSpawnWalk == null)
            Debug.LogError("placeToSpawnWalk est null ! Initailise le dans l'éditeur stp");
        if(playerRigidbody == null)
            Debug.LogError("playerRigidbody est null ! Initailise le dans l'éditeur stp");
        if(wheelchairCollider == null)
            Debug.LogError("wheelchairCollider est null ! Initailise le dans l'éditeur stp");
        if(heightPlayerWalk < float.Epsilon)
            Debug.LogError("heightPlayerWalk est à 0 ! Initailise le dans l'éditeur stp");
        if(heightPlayerWheelChair < float.Epsilon)
            Debug.LogError("heightPlayerWheelChair est à 0 ! Initailise le dans l'éditeur stp");
        if(timeTransition < float.Epsilon)
            Debug.LogError("timeTransition est à 0 ! Initailise le dans l'éditeur stp");
        if(massPlayer < float.Epsilon)
            Debug.LogError("massPlayer est à 0 ! Initailise le dans l'éditeur stp");
        if(massWheelChain < float.Epsilon)
            Debug.LogError("massWheelChain est à 0 ! Initailise le dans l'éditeur stp");
    }

    public void switchPlayer(int nbPlayer)
    {
        StartCoroutine(StartVignette(nbPlayer));
    }

    IEnumerator StartVignette(int nbPlayer)
    {
        float startTime = Time.time;
        float endTime = startTime + timeTransition;
        float currentTime;
        do
        {
            currentTime = Time.time;
            vignette.intensity = new FloatParameter() //Oui je sais on fais un new à chaque frame mais je sais pas comment faire autrement 
            {
                value = Mathf.Lerp(startingIntensity, 1f, Mathf.InverseLerp(startTime, endTime, currentTime))
            };
            yield return null;
        } while (currentTime  < endTime || vignette.intensity < 1f);

        if (nbPlayer == 0)
            toWalk();
        else
            toDrive();
    }
    
    private void toWalk()
    {
        walkable.enabled = true;
        drivable.enabled = false;
        wheelchairModel.SetActive(false);
        transform.position = placeToSpawnWalk.position;
        transform.rotation = placeToSpawnWalk.rotation;
        dataPlayer.height = heightPlayerWalk;
        wheelchairCollider.enabled = false;
        playerRigidbody.mass = massPlayer;
        playerRigidbody.useGravity = false;
        StartCoroutine(UndoVignette());
    }
    
    private void toDrive()
    {
        walkable.enabled = false;
        drivable.enabled = true;
        wheelchairModel.SetActive(true);
        transform.position = placeToSpawnDrive.position;
        transform.rotation = placeToSpawnDrive.rotation;
        dataPlayer.height = heightPlayerWheelChair;
        wheelchairCollider.enabled = true;
        playerRigidbody.mass = massWheelChain;
        playerRigidbody.useGravity = false;
        StartCoroutine(UndoVignette());
    }

    IEnumerator UndoVignette()
    {
        float startTime = Time.time;
        float endTime = startTime + timeTransition;
        float currentTime;
        do
        {
            currentTime = Time.time;
            vignette.intensity = new FloatParameter() //Oui je sais on fais un new à chaque frame mais je sais pas comment faire autrement 
            {
                value = Mathf.Lerp(startingIntensity, 1f, Mathf.InverseLerp(startTime, endTime, endTime - currentTime))
            };
            yield return null;
        } while (currentTime  < endTime || vignette.intensity > startingIntensity);
    }
}
