using Microsoft.EntityFrameworkCore;
using SEGES.Shared.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEGES.Shared
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public string statusNameList = @"[
                ""Pendiente de aprobación"",
                ""En revisión"",
                ""Aprobado"",
                ""Rechazado"",
                ""Aprobación parcial"",
                ""Aprobación condicional"",
                ""Pendiente de revisión adicional"",
                ""En espera de confirmación"",
                ""En proceso de aprobación"",
                ""Aprobación pendiente de firma"",
                ""Aprobación finalizada"",
                ""Aprobación automática""
            ]";

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await CheckCountriesAsync();
            await CheckStatesAsync();
            await CheckCitiesAsync();
            await CheckDocTraceabilityType();
            await CheckHUApprobalStatus();
            await CheckHUPriority();
            await CheckHUPublicationStatus();
            await CheckHUStatus();
            await CheckProjectStatus();
            await CheckRoles();
        }

        private async Task CheckRoles()
        {
            if (!_context.Roles.Any())
            {
                //_context.ResetTableIDs("Roles");
                _context.Roles.Add(new Role { RoleName = "Administrador del sistema" });
                _context.Roles.Add(new Role { RoleName = "Gerente de proyecto" });
                _context.Roles.Add(new Role { RoleName = "Líder de equipo" });
                _context.Roles.Add(new Role { RoleName = "Desarrollador" });
                _context.Roles.Add(new Role { RoleName = "Tester/QA" });
                _context.Roles.Add(new Role { RoleName = "Analista de negocio" });
                _context.Roles.Add(new Role { RoleName = "Diseñador UX/UI" });
                _context.Roles.Add(new Role { RoleName = "Cliente" });
                _context.Roles.Add(new Role { RoleName = "Interesado" });
                _context.Roles.Add(new Role { RoleName = "Consultor" });
                _context.Roles.Add(new Role { RoleName = "Coordinador de proyecto" });
                _context.Roles.Add(new Role { RoleName = "Scrum Master" });
                _context.Roles.Add(new Role { RoleName = "Product Owner" });
                _context.Roles.Add(new Role { RoleName = "Analista de datos" });
                _context.Roles.Add(new Role { RoleName = "Arquitecto de software" });
                //SaveDBChanges();
                _context.SaveChanges();
            }
        }

        private async Task CheckProjectStatus()
        {
            if (!_context.ProjectStatuses.Any())
            {
                var projectStatuses = JsonConvert.DeserializeObject<List<string>>(statusNameList);
                foreach (var item in projectStatuses)
                {
                    _context.ProjectStatuses.Add(new ProjectStatus { Name = item });
                }
                _context.SaveChanges();
            }
        }

        private async Task CheckHUStatus()
        {
            if (!_context.HUStatuses.Any())
            {
                var huStatuses = JsonConvert.DeserializeObject<List<string>>(statusNameList);
                foreach (var item in huStatuses)
                {
                    _context.HUStatuses.Add(new HUStatus { Name = item });
                }
                _context.SaveChanges();
            }
        }

        private async Task CheckHUPublicationStatus()
        {
            if (!_context.HUPublicationStatuses.Any())
            {
                //_context.ResetTableIDs("HUPublicationStatuses");

                var huPublicationStatuses = JsonConvert.DeserializeObject<List<string>>(statusNameList);
                foreach (var item in huPublicationStatuses)
                {
                    _context.HUPublicationStatuses.Add(new HUPublicationStatus { Name = item });
                }
                _context.SaveChanges();
            }
        }

        private async Task CheckHUPriority()
        {
            if (!_context.HUPriorities.Any())
            {
                //_context.ResetTableIDs("HUPriorities");
                _context.HUPriorities.Add(new HUPriority { Name = "Alta" });
                _context.HUPriorities.Add(new HUPriority { Name = "Media" });
                _context.HUPriorities.Add(new HUPriority { Name = "Baja" });
                _context.HUPriorities.Add(new HUPriority { Name = "Urgente" });
                _context.HUPriorities.Add(new HUPriority { Name = "Crítica" });
                _context.HUPriorities.Add(new HUPriority { Name = "Normal" });
                _context.HUPriorities.Add(new HUPriority { Name = "Importante" });
                _context.HUPriorities.Add(new HUPriority { Name = "Inmediata" });
                _context.HUPriorities.Add(new HUPriority { Name = "Esencial" });
                _context.HUPriorities.Add(new HUPriority { Name = "Pendiente" });
                _context.HUPriorities.Add(new HUPriority { Name = "Emergente" });
                _context.HUPriorities.Add(new HUPriority { Name = "Relevante" });

                _context.SaveChanges();
            }
        }

        private async Task CheckHUApprobalStatus()
        {
            if (!_context.HUApprovalStatuses.Any())
            {
                //_context.ResetTableIDs("HUApprovalStatuses");
                _context.HUApprovalStatuses.Add(new HUApprovalStatus { Name = "Pendiente de aprobación" });
                _context.HUApprovalStatuses.Add(new HUApprovalStatus { Name = "En revisión" });
                _context.HUApprovalStatuses.Add(new HUApprovalStatus { Name = "Aprobado" });
                _context.HUApprovalStatuses.Add(new HUApprovalStatus { Name = "Rechazado" });
                _context.HUApprovalStatuses.Add(new HUApprovalStatus { Name = "Aprobación parcial" });
                _context.HUApprovalStatuses.Add(new HUApprovalStatus { Name = "Aprobación condicional" });
                _context.HUApprovalStatuses.Add(new HUApprovalStatus { Name = "Pendiente de revisión adicional" });
                _context.HUApprovalStatuses.Add(new HUApprovalStatus { Name = "En espera de confirmación" });
                _context.HUApprovalStatuses.Add(new HUApprovalStatus { Name = "En proceso de aprobación" });
                _context.HUApprovalStatuses.Add(new HUApprovalStatus { Name = "Aprobación pendiente de firma" });
                _context.HUApprovalStatuses.Add(new HUApprovalStatus { Name = "Aprobación finalizada" });
                _context.HUApprovalStatuses.Add(new HUApprovalStatus { Name = "Aprobación automática" });
                _context.SaveChanges();
            }
        }

        private async Task CheckDocTraceabilityType()
        {
            if (!_context.DocTraceabilityTypes.Any())
            {
                //_context.ResetTableIDs("DocTraceabilityTypes");
                _context.DocTraceabilityTypes.Add(new DocTraceabilityType { Name = "Objetivo" });
                _context.DocTraceabilityTypes.Add(new DocTraceabilityType { Name = "KPI" });
                _context.DocTraceabilityTypes.Add(new DocTraceabilityType { Name = "Triada Estructural" });
                _context.DocTraceabilityTypes.Add(new DocTraceabilityType { Name = "Problema" });
                _context.DocTraceabilityTypes.Add(new DocTraceabilityType { Name = "Responsabilidad" });
                _context.DocTraceabilityTypes.Add(new DocTraceabilityType { Name = "Restricción" });
                _context.DocTraceabilityTypes.Add(new DocTraceabilityType { Name = "Tipo1" });
                _context.DocTraceabilityTypes.Add(new DocTraceabilityType { Name = "Tipo2" });
                _context.DocTraceabilityTypes.Add(new DocTraceabilityType { Name = "Tipo3" });
                _context.DocTraceabilityTypes.Add(new DocTraceabilityType { Name = "Tipo4" });
                _context.DocTraceabilityTypes.Add(new DocTraceabilityType { Name = "Tipo5" });
                _context.DocTraceabilityTypes.Add(new DocTraceabilityType { Name = "Tipo6" });
                _context.SaveChanges();
            }
        }

        private async Task CheckCitiesAsync()
        {
            if (!_context.Cities.Any())
            {
                //_context.ResetTableIDs("Cities");

                int antioquiaId = _context.States.Single(s => s.Name == "Antioquia").StateId;

                _context.Cities.Add(new City { Name = "Medellin", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Abejorral", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Abriaqui", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Alejandria", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Amaga", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Amalfi", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Andes", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Angelopolis", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Angostura", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Anori", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Santafe De Antioquia", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Anza", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Apartado", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Arboletes", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Argelia", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Armenia", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Barbosa", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Belmira", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Bello", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Betania", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Betulia", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Ciudad Bolivar", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Briceño", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Buritica", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Caceres", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Caicedo", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Caldas", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Campamento", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Cañasgordas", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Caracoli", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Caramanta", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Carepa", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "El Carmen De Viboral", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Carolina", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Caucasia", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Chigorodo", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Cisneros", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Cocorna", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Concepcion", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Concordia", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Copacabana", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Dabeiba", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Don Matias", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Ebejico", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "El Bagre", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Entrerrios", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Envigado", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Fredonia", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Frontino", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Giraldo", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Girardota", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Gomez Plata", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Granada", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Guadalupe", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Guarne", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Guatape", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Heliconia", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Hispania", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Itagüi", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Ituango", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Jardin", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Jerico", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "La Ceja", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "La Mstrella", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "La Pintada", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "La Union", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Liborina", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Maceo", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Marinilla", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Montebello", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Murindo", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Mutata", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Nariño", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Necocli", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Nechi", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Olaya", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Peñol", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Peque", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Pueblorrico", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Puerto Berrio", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Puerto Nare", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Puerto Triunfo", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Remedios", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Retiro", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Rionegro", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Sabanalarga", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Sabaneta", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Salgar", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "San Andres", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "San Carlos", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "San Francisco", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "San Jeronimo", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "San Jose De La Montaña", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "San Juan De Uraba", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "San Luis", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "San Pedro", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "San Pedro De Uraba", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "San Rafael", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "San Roque", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "San Vicente", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Santa Barbara", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Santa Rosa De osos", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Santo Domingo", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "El Santuario", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Segovia", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Sonson", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Sopetran", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Tamesis", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Taraza", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Tarso", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Titiribi", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Toledo", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Turbo", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Uramita", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Urrao", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Valdivia", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Valparaiso", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Vegachi", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Venecia", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Vigia Del Fuerte", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Yali", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Yarumal", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Yolombo", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Yondo", StateId = antioquiaId });
                _context.Cities.Add(new City { Name = "Zaragoza", StateId = antioquiaId });
                SaveDBChanges();

                int amazonasId = _context.States.Single(s => s.Name == "Amazonas").StateId;
                _context.Cities.Add(new City { Name = "LETICIA", StateId = amazonasId });
                _context.Cities.Add(new City { Name = "EL ENCANTO", StateId = amazonasId });
                _context.Cities.Add(new City { Name = "LA CHORRERA", StateId = amazonasId });
                _context.Cities.Add(new City { Name = "LA PEDRERA", StateId = amazonasId });
                _context.Cities.Add(new City { Name = "LA VICTORIA", StateId = amazonasId });
                _context.Cities.Add(new City { Name = "MIRITI - PARANA", StateId = amazonasId });
                _context.Cities.Add(new City { Name = "PUERTO ALEGRIA", StateId = amazonasId });
                _context.Cities.Add(new City { Name = "PUERTO ARICA", StateId = amazonasId });
                _context.Cities.Add(new City { Name = "PUERTO NARIÑO", StateId = amazonasId });
                _context.Cities.Add(new City { Name = "PUERTO SANTANDER", StateId = amazonasId });
                _context.Cities.Add(new City { Name = "TARAPACA", StateId = amazonasId });
                SaveDBChanges();

                int araucaId = _context.States.Single(s => s.Name == "Arauca").StateId;
                _context.Cities.Add(new City { Name = "ARAUCA", StateId = araucaId });
                _context.Cities.Add(new City { Name = "ARAUQUITA", StateId = araucaId });
                _context.Cities.Add(new City { Name = "CRAVO NORTE", StateId = araucaId });
                _context.Cities.Add(new City { Name = "FORTUL", StateId = araucaId });
                _context.Cities.Add(new City { Name = "PUERTO RONDON", StateId = araucaId });
                _context.Cities.Add(new City { Name = "SARAVENA", StateId = araucaId });
                _context.Cities.Add(new City { Name = "TAME", StateId = araucaId });
                SaveDBChanges();

                int atlanticoId = _context.States.Single(s => s.Name == "Atlántico").StateId;
                _context.Cities.Add(new City { Name = "BARRANQUILLA", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "BARANOA", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "CAMPO DE LA CRUZ", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "CANDELARIA", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "GALAPA", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "JUAN DE ACOSTA", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "LURUACO", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "MALAMBO", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "MANATI", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "PALMAR DE VARELA", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "PIOJO", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "POLONUEVO", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "PONEDERA", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "PUERTO COLOMBIA", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "REPELON", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "SABANAGRANDE", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "SABANALARGA", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "SANTA LUCIA", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "SANTO TOMAS", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "SOLEDAD", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "SUAN", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "TUBARA", StateId = atlanticoId });
                _context.Cities.Add(new City { Name = "USIACURI", StateId = atlanticoId });
                SaveDBChanges();

                int bolivarId = _context.States.Single(s => s.Name == "Bolívar").StateId;
                _context.Cities.Add(new City { Name = "BARRANCO DE LOBA", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "CALAMAR", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "CANTAGALLO", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "CICUCO", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "CORDOBA", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "CLEMENCIA", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "EL CARMEN DE BOLIVAR", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "EL GUAMO", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "EL PEÑON", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "HATILLO DE LOBA", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "MAGANGUE", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "MAHATES", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "MARGARITA", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "MARIA LA BAJA", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "MONTECRISTO", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "MOMPOS", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "MORALES", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "PINILLOS", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "REGIDOR", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "RIO VIEJO", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "SAN CRISTOBAL", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "SAN ESTANISLAO", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "SAN FERNANDO", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "SAN JACINTO", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "SAN JACINTO DEL CAUCA", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "SAN JUAN NEPOMUCENO", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "SAN MARTIN DE LOBA", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "SAN PABLO", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "SANTA CATALINA", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "SANTA ROSA", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "SANTA ROSA DEL SUR", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "SIMITI", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "SOPLAVIENTO", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "TALAIGUA NUEVO", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "TIQUISIO", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "TURBACO", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "TURBANA", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "VILLANUEVA", StateId = bolivarId });
                _context.Cities.Add(new City { Name = "ZAMBRANO", StateId = bolivarId });
                SaveDBChanges();

                int boyacaId = _context.States.Single(s => s.Name == "Boyacá").StateId;
                _context.Cities.Add(new City { Name = "TUNJA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "ALMEIDA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "AQUITANIA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "ARCABUCO", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "BELEN", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "BERBEO", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "BETEITIVA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "BOAVITA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "BOYACA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "BRICEÑO", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "BUENAVISTA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "BUSBANZA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "CALDAS", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "CAMPOHERMOSO", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "CERINZA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "CHINAVITA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "CHIQUINQUIRA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "CHISCAS", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "CHITA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "CHITARAQUE", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "CHIVATA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "CIENEGA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "COMBITA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "COPER", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "CORRALES", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "COVARACHIA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "CUBARA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "CUCAITA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "CUITIVA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "CHIQUIZA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "CHIVOR", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "DUITAMA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "EL COCUY", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "EL ESPINO", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "FIRAVITOBA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "FLORESTA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "GACHANTIVA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "GAMEZA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "GARAGOA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "GUACAMAYAS", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "GUATEQUE", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "GUAYATA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "GÜICAN", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "IZA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "JENESANO", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "JERICO", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "LABRANZAGRANDE", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "LA CAPILLA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "LA VICTORIA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "LA UVITA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "VILLA DE LEYVA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "MACANAL", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "MARIPI", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "MIRAFLORES", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "MONGUA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "MONGUI", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "MONIQUIRA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "MOTAVITA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "MUZO", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "NOBSA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "NUEVO COLON", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "OICATA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "OTANCHE", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "PACHAVITA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "PAEZ", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "PAIPA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "PAJARITO", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "PANQUEBA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "PAUNA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "PAYA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "PAZ DE RIO", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "PESCA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "PISBA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "PUERTO BOYACA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "QUIPAMA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "RAMIRIQUI", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "RAQUIRA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "RONDON", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SABOYA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SACHICA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SAMACA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SAN EDUARDO", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SAN JOSE DE PARE", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SAN LUIS DE GACENO", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SAN MATEO", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SAN MIGUEL DE SEMA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SAN PABLO DE BORBUR", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SANTANA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SANTA MARIA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SANTA ROSA DE VITERBO", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SANTA SOFIA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SATIVANORTE", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SATIVASUR", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SIACHOQUE", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SOATA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SOCOTA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SOCHA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SOGAMOSO", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SOMONDOCO", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SORA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SOTAQUIRA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SORACA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SUSACON", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SUTAMARCHAN", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "SUTATENZA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "TASCO", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "TENZA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "TIBANA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "TIBASOSA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "TINJACA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "TIPACOQUE", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "TOCA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "TOGÜI", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "TOPAGA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "TOTA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "TUNUNGUA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "TURMEQUE", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "TUTA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "TUTAZA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "UMBITA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "VENTAQUEMADA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "VIRACACHA", StateId = boyacaId });
                _context.Cities.Add(new City { Name = "ZETAQUIRA", StateId = boyacaId });
                SaveDBChanges();

                int caldasId = _context.States.Single(s => s.Name == "Caldas").StateId;
                _context.Cities.Add(new City { Name = "MANIZALES", StateId = caldasId });
                _context.Cities.Add(new City { Name = "AGUADAS", StateId = caldasId });
                _context.Cities.Add(new City { Name = "ANSERMA", StateId = caldasId });
                _context.Cities.Add(new City { Name = "ARANZAZU", StateId = caldasId });
                _context.Cities.Add(new City { Name = "BELALCAZAR", StateId = caldasId });
                _context.Cities.Add(new City { Name = "CHINCHINA", StateId = caldasId });
                _context.Cities.Add(new City { Name = "FILADELFIA", StateId = caldasId });
                _context.Cities.Add(new City { Name = "LA DORADA", StateId = caldasId });
                _context.Cities.Add(new City { Name = "LA MERCED", StateId = caldasId });
                _context.Cities.Add(new City { Name = "MANZANARES", StateId = caldasId });
                _context.Cities.Add(new City { Name = "MARMATO", StateId = caldasId });
                _context.Cities.Add(new City { Name = "MARQUETALIA", StateId = caldasId });
                _context.Cities.Add(new City { Name = "MARULANDA", StateId = caldasId });
                _context.Cities.Add(new City { Name = "NEIRA", StateId = caldasId });
                _context.Cities.Add(new City { Name = "NORCASIA", StateId = caldasId });
                _context.Cities.Add(new City { Name = "PACORA", StateId = caldasId });
                _context.Cities.Add(new City { Name = "PALESTINA", StateId = caldasId });
                _context.Cities.Add(new City { Name = "PENSILVANIA", StateId = caldasId });
                _context.Cities.Add(new City { Name = "RIOSUCIO", StateId = caldasId });
                _context.Cities.Add(new City { Name = "RISARALDA", StateId = caldasId });
                _context.Cities.Add(new City { Name = "SALAMINA", StateId = caldasId });
                _context.Cities.Add(new City { Name = "SAMANA", StateId = caldasId });
                _context.Cities.Add(new City { Name = "SAN JOSE", StateId = caldasId });
                _context.Cities.Add(new City { Name = "SUPIA", StateId = caldasId });
                _context.Cities.Add(new City { Name = "VICTORIA", StateId = caldasId });
                _context.Cities.Add(new City { Name = "VILLAMARIA", StateId = caldasId });
                _context.Cities.Add(new City { Name = "VITERBO", StateId = caldasId });
                SaveDBChanges();

                int caquetaId = _context.States.Single(s => s.Name == "Caquetá").StateId;
                _context.Cities.Add(new City { Name = "FLORENCIA", StateId = caquetaId });
                _context.Cities.Add(new City { Name = "ALBANIA", StateId = caquetaId });
                _context.Cities.Add(new City { Name = "BELEN DE LOS ANDAQUIES", StateId = caquetaId });
                _context.Cities.Add(new City { Name = "CARTAGENA DEL CHAIRA", StateId = caquetaId });
                _context.Cities.Add(new City { Name = "CURILLO", StateId = caquetaId });
                _context.Cities.Add(new City { Name = "EL DONCELLO", StateId = caquetaId });
                _context.Cities.Add(new City { Name = "EL PAUJIL", StateId = caquetaId });
                _context.Cities.Add(new City { Name = "LA MONTAÑITA", StateId = caquetaId });
                _context.Cities.Add(new City { Name = "MILAN", StateId = caquetaId });
                _context.Cities.Add(new City { Name = "MORELIA", StateId = caquetaId });
                _context.Cities.Add(new City { Name = "PUERTO RICO", StateId = caquetaId });
                _context.Cities.Add(new City { Name = "SAN JOSE DE LA FRAGUA", StateId = caquetaId });
                _context.Cities.Add(new City { Name = "SAN VICENTE DEL CAGUAN", StateId = caquetaId });
                _context.Cities.Add(new City { Name = "SOLANO", StateId = caquetaId });
                _context.Cities.Add(new City { Name = "SOLITA", StateId = caquetaId });
                _context.Cities.Add(new City { Name = "VALPARAISO", StateId = caquetaId });
                SaveDBChanges();

                int casanareId = _context.States.Single(s => s.Name == "Casanare").StateId;
                _context.Cities.Add(new City { Name = "YOPAL", StateId = casanareId });
                _context.Cities.Add(new City { Name = "AGUAZUL", StateId = casanareId });
                _context.Cities.Add(new City { Name = "CHAMEZA", StateId = casanareId });
                _context.Cities.Add(new City { Name = "HATO COROZAL", StateId = casanareId });
                _context.Cities.Add(new City { Name = "LA SALINA", StateId = casanareId });
                _context.Cities.Add(new City { Name = "MANI", StateId = casanareId });
                _context.Cities.Add(new City { Name = "MONTERREY", StateId = casanareId });
                _context.Cities.Add(new City { Name = "NUNCHIA", StateId = casanareId });
                _context.Cities.Add(new City { Name = "OROCUE", StateId = casanareId });
                _context.Cities.Add(new City { Name = "PAZ DE ARIPORO", StateId = casanareId });
                _context.Cities.Add(new City { Name = "PORE", StateId = casanareId });
                _context.Cities.Add(new City { Name = "RECETOR", StateId = casanareId });
                _context.Cities.Add(new City { Name = "SABANALARGA", StateId = casanareId });
                _context.Cities.Add(new City { Name = "SACAMA", StateId = casanareId });
                _context.Cities.Add(new City { Name = "SAN LUIS DE PALENQUE", StateId = casanareId });
                _context.Cities.Add(new City { Name = "TAMARA", StateId = casanareId });
                _context.Cities.Add(new City { Name = "TAURAMENA", StateId = casanareId });
                _context.Cities.Add(new City { Name = "TRINIDAD", StateId = casanareId });
                _context.Cities.Add(new City { Name = "VILLANUEVA", StateId = casanareId });
                SaveDBChanges();

                int caucaId = _context.States.Single(s => s.Name == "Cauca").StateId;
                _context.Cities.Add(new City { Name = "POPAYAN", StateId = caucaId });
                _context.Cities.Add(new City { Name = "ALMAGUER", StateId = caucaId });
                _context.Cities.Add(new City { Name = "ARGELIA", StateId = caucaId });
                _context.Cities.Add(new City { Name = "BALBOA", StateId = caucaId });
                _context.Cities.Add(new City { Name = "BOLIVAR", StateId = caucaId });
                _context.Cities.Add(new City { Name = "BUENOS AIRES", StateId = caucaId });
                _context.Cities.Add(new City { Name = "CAJIBIO", StateId = caucaId });
                _context.Cities.Add(new City { Name = "CALDONO", StateId = caucaId });
                _context.Cities.Add(new City { Name = "CALOTO", StateId = caucaId });
                _context.Cities.Add(new City { Name = "CORINTO", StateId = caucaId });
                _context.Cities.Add(new City { Name = "EL TAMBO", StateId = caucaId });
                _context.Cities.Add(new City { Name = "FLORENCIA", StateId = caucaId });
                _context.Cities.Add(new City { Name = "GUAPI", StateId = caucaId });
                _context.Cities.Add(new City { Name = "INZA", StateId = caucaId });
                _context.Cities.Add(new City { Name = "JAMBALO", StateId = caucaId });
                _context.Cities.Add(new City { Name = "LA SIERRA", StateId = caucaId });
                _context.Cities.Add(new City { Name = "LA VEGA", StateId = caucaId });
                _context.Cities.Add(new City { Name = "LOPEZ", StateId = caucaId });
                _context.Cities.Add(new City { Name = "MERCADERES", StateId = caucaId });
                _context.Cities.Add(new City { Name = "MIRANDA", StateId = caucaId });
                _context.Cities.Add(new City { Name = "MORALES", StateId = caucaId });
                _context.Cities.Add(new City { Name = "PADILLA", StateId = caucaId });
                _context.Cities.Add(new City { Name = "PAEZ", StateId = caucaId });
                _context.Cities.Add(new City { Name = "PATIA", StateId = caucaId });
                _context.Cities.Add(new City { Name = "PIAMONTE", StateId = caucaId });
                _context.Cities.Add(new City { Name = "PIENDAMO", StateId = caucaId });
                _context.Cities.Add(new City { Name = "PUERTO TEJADA", StateId = caucaId });
                _context.Cities.Add(new City { Name = "PURACE", StateId = caucaId });
                _context.Cities.Add(new City { Name = "ROSAS", StateId = caucaId });
                _context.Cities.Add(new City { Name = "SAN SEBASTIAN", StateId = caucaId });
                _context.Cities.Add(new City { Name = "SANTANDER DE QUILICHAO", StateId = caucaId });
                _context.Cities.Add(new City { Name = "SANTA ROSA", StateId = caucaId });
                _context.Cities.Add(new City { Name = "SILVIA", StateId = caucaId });
                _context.Cities.Add(new City { Name = "SOTARA", StateId = caucaId });
                _context.Cities.Add(new City { Name = "SUAREZ", StateId = caucaId });
                _context.Cities.Add(new City { Name = "SUCRE", StateId = caucaId });
                _context.Cities.Add(new City { Name = "TIMBIO", StateId = caucaId });
                _context.Cities.Add(new City { Name = "TIMBIQUI", StateId = caucaId });
                _context.Cities.Add(new City { Name = "TORIBIO", StateId = caucaId });
                _context.Cities.Add(new City { Name = "TOTORO", StateId = caucaId });
                _context.Cities.Add(new City { Name = "VILLA RICA", StateId = caucaId });
                SaveDBChanges();

                int cesarId = _context.States.Single(s => s.Name == "Cesar").StateId;
                _context.Cities.Add(new City { Name = "VALLEDUPAR", StateId = cesarId });
                _context.Cities.Add(new City { Name = "AGUACHICA", StateId = cesarId });
                _context.Cities.Add(new City { Name = "AGUSTIN CODAZZI", StateId = cesarId });
                _context.Cities.Add(new City { Name = "ASTREA", StateId = cesarId });
                _context.Cities.Add(new City { Name = "BECERRIL", StateId = cesarId });
                _context.Cities.Add(new City { Name = "BOSCONIA", StateId = cesarId });
                _context.Cities.Add(new City { Name = "CHIMICHAGUA", StateId = cesarId });
                _context.Cities.Add(new City { Name = "CHIRIGUANA", StateId = cesarId });
                _context.Cities.Add(new City { Name = "CURUMANI", StateId = cesarId });
                _context.Cities.Add(new City { Name = "EL COPEY", StateId = cesarId });
                _context.Cities.Add(new City { Name = "EL PASO", StateId = cesarId });
                _context.Cities.Add(new City { Name = "GAMARRA", StateId = cesarId });
                _context.Cities.Add(new City { Name = "GONZALEZ", StateId = cesarId });
                _context.Cities.Add(new City { Name = "LA GLORIA", StateId = cesarId });
                _context.Cities.Add(new City { Name = "LA JAGUA DE IBIRICO", StateId = cesarId });
                _context.Cities.Add(new City { Name = "MANAURE", StateId = cesarId });
                _context.Cities.Add(new City { Name = "PAILITAS", StateId = cesarId });
                _context.Cities.Add(new City { Name = "PELAYA", StateId = cesarId });
                _context.Cities.Add(new City { Name = "PUEBLO BELLO", StateId = cesarId });
                _context.Cities.Add(new City { Name = "RIO DE ORO", StateId = cesarId });
                _context.Cities.Add(new City { Name = "LA PAZ", StateId = cesarId });
                _context.Cities.Add(new City { Name = "SAN ALBERTO", StateId = cesarId });
                _context.Cities.Add(new City { Name = "SAN DIEGO", StateId = cesarId });
                _context.Cities.Add(new City { Name = "SAN MARTIN", StateId = cesarId });
                _context.Cities.Add(new City { Name = "TAMALAMEQUE", StateId = cesarId });
                SaveDBChanges();

                int chocoId = _context.States.Single(s => s.Name == "Chocó").StateId;
                _context.Cities.Add(new City { Name = "QUIBDO", StateId = chocoId });
                _context.Cities.Add(new City { Name = "ACANDI", StateId = chocoId });
                _context.Cities.Add(new City { Name = "ALTO BAUDO", StateId = chocoId });
                _context.Cities.Add(new City { Name = "ATRATO", StateId = chocoId });
                _context.Cities.Add(new City { Name = "BAGADO", StateId = chocoId });
                _context.Cities.Add(new City { Name = "BAHIA SOLANO", StateId = chocoId });
                _context.Cities.Add(new City { Name = "BAJO BAUDO", StateId = chocoId });
                _context.Cities.Add(new City { Name = "BELEN DE BAJIRA", StateId = chocoId });
                _context.Cities.Add(new City { Name = "BOJAYA", StateId = chocoId });
                _context.Cities.Add(new City { Name = "EL CANTON DEL SAN PABLO", StateId = chocoId });
                _context.Cities.Add(new City { Name = "CARMEN DEL DARIEN", StateId = chocoId });
                _context.Cities.Add(new City { Name = "CERTEGUI", StateId = chocoId });
                _context.Cities.Add(new City { Name = "CONDOTO", StateId = chocoId });
                _context.Cities.Add(new City { Name = "EL CARMEN DE ATRATO", StateId = chocoId });
                _context.Cities.Add(new City { Name = "EL LITORAL DEL SAN JUAN", StateId = chocoId });
                _context.Cities.Add(new City { Name = "ISTMINA", StateId = chocoId });
                _context.Cities.Add(new City { Name = "JURADO", StateId = chocoId });
                _context.Cities.Add(new City { Name = "LLORO", StateId = chocoId });
                _context.Cities.Add(new City { Name = "MEDIO ATRATO", StateId = chocoId });
                _context.Cities.Add(new City { Name = "MEDIO BAUDO", StateId = chocoId });
                _context.Cities.Add(new City { Name = "MEDIO SAN JUAN", StateId = chocoId });
                _context.Cities.Add(new City { Name = "NOVITA", StateId = chocoId });
                _context.Cities.Add(new City { Name = "NUQUI", StateId = chocoId });
                _context.Cities.Add(new City { Name = "RIO IRO", StateId = chocoId });
                _context.Cities.Add(new City { Name = "RIO QUITO", StateId = chocoId });
                _context.Cities.Add(new City { Name = "RIOSUCIO", StateId = chocoId });
                _context.Cities.Add(new City { Name = "SAN JOSE DEL PALMAR", StateId = chocoId });
                _context.Cities.Add(new City { Name = "SIPI", StateId = chocoId });
                _context.Cities.Add(new City { Name = "TADO", StateId = chocoId });
                _context.Cities.Add(new City { Name = "UNGUIA", StateId = chocoId });
                _context.Cities.Add(new City { Name = "UNION PANAMERICANA", StateId = chocoId });
                SaveDBChanges();

                int cordobaId = _context.States.Single(s => s.Name == "Córdoba").StateId;
                _context.Cities.Add(new City { Name = "MONTERIA", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "AYAPEL", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "BUENAVISTA", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "CANALETE", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "CERETE", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "CHIMA", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "CHINU", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "CIENAGA DE ORO", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "COTORRA", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "LA APARTADA", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "LORICA", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "LOS CORDOBAS", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "MOMIL", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "MONTELIBANO", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "MOÑITOS", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "PLANETA RICA", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "PUEBLO NUEVO", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "PUERTO ESCONDIDO", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "PUERTO LIBERTADOR", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "PURISIMA", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "SAHAGUN", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "SAN ANDRES DE SOTAVENTO", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "SAN ANTERO", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "SAN BERNARDO DEL VIENTO", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "SAN CARLOS", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "SAN PELAYO", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "TIERRALTA", StateId = cordobaId });
                _context.Cities.Add(new City { Name = "VALENCIA", StateId = cordobaId });
                SaveDBChanges();

                int CundinamarcaId = _context.States.Single(s => s.Name == "Cundinamarca").StateId;
                _context.Cities.Add(new City { Name = "AGUA DE DIOS", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "ALBAN", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "ANAPOIMA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "ANOLAIMA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "ARBELAEZ", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "BELTRAN", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "BITUIMA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "BOJACA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "CABRERA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "CACHIPAY", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "CAJICA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "CAPARRAPI", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "CAQUEZA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "CARMEN DE CARUPA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "CHAGUANI", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "CHIA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "CHIPAQUE", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "CHOACHI", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "CHOCONTA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "COGUA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "COTA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "CUCUNUBA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "EL COLEGIO", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "EL PEÑON", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "EL ROSAL", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "FACATATIVA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "FOMEQUE", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "FOSCA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "FUNZA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "FUQUENE", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "FUSAGASUGA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "GACHALA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "GACHANCIPA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "GACHETA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "GAMA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "GIRARDOT", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "GRANADA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "GUACHETA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "GUADUAS", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "GUASCA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "GUATAQUI", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "GUATAVITA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "GUAYABAL DE SIQUIMA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "GUAYABETAL", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "GUTIERREZ", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "JERUSALEN", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "JUNIN", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "LA CALERA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "LA MESA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "LA PALMA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "LA PEÑA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "LA VEGA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "LENGUAZAQUE", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "MACHETA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "MADRID", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "MANTA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "MEDINA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "MOSQUERA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "NARIÑO", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "NEMOCON", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "NILO", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "NIMAIMA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "NOCAIMA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "VENECIA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "PACHO", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "PAIME", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "PANDI", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "PARATEBUENO", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "PASCA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "PUERTO SALGAR", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "PULI", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "QUEBRADANEGRA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "QUETAME", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "QUIPILE", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "APULO", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "RICAURTE", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "SAN ANTONIO DEL TEQUENDAMA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "SAN BERNARDO", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "SAN CAYETANO", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "SAN FRANCISCO", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "SAN JUAN DE RIO SECO", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "SASAIMA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "SESQUILE", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "SIBATE", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "SILVANIA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "SIMIJACA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "SOACHA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "SOPO", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "SUBACHOQUE", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "SUESCA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "SUPATA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "SUSA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "SUTATAUSA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "TABIO", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "TAUSA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "TENA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "TENJO", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "TIBACUY", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "TIBIRITA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "TOCAIMA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "TOCANCIPA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "TOPAIPI", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "UBALA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "UBAQUE", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "VILLA DE SAN DIEGO DE UBATE", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "UNE", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "UTICA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "VERGARA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "VIANI", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "VILLAGOMEZ", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "VILLAPINZON", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "VILLETA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "VIOTA", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "YACOPI", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "ZIPACON", StateId = CundinamarcaId });
                _context.Cities.Add(new City { Name = "ZIPAQUIRA", StateId = CundinamarcaId });
                SaveDBChanges();

            }
        }

        private async Task CheckStatesAsync()
        {
            if (!_context.States.Any())
            {
                //_context.ResetTableIDs("States");
                int colombiaId = _context.Countries.Single(c => c.Name == "Colombia").CountryId;

                _context.States.Add(new State { Name = "Antioquia", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Atlántico", CountryId = colombiaId });
                _context.States.Add(new State { Name = "D.C.", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Bolívar", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Boyacá", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Caldas", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Caquetá", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Cauca", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Cesar", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Córdoba", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Cundinamarca", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Chocó", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Huila", CountryId = colombiaId });
                _context.States.Add(new State { Name = "La Guajira", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Magdalena", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Meta", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Nariño", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Norte de Santander", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Quindio", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Risaralda", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Santander", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Sucre", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Tolima", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Valle del Cauca", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Arauca", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Casanare", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Putumayo", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Archipiélago de San Andrés, Providencia y Santa Catalina", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Amazonas", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Guainía", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Guaviare", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Vaupés", CountryId = colombiaId });
                _context.States.Add(new State { Name = "Vichada", CountryId = colombiaId });
                _context.SaveChanges();
            }
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                //_context.ResetTableIDs("Countries");
                _context.Countries.Add(new Shared.Entities.Country { Name = "Colombia" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Argentina" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Brasil" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Chile" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Perú" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "México" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "España" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Francia" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Italia" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Alemania" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Canadá" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Estados Unidos" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Japón" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Corea del Sur" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Australia" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Nueva Zelanda" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "India" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "China" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Rusia" });
                _context.Countries.Add(new Shared.Entities.Country { Name = "Sudáfrica" });
                _context.SaveChanges();
            }
        }

        public void SaveDBChanges()
        {
            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Error al guardar los cambios en la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        }
    }
}
