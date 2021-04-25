using UnityEngine;
using UnityEngine.UI;
using System;

public class PointController : MonoBehaviour {
    public GameEvent pointsCollectedEvent;
    public Text pointsText;

    private GameEventListener pointsCollectedEventListener;
    private int points;
    private static String baseText = "Points: ";

    void Start() {
        points = 0;
        pointsText.text = baseText + "0";
        pointsCollectedEventListener = (GameEventListener) ScriptableObject.CreateInstance("GameEventListener");
        pointsCollectedEventListener.SetupListener(pointsCollectedEvent, CollectPoints);
    }

    private void CollectPoints() {
        points += 1;
        pointsText.text = baseText + points;
    }
}
