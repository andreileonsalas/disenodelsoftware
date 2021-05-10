using System;


var random = new Random();
var opciones = new[]
{
    "casa",
    "perro",
    "pepe"
};

var programa = new Programa(opciones[random.Next(0, opciones.Length)]);
var participante = new Participante(programa, "Juan");

foreach (var opcion in opciones)
    participante.Responder(opcion);


public class Programa
{
    private string _respuesta;
    private int _intentos = 0;

    public Programa(string respuesta)
    {
        _respuesta = respuesta;
    }

    public void Suscribirse(Participante participante)
    {
        participante.PosibleRespuesta += Participante_PosibleRespuesta;
    }

    private void Participante_PosibleRespuesta(object sender, string e)
    {
        _intentos++;
        var participante = (Participante)sender;

        if (_respuesta == e)
            Console.WriteLine($"El ganador es {participante.Nombre}, con la palabra '{e}' en el intento {_intentos}");
        else
            Console.WriteLine($"'{e}' no es la palabra correcta");
    }
}

public class Participante
{
    Programa _programa;
    public event EventHandler<string> PosibleRespuesta;

    public string Nombre { get; set; }

    public Participante(Programa programa, string nombre)
    {
        _programa = programa;
        _programa.Suscribirse(this);
        Nombre = nombre;
    }

    public void Responder(string posibleRespuesta) => PosibleRespuesta(this, posibleRespuesta);
}