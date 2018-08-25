using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FootballWebSiteApi.Entities;
using FootballWebSiteApi.Helpers;
using FootballWebSiteApi.Models;

namespace FootballWebSiteApi.Repository
{
    public class ArticleRepository : IDatabaseRepository<JArticle>, IDisposable
    {

        private FootballWebSiteDbEntities entities;

        public ArticleRepository()
        {
            entities = new FootballWebSiteDbEntities();
        }
        public IEnumerable<JArticle> Get()
        {
            var articles = entities.Articles.Where(o => o.deletedDate.HasValue == false
            && o.ownerId.ToString() == Properties.Settings.Default.OwnerId).OrderByDescending(o => o.creationDate);

            return Mapper.Map(articles);
        }

        public JArticle Get(string id)
        {
            return Mapper.Map(entities.Articles.Where(o => o.deletedDate.HasValue == false).Single(o => o.id.ToString() == id));
        }

        public JArticle Post(JArticle jArticle)
        {
            var article = new Article
            {
                id = Guid.NewGuid(),
                creationDate = DateTime.Now,
                publishedDate = DateTime.Now,
                publisher = "admin",
                ownerId = new Guid(Properties.Settings.Default.OwnerId)
            };

        entities.Articles.Add(article);
            entities.SaveChanges();
            return jArticle;

        }

        public JArticle Put(string id, JArticle article)
        {
            article.modifiedDate = DateTime.Now;

            var correspondingArticle = entities.Articles.Where(o => o.deletedDate.HasValue == false).Single(o => o.id.ToString() == id);
            correspondingArticle.title = article.title;
            correspondingArticle.body = article.body;
            correspondingArticle.modifiedDate = article.modifiedDate;

            entities.SaveChanges();
            return Mapper.Map(correspondingArticle);
        }

        public void Delete(string id)
        {
            var correspondingArticle = entities.Articles.Where(o => o.deletedDate.HasValue == false).Single(o => o.id.ToString() == id);
            correspondingArticle.deletedDate = DateTime.Now;
            entities.SaveChanges();
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}