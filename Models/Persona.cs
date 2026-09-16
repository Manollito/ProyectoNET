public class Persona
{
    public int Id { get; set; }
    public string? Nombre { get; set; }

    public int Edad { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }
    public Persona()
    {
    }

    public Persona(int id, string? nombre, int edad, string? correo, string? telefono)
    {
        Id = id;
        Nombre = nombre;
        Edad = edad;
        Correo = correo;
        Telefono = telefono;
    }
}