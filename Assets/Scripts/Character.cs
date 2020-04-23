using System.Linq;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public enum Elemento
{
    Fuego, Agua, Aire, Planta, Rayo,
    Oscuridad, Luz, Orden, Caos,
    Locura, Serenidad, Arcano, Divino
}

[System.Serializable]
public enum Tipo
{
    Corte, Punzante, Contundente,
    MProyectil, MChorro, MCuerpoCuerpo
}

[System.Serializable]
public class Character
{
    public string Nombre;
    public string Sprite;
    public Stats Stats;
    public List<Equipo> Equipo;

    public Elemento[] Debilidades;
    public Elemento[] Fortalezas;
    public Habilidad[] Habilidades;

    public Character(string _Nombre, string _Sprite, Stats _Stats,
                    List<Equipo> _Equipo, Elemento[] _Debilidades,
                    Elemento[] _Fortalezas, Habilidad[] _Habilidades)
    {
        this.Nombre = _Nombre;
        this.Sprite = _Sprite;
        this.Stats = _Stats;
        this.Equipo = _Equipo;

        this.Debilidades = _Debilidades;
        this.Fortalezas = _Fortalezas;
        this.Habilidades = _Habilidades;
    }

    public Sprite[] GetSprite()
    {
        return Resources.LoadAll(this.Sprite, typeof(Sprite)).Cast<Sprite>().ToArray();
    }

    public void CambiarEquipo(Equipo _Equipo)
    {
        int index = this.Equipo.FindIndex((eq) => eq.TipoEquipo == _Equipo.TipoEquipo);
        if (index != -1)
        {
            this.Equipo[index] = _Equipo;
        }
        else
        {
            this.Equipo.Add(_Equipo);
        }
    }
}
