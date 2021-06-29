

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



    public Sprite SpritePhoto
    {
        get
        {
            return photo;
        }
    }


    [SerializeField] Sprite bulle;



    public Sprite SpriteBulle
    {
        get
        {
            return bulle;
        }
    }




    [SerializeField] Sprite petiteBulle;



    public Sprite SpritePetiteBulle
    {
        get
        {
            return petiteBulle;
        }
    }




    [SerializeField] Sprite titre;



    public Sprite SpriteTitre
    {
        get
        {
            return titre;
        }
    }



    [SerializeField] string description;


    public string Description
    {
        get
        {
            return description;
        }
    }


    [SerializeField] Color backgroundColor;


    public Color BackgroundColor
    {
        get
        {
            return backgroundColor;
        }
    }
}
