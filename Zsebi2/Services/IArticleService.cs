using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Zsebi2.DataLayer;
using Zsebi2.Models;

namespace Zsebi2.Services
{
    public interface IArticleService
    {
        Task<PaginatedList<ArticleModel>> GetArticlesByDateDescending(int page, int size);
        Task<ArticleModel> GetArticleById(int id);
        Task SaveArticle(ArticleModel article);
        Task DeleteArticleById(int id);
    }

    class ArticleService : IArticleService
    {
        private readonly SiteContext _context;
        private readonly IMapper _mapper;

        public ArticleService(SiteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<PaginatedList<ArticleModel>> GetArticlesByDateDescending(int page, int size)
        {
            var query = _context.Articles.OrderByDescending(a => a.PublishDate);
            return PaginatedList<ArticleModel>.CreateAsync(query, page, size, 
                q => q.ProjectTo<ArticleModel>(_mapper.ConfigurationProvider));
        }

        public Task<ArticleModel> GetArticleById(int id)
        {
            return _context.Articles
                .Where(m => m.ID == id)
                .ProjectTo<ArticleModel>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public Task SaveArticle(ArticleModel articleModel)
        {
            var article = _mapper.Map<Article>(articleModel);
            var entry =_context.Attach(article);
            if (article.ID > 0)
            {
                entry.State = EntityState.Modified;
            }
            else
            {
                entry.State = EntityState.Added;
            }
            return _context.SaveChangesAsync();
        }

        public async Task DeleteArticleById(int id)
        {
            var entity = await GetArticleById(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}