using System.Collections.Generic;

[System.Serializable]
public enum Elemento
{
    Fuego, Agua, Aire, Planta, Rayo,
    Oscuridad, Luz, Orden, Caos,
    Locura, Serenidad, Arcano, Divino
}

[System.Serializable]
public enum TipoAtaque
{
    Corte, Punzante, Contundente,
    MProyectil, MChorro, MCuerpoCuerpo
}

[System.Serializable]
public class Personaje
{
    public string Nombre;
    public string Sprite;
    public int LvL;
    public int Exp;

    public Estadisticas Stats;
    public List<Equipo> Equipo;

    public Elemento[] Debilidades;
    public Elemento[] Fortalezas;
    public Habilidad[] Habilidades;

    public Personaje(string _Nombre, string _Sprite, int _LvL, int _Exp,
                    Estadisticas _Stats, List<Equipo> _Equipo, Elemento[] _Debilidades,
                    Elemento[] _Fortalezas, Habilidad[] _Habilidades)
    {
        this.Nombre = _Nombre;
        this.Sprite = _Sprite;
        this.LvL = _LvL;
        this.Exp = _Exp;
        this.Stats = _Stats;
        this.Equipo = _Equipo;

        this.Debilidades = _Debilidades;
        this.Fortalezas = _Fortalezas;
        this.Habilidades = _Habilidades;
    }
}
