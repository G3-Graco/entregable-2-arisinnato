using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class UbicacionService : IUbicacionService
    {
        private static List<Ubicacion> Ubicaciones = new List<Ubicacion>(); // Almacenamiento en memoria

        // Obtener todas las ubicaciones
        public List<Ubicacion> GetAll()
        {
            return Ubicaciones;
        }

        // Obtener una ubicación por su ID
        public Ubicacion GetById(int id)
        {
            return Ubicaciones.FirstOrDefault(u => u.id == id);
        }

        // Añadir una nueva ubicación
        public void Add(Ubicacion ubicacion)
        {
            if (GetById(ubicacion.id) != null)
            {
                throw new Exception("La ubicación ya existe.");
            }
            Ubicaciones.Add(ubicacion);
        }

        // Actualizar una ubicación existente
        public void Update(int id, Ubicacion ubicacion)
        {
            var ubicacionExistente = GetById(id);
            if (ubicacionExistente == null)
            {
                throw new Exception("La ubicación no existe.");
            }
            ubicacionExistente.nombre = ubicacion.nombre;
            ubicacionExistente.descripcion = ubicacion.descripcion;
            ubicacionExistente.clima = ubicacion.clima;
        }

        // Eliminar una ubicación
        public void Delete(int id)
        {
            var ubicacion = GetById(id);
            if (ubicacion == null)
            {
                throw new Exception("La ubicación no existe.");
            }
            Ubicaciones.Remove(ubicacion);
        }
    }
}