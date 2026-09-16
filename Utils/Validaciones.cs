using System.Text.RegularExpressions;

public static class Validaciones
{
    public static bool ValidarNombre(string? nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            return false;

        if (Regex.IsMatch(nombre, @"\d"))
            return false;

        return true;
    }

    public static bool ValidarEdad(int edad)
    {
        return edad >= 0 && edad <= 120;
    }

    public static bool ValidarCorreo(string? correo) 
    {   if (string.IsNullOrWhiteSpace(correo)) 
            return false; 
        
        return Regex.IsMatch( 
            correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$" 
        ); 
    }

    public static bool ValidarTelefono(string? telefono)
    {
        if (string.IsNullOrWhiteSpace(telefono))
        {
            return false;
        }

        return Regex.IsMatch(telefono, @"^\d{8}$");
    }
}