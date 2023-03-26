using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Profit_Homework_MvC.Data;
using Profit_Homework_MvC.Models;

namespace Profit_Homework_MvC.Repository
{
	public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
	{
		protected readonly Appdbcontext _appdbcontext;
		protected readonly ILogger<GenericRepository<TEntity>> _logger;

        public GenericRepository(Appdbcontext appdbcontext, ILogger<GenericRepository<TEntity>> logger)
        {
			_appdbcontext = appdbcontext;
			_logger = logger;
        }


		public  TEntity Add(TEntity entity)
		{
			try
			{
                _appdbcontext.Set<TEntity>().Add(entity);
                _appdbcontext.SaveChanges();
                return entity;
            }
			catch (Exception e)
			{
				_logger.LogInformation(e.Message);
				return null;
			}
			 
		}

		public void Delete(int id)
		{
            try
            {
                TEntity entityToDelete = _appdbcontext.Set<TEntity>().Single(x => x.Id == id);
                _appdbcontext.Set<TEntity>().Remove(entityToDelete);
                _appdbcontext.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw;
            }
        }

		public List<TEntity> GetAll()
		{
			try
			{
                return _appdbcontext.Set<TEntity>().AsNoTracking().ToList();
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw;
			}
			
		}

		public TEntity GetById(int id)
		{
			try
			{
                return _appdbcontext.Set<TEntity>().Single(x => x.Id == id);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                return null;
            }

        }

		public void Update(TEntity entity, int id)
		{
			try
			{
                _appdbcontext.Set<TEntity>().Update(entity);
                _appdbcontext.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw;
			}
			

		}
	}
}
