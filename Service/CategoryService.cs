using ITDiv_MiniProject.Helper;
using ITDiv_MiniProject.Model;
using ITDiv_MiniProject.Model.Request;
using ITDiv_MiniProject.Model.Response;
using ITDiv_MiniProject.Output;
using Microsoft.AspNetCore.Mvc;

namespace ITDiv_MiniProject.Service
{
    public class CategoryService : ControllerBase
    {
        public CategoryHelper _categoryHelper;

        public CategoryService(CategoryHelper categoryHelper)
        {
            _categoryHelper = categoryHelper;
        }

        [HttpGet]
        [Route("api/categories")]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            try
            {
                List<Category> categories = _categoryHelper.GetCategories();
                return categories;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving categories.", error = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/add-category")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult AddCategory([FromBody] CategoryRequest request)
        {
            CategoryOutput categoryOutput = new CategoryOutput();

            try
            {
                categoryOutput.Categories = _categoryHelper.AddCategoryHelper(request);
                if (categoryOutput.Categories.statusCode == 200)
                {
                    return new OkObjectResult(categoryOutput.Categories);
                }

            }
            catch (Exception ex)
            {
                var errorResponse = new CategoryOutput
                {
                    Categories = new ServerResponse
                    {
                        statusCode = 500,
                        message = "An error occurred while adding the category."
                    }
                };
                return new ObjectResult(errorResponse.Categories)
                {
                    StatusCode = errorResponse.Categories.statusCode
                };
            }
            var specificErrorResponse = new CategoryOutput
            {
                Categories = new ServerResponse
                {
                    statusCode = 400,
                    message = "Category add failed due to a specific reason."
                }
            };
            return new ObjectResult(specificErrorResponse.Categories)
            {
                StatusCode = specificErrorResponse.Categories.statusCode
            };
        }

        [HttpPut]
        [Route("api/edit-category/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult EditCategory([FromRoute] Guid id, [FromBody] CategoryRequest request)
        {
            CategoryOutput categoryOutput = new CategoryOutput();

            try
            {
                categoryOutput.Categories = _categoryHelper.EditCategoryHelper(id, request);
                if (categoryOutput.Categories.statusCode == 200)
                {
                    return new OkObjectResult(categoryOutput.Categories);
                }

            }
            catch (Exception ex)
            {
                var errorResponse = new CategoryOutput
                {
                    Categories = new ServerResponse
                    {
                        statusCode = 500,
                        message = "An error occurred while adding the category."
                    }
                };
                return new ObjectResult(errorResponse.Categories)
                {
                    StatusCode = errorResponse.Categories.statusCode
                };
            }
            var specificErrorResponse = new CategoryOutput
            {
                Categories = new ServerResponse
                {
                    statusCode = 400,
                    message = "Category add failed due to a specific reason."
                }
            };
            return new ObjectResult(specificErrorResponse.Categories)
            {
                StatusCode = specificErrorResponse.Categories.statusCode
            };
        }

        [HttpDelete]
        [Route("api/delete-category/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult DeleteCategory([FromRoute] Guid id)
        {
            CategoryOutput categoryOutput = new CategoryOutput();

            try
            {
                categoryOutput.Categories = _categoryHelper.DeleteCategoryHelper(id);
                if (categoryOutput.Categories.statusCode == 200)
                {
                    return new OkObjectResult(categoryOutput.Categories);
                }

            }
            catch (Exception ex)
            {
                var errorResponse = new CategoryOutput
                {
                    Categories = new ServerResponse
                    {
                        statusCode = 500,
                        message = "An error occurred while adding the category."
                    }
                };
                return new ObjectResult(errorResponse.Categories)
                {
                    StatusCode = errorResponse.Categories.statusCode
                };
            }
            var specificErrorResponse = new CategoryOutput
            {
                Categories = new ServerResponse
                {
                    statusCode = 400,
                    message = "Category add failed due to a specific reason."
                }
            };
            return new ObjectResult(specificErrorResponse.Categories)
            {
                StatusCode = specificErrorResponse.Categories.statusCode
            };
        }
    }
}

