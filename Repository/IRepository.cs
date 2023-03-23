using Profit_Homework_MvC.Models;

namespace Profit_Homework_MvC.Repository
{
	public interface IRepository<TEntity> where TEntity : BaseEntity, new()
	{
		public List<TEntity> GetAll();
		public TEntity GetById(int id);
		public TEntity Add(TEntity entity);
		public void Delete(int id);
		public void Update(TEntity entity, int id);


	}
}
