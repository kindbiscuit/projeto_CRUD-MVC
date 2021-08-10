using Consultorio.Models;
using System.Collections.Generic;

namespace Consultorio.Services
{
    public interface IConsultasService
    {
        bool create(Consultas consultas);
        bool delete(int? id);
        Consultas get(int? id);
        List<Consultas> getAll();
        bool update(Consultas c);
    }
}