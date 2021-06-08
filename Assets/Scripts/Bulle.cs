

using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Bulle", order = 1)]
public class Bulle : ScriptableObject
{
    [SerializeField] GameObject prefab;

    public GameObject Prefab
    {
        get
        {
            return prefab;
        }
    }

    [SerializeField] string eleve;

    public string Eleve
    {
        get
        {
            return eleve;
        }
    }

    [SerializeField] string title;

    public string Title
    {
        get
        {
            return title;
        }
    }

    [SerializeField] Sprite photo;



    public Sprite Photo
    {
        get
        {
            return photo;
        }
    }
}
