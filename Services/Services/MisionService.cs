using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class MisionService : IMisionService
    {
        private static List<Mision> Misiones = new List<Mision>(); // Almacenamiento en memoria

        // Obtener todas las misiones
        public List<Mision> GetAll()
        {
            return Misiones;
        }

        // Obtener una misión por su ID
        public Mision GetById(int id)
        {
            return Misiones.FirstOrDefault(m => m.id == id);
        }

        // Añadir una nueva misión
        public void Add(Mision mision)
        {
            if (GetById(mision.id) != null)
            {
                throw new Exception("La misión ya existe.");
            }
            Misiones.Add(mision);
        }

        // Actualizar una misión existente
        public void Update(int id, Mision mision)
        {
            var misionExistente = GetById(id);
            if (misionExistente == null)
            {
                throw new Exception("La misión no existe.");
            }
            misionExistente.nombre = mision.nombre;
            misionExistente.objetivos = mision.objetivos;
            misionExistente.recompensas = mision.recompensas;
            misionExistente.estado = mision.estado;
        }

        // Eliminar una misión
        public void Delete(int id)
        {
            var mision = GetById(id);
            if (mision == null)
            {
                throw new Exception("La misión no existe.");
            }
            Misiones.Remove(mision);
        }

        // Aceptar una misión (cambiar estado a 'A' de "Aceptada")
        public void AceptarMision(int id)
        {
            var mision = GetById(id);
            if (mision == null)
            {
                throw new Exception("La misión no existe.");
            }
            mision.estado = 'A'; // 'A' para "Aceptada"
        }

        // Completar una misión (cambiar estado a 'C' de "Completada")
        public void CompletarMision(int id)
        {
            var mision = GetById(id);
            if (mision == null)
            {
                throw new Exception("La misión no existe.");
            }
            mision.estado = 'C'; // 'C' para "Completada"
        }

        // Agregar un objetivo a la misión
        public void AgregarObjetivo(int id, string objetivo)
        {
            var mision = GetById(id);
            if (mision == null)
            {
                throw new Exception("La misión no existe.");
            }
            mision.objetivos.Add(objetivo);
        }

        // Eliminar un objetivo de la misión
        public void EliminarObjetivo(int id, string objetivo)
        {
            var mision = GetById(id);
            if (mision == null)
            {
                throw new Exception("La misión no existe.");
            }
            mision.objetivos.Remove(objetivo);
        }
    }
}