using System.Collections.Generic;

namespace HalvaWebApplication.Code.Interfaces
{
	public interface IDataEntityRepository<T> where T : IDataEntity
	{
		T Get(int id);
		void Save(T entity);
		void Delete(int id);
		List<T> GetList();
	}
}