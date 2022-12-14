using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
namespace ProductsAndCategories.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public class CategoryController : Controller
{
    private ProductsAndCategoriesContext db;

    public CategoryController(ProductsAndCategoriesContext context)
    {
        db = context;
    }

    [HttpGet("/categories")]
    public IActionResult Categories()
    {
        List<Category> AllCategories = db.Categories.ToList();
        ViewBag.Categories = AllCategories;
        return View("AllCategories");
    }

    [HttpPost("/category/new")]
    public IActionResult NewCategory(Category newCategory)
    {
        if(ModelState.IsValid == false)
        {
            return Categories();
        }
        db.Categories.Add(newCategory);
        db.SaveChanges();
        return RedirectToAction("Categories");
    }

    [HttpGet("/categories/{categoryId}")]
    public IActionResult ProdForCat(int categoryId)
    {
        Category? OneCategory = db.Categories
            .Include(c => c.CategoriesWithProducts)
            .ThenInclude(p => p.Product)
            .FirstOrDefault(c => c.CategoryId == categoryId);
        ViewBag.Category = OneCategory;

        ViewBag.NotYetAssoc = db.Products
            .Include(c => c.ProductsWithCategories)
            .ThenInclude(c => c.Category)
            .Where(c => !c.ProductsWithCategories.Any(p => p.CategoryId == categoryId));        
        return View("ProductsForCategories");
    }

    [HttpPost("/category/addproduct/{categoryId}")]
    public IActionResult AddProduct(int categoryId, Association newProduct)
    {
        if(ModelState.IsValid == false)
        {
            return ProdForCat(categoryId);
        }
        newProduct.CategoryId = categoryId;
        db.Associations.Add(newProduct);
        db.SaveChanges();
        return RedirectToAction("ProdForCat", new {categoryId = categoryId});
    }
}