using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;


namespace SistemaVentas.DAL.Repositorios.Contrato
{
	public interface IGenericRepository<TModel> where TModel : class
	{
		Task<TModel> Obtener(Expression<Func<TModel, bool>> filtro);

		//var producto= await respositorio.Bbtener(p =>p.Id==5);  select * from producto where Id=5

		Task<TModel> Crear(TModel modelo);

		Task<bool> Editar(TModel modelo);

		Task<bool> Eliminar(TModel modelo);

		Task<IQueryable<TModel>>Consultar(Expression<Func<TModel, bool>> filtro = null); 

		//var lista= await respositorio.Consultar (); 

	}
}
