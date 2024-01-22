﻿using Application.Interfaces;
using Core;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OperacionRepository : IOperacionRepository
    {
        private readonly Db_Connection _dbContext;

        public OperacionRepository(Db_Connection dbContext)
        {
            _dbContext = dbContext;
        }

        public void RegistrarOperacion(Operacion operacion)
        {
            try
            {
                if(operacion == null)
                {
                    throw new ArgumentNullException(nameof(operacion));
                }
                _dbContext.Operaciones.Add(operacion);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Registrar la Operacion: " + ex.Message, ex);
            }
        }
    }
}
