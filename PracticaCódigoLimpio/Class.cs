using System.Collections.Generic;
using System;

public class Usuario
{
    public string Nombre { get; set; }
    public string Contraseña { get; set; }

    public Usuario(string nombre, string contraseña)
    {
        Nombre = nombre;
        Contraseña = contraseña;
    }

    public virtual bool Autenticar(string contraseñaIngresada)
    {
        return Contraseña == contraseñaIngresada;
    }
}

public class Estudiante : Usuario
{
    public Estudiante(string nombre, string contraseña) : base(nombre, contraseña)
    {
    }
}

public class Profesor : Usuario
{
    public Profesor(string nombre, string contraseña) : base(nombre, contraseña)
    {
    }

    public void IngresarNotas(Estudiante estudiante, Curso curso, float nota)
    {
        // Lógica para ingresar notas
    }
}

public class Administrativo : Usuario
{
    public Administrativo(string nombre, string contraseña) : base(nombre, contraseña)
    {
    }
}

public class Curso
{
    public string Nombre { get; set; }
    public List<Estudiante> EstudiantesInscritos { get; set; }

    public Curso(string nombre)
    {
        Nombre = nombre;
        EstudiantesInscritos = new List<Estudiante>();
    }

    public void InscribirEstudiante(Estudiante estudiante)
    {
        EstudiantesInscritos.Add(estudiante);
    }

    public void DesinscribirEstudiante(Estudiante estudiante)
    {
        EstudiantesInscritos.Remove(estudiante);
    }
}

public class GestorCursos
{
    private List<Curso> cursos;

    public GestorCursos()
    {
        cursos = new List<Curso>();
    }

    public void AgregarCurso(Curso curso)
    {
        cursos.Add(curso);
    }

    public void EliminarCurso(Curso curso)
    {
        cursos.Remove(curso);
    }

    public void ListarCursos()
    {
        foreach (var curso in cursos)
        {
            Console.WriteLine(curso.Nombre);
        }
    }
}

public class GestorHorarios
{
    // Implementar lógica para la gestión de horarios
}

public class InterfazUsuario
{
    // Implementar la interfaz de usuario
}

public class GestorNotas
{
    // Implementar la gestión de notas
}
