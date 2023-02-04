using Exercise4_Digg_Webshop.Data;
using Exercise4_Digg_Webshop.Models;
using Exercise4_Digg_Webshop.Models.ViewModels;
using Exercise4_Digg_Webshop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Exercise4_Digg_Webshop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IProductService _service;
        private readonly AppDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminController(IProductService service, AppDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        //The Login Screen
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }
            var user = await _userManager.FindByEmailAsync(loginVM.EmailAdress);

            if(user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("EditProducts", "Admin");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(loginVM);

            }
            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginVM);
        }

        //The Main Admin View
        public IActionResult EditProducts()
        {
            var products = _service.GetAll();
            return View(products);
        }


        //The Delete Confirm View
        public IActionResult DeleteConfirm(Guid id)
        {
            var product = _service.GetProduct(id);
            return View(product);
        }

        //Delete Action
        public IActionResult Delete(Guid id)
        {
            var product = _service.GetProduct(id);
            if(product == null)
            {
                return View("NotFound");
            }
            _service.DeleteProduct(product);

            return RedirectToAction(nameof(EditProducts));

        }

        //The Product View
        public IActionResult View(Guid id)
        {
            var product = _service.GetProduct(id);
            if (product == null)
            {
                return View("NotFound");
            }
            return View(product);
        }

        //The Edit Product View
        public IActionResult Edit(Guid id)
        {
            var product = _service.GetProduct(id);
            if(product == null)
            {
                return View("NotFound");
            }
            return View(product);
        }
        //Edit Action
        [HttpPost]
        public IActionResult Edit(Guid id, [Bind("Id,ProductName,ProductDescription,ProductCategory,ImageUrl,Rating,BasePrice,PromotionPrice")] Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _service.UpdateProduct(id, product);
            return RedirectToAction(nameof(EditProducts));
        }


        //The Add Product View
        public IActionResult Add()
        {
            return View();
        }

        //Add Action
        [HttpPost]
        public IActionResult Add([Bind("Id,ProductName,ProductDescription,ProductCategory,ImageUrl,Rating,BasePrice,PromotionPrice")]Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _service.AddProduct(product);
            return RedirectToAction(nameof(EditProducts));
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }

    }
}
