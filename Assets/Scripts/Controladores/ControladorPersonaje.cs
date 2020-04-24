using UnityEngine;
using System.Linq;

public class ControladorPersonaje : MonoBehaviour
{
    public static Sprite[] GetSprite(Personaje personaje)
    {
        return Resources.LoadAll(personaje.Sprite, typeof(Sprite)).Cast<Sprite>().ToArray();
    }

    public static void CambiarEquipo(Equipo _Equipo, Personaje personaje)
    {
        int index = personaje.Equipo.FindIndex((eq) => eq.TipoEquipo == _Equipo.TipoEquipo);
        if (index != -1)
        {
            personaje.Equipo[index] = _Equipo;
        }
        else
        {
            personaje.Equipo.Add(_Equipo);
        }
    }

    public static IA GetIA(Enemigo enemigo)
    {
        switch (enemigo.IA)
        {
            default:
                return new IA();
        }
    }
}
