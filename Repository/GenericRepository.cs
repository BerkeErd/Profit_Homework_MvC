using Hangfire;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Profit_Homework_MvC.CacheHelper;
using Profit_Homework_MvC.Data;
using Profit_Homework_MvC.Models;

namespace Profit_Homework_MvC.Repository
{
	public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
	{
		protected readonly Appdbcontext _appdbcontext;
		protected readonly ILogger<GenericRepository<TEntity>> _logger;

        private readonly static CacheTech cacheTech = CacheTech.Memory;
        private readonly string cacheKey = $"{typeof(TEntity)}";
        private readonly Func<CacheTech, ICacheService> _cacheService;

        public GenericRepository(Appdbcontext appdbcontext, ILogger<GenericRepository<TEntity>> logger, Func<CacheTech, ICacheService> cacheService)
        {
			_appdbcontext = appdbcontext;
			_logger = logger;
            _cacheService = cacheService;
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
                
                if (!_cacheService(cacheTech).TryGet(cacheKey, out IReadOnlyList<TEntity> cachedList))
                {
                    cachedList =  _appdbcontext.Set<TEntity>().ToList();
                    _cacheService(cacheTech).Set(cacheKey, cachedList);
                    _logger.LogInformation("Veritabanından Cache'e eklenip geldi");
                }
                _logger.LogInformation("Cache'den geldi");
                return cachedList.ToList();
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
