using Microsoft.AspNetCore.Mvc;
using Store.Web.Models;
using System.Diagnostics;

namespace Store.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IBookRepository bookRepository;

        public CartController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public IActionResult Add(int id)
        {

            Debug.WriteLine("ID: " + id);

            var book = bookRepository.GetById(id);
            
            Cart cart;

            if (!HttpContext.Session.TryGetCart(out cart))
                cart = new Cart();

            if (cart.Items.ContainsKey(id))
            {
                Debug.WriteLine("CONTAINS " + id);
                cart.Items[id]++; 
            }
            else
            {
                Debug.WriteLine("Not CONTAINS " + id);
                cart.Items[id] = 1;
            }


            

            cart.Amount += book.Price;
            Debug.WriteLine("cart.Items[id]: " + cart.Items[id]);
            Debug.WriteLine("cart.Amount: " + cart.Amount);

            HttpContext.Session.Set(cart);

            return RedirectToAction("Index", "Book", new { id });
        }
    }
}
