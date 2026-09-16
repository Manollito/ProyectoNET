using System.Text.Json;


public class PersonaRepository
{
    private const string ARCHIVO = "personas.json";
    public void Guardar(List<Persona> personas)
    {
        string json = JsonSerializer.Serialize(personas);

        File.WriteAllText(ARCHIVO, json);
    }
    public List<Persona> Cargar()
    {
        if (File.Exists(ARCHIVO))
        {
            string json = File.ReadAllText(ARCHIVO);

            List<Persona>? personasCargadas =
                JsonSerializer.Deserialize<List<Persona>>(json);

            if (personasCargadas != null)
            {
                return personasCargadas;
            }
        }

        return new List<Persona>();
    }
}