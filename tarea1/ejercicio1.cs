using System;


var matriz = MatrizFactory.CrearMatrizIdentidad(4);
Console.WriteLine(matriz.EsIdentidad());


public class MatrizFactory
{
    private static readonly Random _random = new();

    public static Matriz CrearMatriz(int tamano)
    {
        var valores = new int[tamano, tamano];
        for (var i = 0; i < tamano; i++)
            for (var j = 0; j < tamano; j++)
                valores[i, j] = _random.Next();

        return new Matriz(tamano, valores);
    }

    public static Matriz CrearMatrizIdentidad(int tamano)
    {
        var valores = new int[tamano, tamano];
        for (var i = 0; i < tamano; i++)
            for (var j = 0; j < tamano; j++)
                valores[i, j] = i == j ? 1 : 0;

        return new Matriz(tamano, valores);
    }
}

public class Matriz
{
    private readonly int _tamano;
    private readonly int[,] _valores;

    public Matriz(int tamano, int[,] values)
    {
        this._tamano = tamano;
        _valores = values;
    }

    public bool EsIdentidad()
    {
        for (var i = 0; i < _tamano; i++)
            for (var j = 0; j < _tamano; j++)
                if ((i == j && _valores[i, j] != 1) || (i != j && _valores[i, j] != 0))
                    return false;

        return true;
    }
}