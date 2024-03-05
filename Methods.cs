using System;
using System.Collections.Generic;

class Program
{
    static List<string> usuariosRegistrados = new List<string>();
    static string usuarioActual;
    static List<string> estudiantesInscritos = new List<string>();
    static string profesorAsignado;

    static void Main(string[] args)
    {
        // Registrar usuarios
        RegistrarUsuario("Estudiante1", "contraseña1");
        RegistrarUsuario("Estudiante2", "contraseña2");
        RegistrarUsuario("Profesor1", "contraseña3");
        RegistrarUsuario("Administrativo1", "contraseña4");

        // Iniciar sesión
        IniciarSesion();

        // Mostrar menú correspondiente al tipo de usuario
        if (EsEstudiante(usuarioActual))
        {
            MostrarMenuEstudiante();
        }
        else if (EsProfesor(usuarioActual))
        {
            MostrarMenuProfesor();
        }
        else if (EsAdministrativo(usuarioActual))
        {
            MostrarMenuAdministrativo();
        }
    }

    static void RegistrarUsuario(string nombre, string contraseña)
    {
        usuariosRegistrados.Add($"{nombre}:{contraseña}");
    }

    static void IniciarSesion()
    {
        Console.WriteLine("Nombre de usuario:");
        string nombre = Console.ReadLine();
        Console.WriteLine("Contraseña:");
        string contraseña = Console.ReadLine();

        if (usuariosRegistrados.Contains($"{nombre}:{contraseña}"))
        {
            Console.WriteLine("Inicio de sesión exitoso.");
            usuarioActual = nombre;
        }
        else
        {
            Console.WriteLine("Nombre de usuario o contraseña incorrectos.");
            // Salir o volver a intentar inicio de sesión
        }
    }

    static bool EsEstudiante(string usuario)
    {
        return usuario.StartsWith("Estudiante");
    }

    static bool EsProfesor(string usuario)
    {
        return usuario.StartsWith("Profesor");
    }

    static bool EsAdministrativo(string usuario)
    {
        return usuario.StartsWith("Administrativo");
    }

    static void MostrarMenuEstudiante()
    {
        while (true)
        {
            Console.WriteLine("Menú de Estudiante:");
            Console.WriteLine("1. Inscribirse a un curso");
            Console.WriteLine("2. Consultar horario");
            Console.WriteLine("3. Salir");
            Console.WriteLine("Seleccione una opción:");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    InscribirseACurso();
                    break;
                case "2":
                    ConsultarHorario();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Por favor seleccione una opción válida.");
                    break;
            }
        }
    }

    static void InscribirseACurso()
    {
        Console.WriteLine("Inscripción a curso realizada.");
    }

    static void ConsultarHorario()
    {
        Console.WriteLine("Horario del estudiante:");
        Console.WriteLine("Lunes: Matemáticas 6-8am, Español 8-10am, Ciencias 10-12am");
        Console.WriteLine("Martes: No hay clases");
        Console.WriteLine("Miércoles: Programación 8-10am, Inglés 10-12am");
        Console.WriteLine("Jueves: No hay clases");
        Console.WriteLine("Viernes: Ética 10-12am");
    }

    static void MostrarMenuProfesor()
    {
        while (true)
        {
            Console.WriteLine("Menú de Profesor:");
            Console.WriteLine("1. Modificar notas de un estudiante");
            Console.WriteLine("2. Volver al inicio de sesión");
            Console.WriteLine("Seleccione una opción:");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ModificarNotasEstudiante();
                    break;
                case "2":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Por favor seleccione una opción válida.");
                    break;
            }
        }
    }

    static void ModificarNotasEstudiante()
    {
        List<string> estudiantes = new List<string>
        {
            "Estudiante1:3.5",
            "Estudiante2:4.0",
            "Estudiante3:2.8"
        };

        Console.WriteLine("Lista de estudiantes:");
        for (int i = 0; i < estudiantes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {estudiantes[i]}");
        }

        Console.WriteLine("Seleccione el número de estudiante al que desea modificar las notas:");
        int indiceEstudiante = int.Parse(Console.ReadLine()) - 1;

        if (indiceEstudiante >= 0 && indiceEstudiante < estudiantes.Count)
        {
            Console.WriteLine($"Ingrese la nueva nota para el estudiante {estudiantes[indiceEstudiante].Split(':')[0]}:");
            float nuevaNota = float.Parse(Console.ReadLine());
            estudiantes[indiceEstudiante] = $"{estudiantes[indiceEstudiante].Split(':')[0]}:{nuevaNota}";

            Console.WriteLine($"La nota del estudiante ha sido modificada correctamente.");
        }
        else
        {
            Console.WriteLine("Número de estudiante inválido.");
        }
    }

    static void MostrarMenuAdministrativo()
    {
        while (true)
        {
            Console.WriteLine("Menú de Administrativo:");
            Console.WriteLine("1. Inscribir estudiantes a un grupo");
            Console.WriteLine("2. Desinscribir estudiantes de un grupo");
            Console.WriteLine("3. Asignar profesor a un grupo");
            Console.WriteLine("4. Obtener profesor de un grupo");
            Console.WriteLine("5. Ver información del grupo");
            Console.WriteLine("6. Volver al inicio de sesión");
            Console.WriteLine("Seleccione una opción:");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    InscribirEstudiantes();
                    break;
                case "2":
                    DesinscribirEstudiantes();
                    break;
                case "3":
                    AsignarProfesor();
                    break;
                case "4":
                    ObtenerProfesor();
                    break;
                case "5":
                    VerInformacionGrupo();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Por favor seleccione una opción válida.");
                    break;
            }
        }
    }

    static void InscribirEstudiantes()
    {
        Console.WriteLine("Ingrese el nombre del grupo:");
        string nombreGrupo = Console.ReadLine();
        estudiantesInscritos.Clear();

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"Ingrese el nombre del estudiante {i} (o 'fin' para terminar):");
            string nombreEstudiante = Console.ReadLine();
            if (nombreEstudiante.ToLower() == "fin")
            {
                break;
            }
            estudiantesInscritos.Add(nombreEstudiante);
        }

        Console.WriteLine($"Estudiantes inscritos en el grupo {nombreGrupo}:");
        foreach (string estudiante in estudiantesInscritos)
        {
            Console.WriteLine(estudiante);
        }
    }

    static void DesinscribirEstudiantes()
    {
        estudiantesInscritos.Clear();
        Console.WriteLine("Estudiantes desinscritos del grupo.");
    }

    static void AsignarProfesor()
    {
        Console.WriteLine("Ingrese el nombre del profesor:");
        profesorAsignado = Console.ReadLine();
        Console.WriteLine($"Profesor asignado: {profesorAsignado}");
    }

    static void ObtenerProfesor()
    {
        if (profesorAsignado != null)
        {
            Console.WriteLine($"El profesor asignado al grupo es: {profesorAsignado}");
        }
        else
        {
            Console.WriteLine("No se ha asignado ningún profesor a este grupo.");
        }
    }

    static void VerInformacionGrupo()
    {
        Console.WriteLine("Información del grupo:");
        Console.WriteLine($"Estudiantes inscritos:");
        foreach (string estudiante in estudiantesInscritos)
        {
            Console.WriteLine(estudiante);
        }
        Console.WriteLine($"Profesor asignado: {profesorAsignado}");
    }
}
