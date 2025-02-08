using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IEquipoService
    {
        // Operaciones CRUD
        List<Equipo> GetAll(); // Obtener todos los equipos
        Equipo GetById(int id); // Obtener un equipo por su tipo
        void Add(Equipo equipo); // Añadir un nuevo equipo
        void Update(int id, Equipo equipo); // Actualizar un equipo existente
        void Delete(int id); // Eliminar un equipo

        // Métodos específicos
        void Equipar(int id, string tipo); // Equipar un objeto
        void Desequipar(int id, string tipo); // Desequipar un objeto
    }
}