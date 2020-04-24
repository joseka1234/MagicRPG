using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto
{
    string Nombre;
    string Descripcion;
    Estadisticas Incrementos;

    public Objeto(string _Nombre, string _Descripcion, Estadisticas _Incrementos)
    {
        this.Nombre = _Nombre;
        this.Descripcion = _Descripcion;
        this.Incrementos = _Incrementos;
    }
}
