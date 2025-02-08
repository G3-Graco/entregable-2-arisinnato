using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IMisionService
    {
        // Operaciones CRUD
        List<Mision> GetAll(); // Obtener todas las misiones
        Mision GetById(int id); // Obtener una misión por su ID
        void Add(Mision mision); // Añadir una nueva misión
        void Update(int id, Mision mision); // Actualizar una misión existente
        void Delete(int id); // Eliminar una misión

        // Métodos específicos
        void AceptarMision(int id); // Aceptar una misión (cambiar estado a 'A' de "Aceptada")
        void CompletarMision(int id); // Completar una misión (cambiar estado a 'C' de "Completada")
        void AgregarObjetivo(int id, string objetivo); // Agregar un objetivo a la misión
        void EliminarObjetivo(int id, string objetivo); // Eliminar un objetivo de la misión
    }
}