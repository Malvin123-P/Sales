﻿using Microsoft.Extensions.Logging;
using Sales.Dominio.Entities;
using Sales.Dominio.Repository;
using Sales.Infraestructura.Context;
using Sales.Infraestructura.Core;
using Sales.Infraestructura.Extentions;
using Sales.Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using TipoDocumentoVenta = Sales.Dominio.Entities.TipoDocumentoVenta;

namespace Sales.Infraestructura.Repositories
{
    public class TipoDocumentoVentaRepository : BaseRepository<TipoDocumentoVenta>, ITipoDocumentoVentaRepository
    {
        private readonly SalesContext context;
        private readonly ILogger<TipoDocumentoVentaRepository> logger;

        public TipoDocumentoVentaRepository(SalesContext context, ILogger<TipoDocumentoVentaRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override void Save(TipoDocumentoVenta entity)
        {
            try
            {
                if (context.TipoDocumentosVenta.Any(t => t.id == entity.id))
                {
                    this.logger.LogWarning("Ya existe un tipo de documento con el id ingresado.");
                }

                this.context.TipoDocumentosVenta.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al crear el tipo de documento", ex);
            }
        }

        public override void Update(TipoDocumentoVenta entity)
        {
            try
            {
                var documentToUpdate = this.GetEntity(entity.id);

                if (documentToUpdate == null)
                {
                    this.logger.LogWarning("El tipo de documento no existe");
                }

                documentToUpdate.Descripcion = entity.Descripcion;
                documentToUpdate.FechaMod = entity.FechaMod;
                documentToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                documentToUpdate.EsActivo = entity.EsActivo;

                this.context.TipoDocumentosVenta.Update(documentToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al actualizar el tipo de documento", ex);
            }
        }

        public override List<TipoDocumentoVenta> GetEntities()
        {
            return base.GetEntities().Where(ca => !ca.Eliminado).ToList();
        }

        public override TipoDocumentoVenta GetEntity(int id)
        {
            return this.context.TipoDocumentosVenta.Find(id);
        }

        public override bool Exists(Func<TipoDocumentoVenta, bool> filter)
        {
            return base.Exists(filter);
        }

        public override List<TipoDocumentoVenta> FinAll(Func<TipoDocumentoVenta, bool> filter)
        {
            return base.FinAll(filter);
        }
    }
}
