using Consultorio.Data;
using Consultorio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Services
{
    public class ConsultasSqlService : IConsultasService
    {
        ConsultorioContext context;
        public ConsultasSqlService(ConsultorioContext context)
        {
            this.context = context;
        }

        public List<Consultas> getAll()
        {
            return context.Consultas.Include(c => c.paciente).ToList();
        }
        public bool create(Consultas consultas)
        {
            try
            {
                context.Consultas.Add(consultas);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Consultas get(int? id)
        {
            return context.Consultas.Include(c => c.paciente).FirstOrDefault(p=>p.Id == id);
        }

        public bool update(Consultas c)
        {
            try
            {
                context.Consultas.Update(c);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool delete(int? id)
        {
            try
            {
                context.Consultas.Remove(get(id));
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
