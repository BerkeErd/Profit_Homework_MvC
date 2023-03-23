using Microsoft.EntityFrameworkCore;
using Profit_Homework_MvC.Data;
using Profit_Homework_MvC.Models;

namespace Profit_Homework_MvC.Repository
{
	public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
	{
		protected readonly Appdbcontext _appdbcontext;

        public GenericRepository(Appdbcontext appdbcontext)
        {
			_appdbcontext = appdbcontext;
        }


		public  TEntity Add(TEntity entity)
		{

			 _appdbcontext.Set<TEntity>().Add(entity);
			 _appdbcontext.SaveChanges();
			 return entity;
		}

		public void Delete(int id)
		{
			TEntity obj = new TEntity() { Id = id };
			_appdbcontext.Entry(obj).State = EntityState.Deleted;
		}

		public List<TEntity> GetAll()
		{
			return _appdbcontext.Set<TEntity>().AsNoTracking().ToList();
		}

		public TEntity GetById(int id)
		{
			return _appdbcontext.Set<TEntity>().SingleOrDefault(x => x.Id == id);
		}

		public void Update(TEntity entity, int id)
		{
			_appdbcontext.Set<TEntity>().Update(entity);
			_appdbcontext.SaveChanges();

		}
	}
}
