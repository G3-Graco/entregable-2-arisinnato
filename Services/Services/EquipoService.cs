using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Services;

namespace Services.Services
{
    public class EquipoService
    {
         private static List<Equipo> Equipos = new List<Equipo>(); // Almacenamiento en memoria

        // Obtener todos los equipos
        public List<Equipo> GetAll()
        {
            return Equipos;
        }

        // Obtener un equipo por su ID
        public Equipo GetById(int id)
        {
            return Equipos.FirstOrDefault(e => e.id == id);
        }

        // Añadir un nuevo equipo
        public void Add(Equipo equipo)
        {
            if (GetById(equipo.id) != null)
            {
                throw new Exception("El equipo ya existe.");
            }
            Equipos.Add(equipo);
        }

        // Actualizar un equipo existente
        public void Update(int id, Equipo equipo)
        {
            var equipoExistente = GetById(id);
            if (equipoExistente == null)
            {
                throw new Exception("El equipo no existe.");
            }
            equipoExistente.casco = equipo.casco;
            equipoExistente.armadura = equipo.armadura;
            equipoExistente.arma1 = equipo.arma1;
            equipoExistente.arma2 = equipo.arma2;
            equipoExistente.guanteletes = equipo.guanteletes;
            equipoExistente.grebas = equipo.grebas;
        }

        // Eliminar un equipo
        public void Delete(int id)
        {
            var equipo = GetById(id);
            if (equipo == null)
            {
                throw new Exception("El equipo no existe.");
            }
            Equipos.Remove(equipo);
        }

        // Equipar un objeto en el slot correspondiente
        public void Equipar(int id, string tipoObjeto)
        {
            var equipo = GetById(id);
            if (equipo == null)
            {
                throw new Exception("El equipo no existe.");
            }

            switch (tipoObjeto.ToLower())
            {
                case "casco":
                    equipo.casco = "Casco equipado";
                    break;
                case "armadura":
                    equipo.armadura = "Armadura equipada";
                    break;
                case "arma1":
                    equipo.arma1 = "Arma 1 equipada";
                    break;
                case "arma2":
                    equipo.arma2 = "Arma 2 equipada";
                    break;
                case "guanteletes":
                    equipo.guanteletes = "Guanteletes equipados";
                    break;
                case "grebas":
                    equipo.grebas = "Grebas equipadas";
                    break;
                default:
                    throw new Exception("Tipo de objeto no válido.");
            }
        }

        // Desequipar un objeto del slot correspondiente
        public void Desequipar(int id, string tipoObjeto)
        {
            var equipo = GetById(id);
            if (equipo == null)
            {
                throw new Exception("El equipo no existe.");
            }

            switch (tipoObjeto.ToLower())
            {
                case "casco":
                    equipo.casco = string.Empty;
                    break;
                case "armadura":
                    equipo.armadura = string.Empty;
                    break;
                case "arma1":
                    equipo.arma1 = string.Empty;
                    break;
                case "arma2":
                    equipo.arma2 = string.Empty;
                    break;
                case "guanteletes":
                    equipo.guanteletes = string.Empty;
                    break;
                case "grebas":
                    equipo.grebas = string.Empty;
                    break;
                default:
                    throw new Exception("Tipo de objeto no válido.");
            }
        }
    }
}