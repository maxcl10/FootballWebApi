using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Xml.Linq;
using WebApplication14.Models;

namespace WebApplication14.Repository
{
    public class ArticleXmlRepository : IDatabaseRepository<Article>, IDisposable
    {
        public IEnumerable<Article> Get()
        {
            var url = HttpContext.Current.Request.MapPath("App_Data\\Articles.xml");
            url = url.Replace("\\api", "");

            XDocument xDoc = XDocument.Load(url);
            var res = xDoc.Descendants("article").Select(p => new Article
            {
                id = new Guid(p.Attribute("id").Value),
                title = p.Element("title")?.Value,
                body = p.Element("body")?.ToString().Replace("<body>", "").Replace("</body>", ""),
                publishedDate = !string.IsNullOrWhiteSpace(p.Element("publishedDate")?.Value) ? DateTime.Parse(p.Element("publishedDate")?.Value) : (DateTime?)null,
                publisher = p.Element("publisher")?.Value
            }).ToList();

            return res.OrderByDescending(o => o.publishedDate);
        }

        public Article Get(string id)
        {
            var url = HttpContext.Current.Request.MapPath("App_Data\\Articles.xml");
            url = url.Replace("\\api\\articles", "");

            XDocument xDoc = XDocument.Load(url);
            var res = xDoc.Descendants("article").Where(o => o.Attribute("id").Value == id).Select(p => new Article
            {
                id = new Guid(p.Attribute("id").Value),
                title = p.Element("title")?.Value,
                body = p.Element("body")?.ToString().Replace("<body>", "").Replace("</body>", ""),
                publishedDate =
                    !string.IsNullOrWhiteSpace(p.Element("publishedDate")?.Value)
                        ? DateTime.Parse(p.Element("publishedDate")?.Value)
                        : (DateTime?)null,
                publisher = p.Element("publisher")?.Value
            }).ToList();

            return res.First();
        }

        public Article Post(Article article)
        {
            article.id = Guid.NewGuid();
            article.publishedDate = DateTime.Now;
            article.publisher = "Admin";


            var url = HttpContext.Current.Request.MapPath("App_Data\\Articles.xml");
            url = url.Replace("\\api", "");

            XElement articleElement = new XElement("article");
            articleElement.Add(new XAttribute("id", article.id));
            articleElement.Add(new XElement("title", article.title));
            articleElement.Add(new XElement("body", article.body));
            articleElement.Add(new XElement("publishedDate", article.publishedDate));
            articleElement.Add(new XElement("publisher", article.publisher));



            XDocument xDoc = XDocument.Load(url);
            xDoc.Element("articles").Add(articleElement);
            xDoc.Save(url);

            return article;
        }

        public Article Put(string id, Article article)
        {
            var url = HttpContext.Current.Request.MapPath("App_Data\\Articles.xml");
            url = url.Replace("\\api\\articles", "");


            XDocument xDoc = XDocument.Load(url);

            var editedArticle = (from item in xDoc.Descendants("article")
                                 where item.Attribute("id").Value == id
                                 select item).First();

            editedArticle.SetElementValue("title", article.title);
            editedArticle.Element("body").SetValue(article.body);

            xDoc.Save(url);

            return article;
        }

        public void Delete(string id)
        {
            var url = HttpContext.Current.Request.MapPath("App_Data\\Articles.xml");
            url = url.Replace("\\api\\articles", "");

            XDocument xDoc = XDocument.Load(url);
            xDoc.Element("articles").Elements("article").Where(o => o.Attribute("id").Value == id).Remove();

            xDoc.Save(url);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}