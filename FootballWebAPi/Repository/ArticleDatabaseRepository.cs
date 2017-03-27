using System;
using System.Collections.Generic;
using System.Linq;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Repository
{
    public class ArticleDatabaseRepository : IDatabaseRepository<Article>, IDisposable
    {

        private FootballWebSiteDbEntities entities;

        public ArticleDatabaseRepository()
        {
            entities = new FootballWebSiteDbEntities();
        }
        public IEnumerable<Article> Get()
        {
            return entities.Articles.Where(o=>o.deletedDate.HasValue ==false).OrderByDescending(o=>o.creationDate);

        }

        public Article Get(string id)
        {
            return entities.Articles.Where(o => o.deletedDate.HasValue == false).Single(o => o.id.ToString() == id);
        }

        public Article Post(Article article)
        {
            article.id = Guid.NewGuid();
            article.creationDate = DateTime.Now;
            article.publishedDate = DateTime.Now;
            article.publisher = "admin";


            entities.Articles.Add(article);
            entities.SaveChanges();
            return article;

        }

        public Article Put(string id, Article article)
        {
            article.modifiedDate = DateTime.Now;


            var correspondingArticle = entities.Articles.Where(o => o.deletedDate.HasValue == false).Single(o => o.id.ToString() == id);
            correspondingArticle.title = article.title;
            correspondingArticle.body = article.body;
            correspondingArticle.modifiedDate = article.modifiedDate;

            entities.SaveChanges();
            return article;
        }

        public void Delete(string id)
        {
            var correspondingArticle = entities.Articles.Where(o => o.deletedDate.HasValue == false).Single(o => o.id.ToString() == id);
            correspondingArticle.deletedDate =DateTime.Now;
            entities.SaveChanges();
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}