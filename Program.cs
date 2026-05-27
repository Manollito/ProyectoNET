/*
Primer proyecto en .NET
*/

/*
Crear proyecto consola
dotnet new console

Ejecutar
dotnet run

Compilar
dotnet build

Crear proyecto web API
dotnet new webapi

Ver plantillas
dotnet new list
*/


// Variables y tipos de datos

int edad = 20;  //enteros
double altura = 1.75;  //decimales
bool esMayor = edad >= 18;  //booleanos
string nombre = "Juan";  //texto


//Imprimir en pantalla

//Con salto de linea
Console.WriteLine("Hola, " + nombre + "! Tienes " + edad + " años y mides " + altura + " metros.");

//Sin salto de linea
Console.Write("Hola ");
Console.Write("mundo");

//Pedir datos al usuario

Console.Write("¿Cómo te llamas? ");
string nombre = Console.ReadLine();

//Convertir valores

Console.Write("Edad: ");
int edad = int.Parse(Console.ReadLine());
Console.WriteLine("Tu edad es " + edad);

//Condicionales

if (edad >= 18)
{
    Console.WriteLine("Eres mayor de edad.");
}
else
{
    Console.WriteLine("Eres menor de edad.");
}

//Operadores lógicos
// && (AND), || (OR), ! (NOT)

//Ciclo While

int contador = 0;
while (contador < 5)
{
    Console.WriteLine("Contador: " + contador);
    contador++;
}

//Ciclo For
for (int i = 0; i < 5; i++)
{
    Console.WriteLine("Índice: " + i);
}

//Funciones con Parametros
void Saludar(string nombre)
{
    Console.WriteLine("Hola, " + nombre + "!");
}

Saludar("Manuel");

//Funciones que retornan valores

int Sumar(int a, int b)
{
    return a + b;
}

int resultado = Sumar(5, 3);
Console.WriteLine(resultado);

//Arreglos
int[] numeros = { 1, 2, 3, 4 };

Console.WriteLine(numeros[0]);

//Listas
List<string> nombres = new List<string>();

nombres.Add("Ana");
nombres.Add("Luis");

foreach (string nombre in nombres)
{
    Console.WriteLine(nombre);
}

//Strings modernos

string nombre = "Manuel";

Console.WriteLine($"Hola {nombre}");

//Manejo básico de errores
try
{
    int numero = int.Parse(Console.ReadLine());
}
catch
{
    Console.WriteLine("Eso no es un número");
}