
[System.Serializable]
public class Habilidad
{
    public Elemento Elemento;
    public Tipo Tipo;
    public int Poder;

    public Habilidad(Elemento _Elemento, Tipo _Tipo, int _Poder)
    {
        this.Elemento = _Elemento;
        this.Tipo = _Tipo;
        this.Poder = _Poder;
    }
}