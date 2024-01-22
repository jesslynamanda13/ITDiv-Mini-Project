using ITDiv_MiniProject.Model;
using ITDiv_MiniProject.Model.Request;
using ITDiv_MiniProject.Model.Response;
using Microsoft.EntityFrameworkCore;

namespace ITDiv_MiniProject.Helper
{
    public class CategoryHelper
    {
        private readonly CategoryContext _categoryContext;
        public CategoryHelper(CategoryContext categoryContext)
        {
            _categoryContext = categoryContext;
        }

        public List<Category> GetCategories()
        {
            try
            {
                var query = from record in _categoryContext.Categories
                            select record;
                List<Category> categories = query.ToList();
                return categories;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving categories: " + ex.Message);
            }
        }


        public ServerResponse AddCategoryHelper(CategoryRequest request)
        {
            ServerResponse response = new ServerResponse();
            try
            {

                if (request == null)
                {
                    response.statusCode = 400;
                    response.message = "Invalid Request";
                    response.success = false;
                    return response;
                }

                var Category = new Category();
                Category.Name = request.Name;
            

                _categoryContext.Categories.Add(Category);
                _categoryContext.SaveChanges();

                response.statusCode = 200;
                response.message = "Success";
                response.success = true;
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding category: " + ex.Message);
            }
       }

        public ServerResponse EditCategoryHelper(Guid categoryId, CategoryRequest request)
        {
            ServerResponse response = new ServerResponse();
            try
            {
                if (request == null)
                {
                    response.statusCode = 400;
                    response.message = "Invalid Request";
                    response.success = false;
                    return response;
                }

                var category = _categoryContext.Categories.Find(categoryId);
                if (category == null)
                {
                    response.statusCode = 404; 
                    response.message = "Category not found";
                    response.success = false;
                    return response;
                }

                category.Name = request.Name;
                _categoryContext.SaveChanges();

                response.statusCode = 200;
                response.message = "Category updated successfully";
                response.success = true;
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while editing category: " + ex.Message);
            }
        }

        public ServerResponse DeleteCategoryHelper(Guid categoryId)
        {
            ServerResponse response = new ServerResponse();
            try
            {

                var category = _categoryContext.Categories.Find(categoryId);
                if (category == null)
                {
                    response.statusCode = 404;
                    response.message = "Category not found";
                    response.success = false;
                    return response;
                }

                _categoryContext.Categories.Remove(category);
                _categoryContext.SaveChanges();

                response.statusCode = 200;
                response.message = "Category deleted successfully";
                response.success = true;
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting category: " + ex.Message);
            }
        }

    }
}
