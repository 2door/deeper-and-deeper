using UnityEngine;
using UnityEngine.UI;
using System;

public class PointController : MonoBehaviour {
    public GameEvent pointsCollectedEvent;
    public Text pointsText;

    private GameEventListener pointsCollectedEventListener;
    private int points;
    private static String baseText = "Points: ";
    private AudioSource pickupAudio;

    void Start() {
        points = 0;
        pointsText.text = baseText + "0";
        pickupAudio = transform.GetComponent<AudioSource>();
        pointsCollectedEventListener = (GameEventListener) ScriptableObject.CreateInstance("GameEventListener");
        pointsCollectedEventListener.SetupListener(pointsCollectedEvent, CollectPoints);
    }

    private void CollectPoints() {
        points += 1;
        pickupAudio.Play();
        pointsText.text = baseText + points;
    }
}
