using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVentas.DAL.Repositorios.Contrato;
using SistemaVentas.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using SistemaVenta.DAL.DBContext;


namespace SistemaVentas.DAL.Repositorios
{
	public class GenericRepository<TModelo>: IGenericRepository<TModelo> where TModelo:class
	{
		private readonly DbVentaTiendaAngularContext _dbcontext;

		//Contructor
		public GenericRepository(DbVentaTiendaAngularContext dbcontext)
		{
			_dbcontext = dbcontext;
		}

		public async Task<TModelo> Obtener(Expression<Func<TModelo, bool>> filtro)
		{
			try
			{
				//Select*from TModelo where filtro
				TModelo modelo = await _dbcontext.Set<TModelo>().FirstOrDefaultAsync(filtro);
				return modelo;

			}
			catch {


				throw;
			
			}
		}

		public async Task<TModelo>Crear(TModelo modelo)
		{
			try
			{
				_dbcontext.Set<TModelo>().Add(modelo);
				//Guardamos los cambios de manera asincrona
				await _dbcontext.SaveChangesAsync();
				return modelo;

			}
			catch {
				throw;
			
			}


		}

		public async Task<bool> Editar(TModelo modelo)
		{
			try
			{

				_dbcontext.Set<TModelo>().Update(modelo);
				await _dbcontext.SaveChangesAsync();
				return true;


			}
			catch {
				throw;
			
			}
		}

		public async Task<bool> Eliminar(TModelo modelo)
		{
			try
			{

				_dbcontext.Set<TModelo>().Remove(modelo);
				await _dbcontext.SaveChangesAsync();
				return true;

			}
			catch {
				throw;
			}
		}

		public async Task<IQueryable<TModelo>>Consultar(Expression<Func<TModelo, bool>> filtro = null)
		{
			try
			{
				//Es una consulta sin ejecutar aun
				IQueryable<TModelo> queryModelo = filtro == null ?
					_dbcontext.Set<TModelo>() : _dbcontext.Set<TModelo>().Where(filtro);
				
				//Al retornar un IQueryable no devolvemos un objeto, devolvemos una instrucción de SQL en construcción
				return queryModelo;


			}
			catch {

				throw;
			}
		}






	}
}
