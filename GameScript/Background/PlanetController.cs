using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class PlanetController : ObjectController
{
    private List<bool> planetActive = new List<bool>();
    public enum planet {
        Unknow = 0,
        Moon = 1, 
        Venus = 2,
        Mars = 3,
        Mercure = 4,
        Jupiter = 5,
        Saturne = 6,
        Uranus = 7,
        Neptune = 8
    }
    [SerializeField] private planet actualPlanet;
    [SerializeField] private planet[] planetToShow = new planet[8];
    [SerializeField] private float[] distanceToTravel = new float[8] {384400,41000000,78000000,92000000,628000000,1300000000,2300000000,4300000000};
    [SerializeField] private Sprite[] planetSprite = new Sprite[8];
    [SerializeField] private SpriteRenderer planetRenderer;
    private int index = 0;
    private int[] indexCalculator;
    public float distanceToBrake;
    private void Awake()
    {
        switch (actualPlanet)
        {
            case planet.Unknow:
                break;

            case planet.Moon:
            case planet.Venus:
            case planet.Mercure:
                indexCalculator = new int[3] { 0, 1, 3 };
                break;

            case planet.Mars:
            case planet.Jupiter:
            case planet.Saturne:
            case planet.Uranus:
            case planet.Neptune:
                indexCalculator = new int[5] { 2, 4, 5, 6, 7 };
                break;
        }
    }

    protected override void Update()
    {
        PlanetShow(distanceToTravel[indexCalculator[index]], planetSprite[indexCalculator[index]], planetToShow[indexCalculator[index]]);
    
    }

    public void PlanetShow(float distance, Sprite planetSprite, planet planet)
    {
        if (actualPlanet == planet) // Si c'est la planète qu'il nous fallait atteindre alors
        {
            distanceToBrake = (gmIns.speedStruct.speed * 18000f * Time.deltaTime);
            if (gmIns.score >= (distance - distanceToBrake) && actualPlanet == planet) gmIns.planetReached = true;
             //On stop net le véhicule
        }
        else if (gmIns.score >= (distance + 20000f)) //Sinon quand elle est dépassée on la replace en attente de réutilisation
        {
            transform.position = new Vector3(0, 1.75f, -0.3f);
            index++;
        }

        if (gmIns.score >= (distance - 9000f)) // Si la planète approche de la distance désirée
        {
            base.Update();
        }
    }
}
