﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SolicitudInscripcion
{
    internal class Alumno
    {
        public int NumeroRegistro { get; }
        public string Nombre { get; }
        public string Apellido { get; }
        public int DNI { get; }
        public string Email { get; }
        public int CodigoCarrera { get; }
        public bool Ultimas4 { get; }  
        public string MateriasAprobadas { get; }

        const string maestroAlumnos = "maestroAlumnos.txt";

        public static List<Alumno> alumnos = new List<Alumno>();

        public Alumno()
        {

        }

        public Alumno(string linea)
        {
            var datos = linea.Split('|');
            NumeroRegistro = int.Parse(datos[0]);
            Nombre = datos[1];
            Apellido = datos[2];
            DNI = int.Parse(datos[3]);
            Email = datos[4];
            CodigoCarrera = int.Parse(datos[5]);
            Ultimas4 = bool.Parse(datos[6]);
            var tabs = linea.Count(c => c == '|');

            for (int i = 6; i == tabs; i++)
            {
                MateriasAprobadas = datos[i] + "-" ;
            }            

        }

        public void LeerMaestroAlumnos()
        {
            if (File.Exists(maestroAlumnos))
            {
                using (var reader = new StreamReader(maestroAlumnos))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();

                        var unAlumno = new Alumno(linea);
                        alumnos.Add(unAlumno);
                    }
                }
            }
        }
        public void Inicializar()
        {
            //LeerMaestroAlumnos();
            foreach(Alumno a in alumnos)
            {
                Console.WriteLine($"{a.NumeroRegistro}-{a.Apellido}-{a.Nombre}-{a.MateriasAprobadas}-{a.DNI}-{a.Email}-{a.Ultimas4}-{a.CodigoCarrera}");
            }
        }
    }
}