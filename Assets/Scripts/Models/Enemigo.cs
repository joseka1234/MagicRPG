using System.Collections.Generic;

[System.Serializable]
public class Enemigo : Personaje
{
    public Dictionary<Objeto, float> Drops; // Drops -> Item,Probabilidad
    public int ExperienciaDropeada;
    public TiposIA IA;

    public Enemigo(string _Nombre, string _Sprite, int _Nivel, int _Experiencia,
                Estadisticas _Stats, List<Equipo> _Equipo, Elemento[] _Debilidades,
                Elemento[] _Fortalezas, Habilidad[] _Habilidades,
                Dictionary<Objeto, float> _Drops, int _ExperienciaDropeada, TiposIA _IA)
                // Super constructor
                : base(_Nombre, _Sprite, _Nivel, _Experiencia, _Stats,
                       _Equipo, _Debilidades, _Fortalezas, _Habilidades)
    {
        this.Drops = _Drops;
        this.ExperienciaDropeada = _ExperienciaDropeada;
        this.IA = _IA;
    }

}
