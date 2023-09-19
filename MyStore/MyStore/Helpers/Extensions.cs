using MyStore.Domain;
using MyStore.Models;
using System.Runtime.CompilerServices;

namespace MyStore.Helpers
{
    public static class Extensions
    {
        public static int CountWords(this string paragraph)
        {
            var words = paragraph.Split(' ');
            return words.Length;
        }

        public static CategoryModel ToCategoryModel(this Category domainObject)
        {
            var model = new CategoryModel();
            model.Categoryid = domainObject.Categoryid;
            model.Categoryname = domainObject.Categoryname;
            model.Description = domainObject.Description;
            return model;
        }

        public static Category ToCategory(this CategoryModel model)
        {
            var category = new Category();
            category.Categoryid = model.Categoryid;
            category.Categoryname = model.Categoryname;
            category.Description = model.Description;
            return category;
        }
    }
}
