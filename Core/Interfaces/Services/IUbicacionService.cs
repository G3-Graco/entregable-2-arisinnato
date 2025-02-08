using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IUbicacionService
    {
        // Operaciones CRUD
        List<Ubicacion> GetAll(); // Obtener todas las ubicaciones
        Ubicacion GetById(int id); // Obtener una ubicación por su ID
        void Add(Ubicacion ubicacion); // Añadir una nueva ubicación
        void Update(int id, Ubicacion ubicacion); // Actualizar una ubicación existente
        void Delete(int id); // Eliminar una ubicación
    }
}