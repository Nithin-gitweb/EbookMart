using EBookMart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBookMart.Controllers
{
    public class BookShopController : Controller
    {
        // GET: BookShop
        public ActionResult ListBook(int id)
        {
            var bookscontext = new BookData();
            List<BookDb> books = bookscontext.BookDbs.ToList();
            ViewBag.bookdata = books;
            ViewBag.RandomNumber = id;
            return View();
        }
        public ActionResult ReturnPDF(string fileurl)
        {
            return File(fileurl, "application/pdf");
        }
        public ActionResult AddToWishList(int UserId,int BookId)
        {
            WishListContext wishListContext = new WishListContext();
            List<WishList> wishList = wishListContext.WishLists.Where(entity => entity.CustomerId == UserId).ToList();
            bool presence = false;
            foreach(var item in wishList)
            {
                if(item.Bookid == BookId)
                {
                    presence = true;
                    break;
                }
                else
                {
                    presence = false;
                }
            }
            if(presence == true)
            {
                return Content("Book is already available in wishlist. Please go back");
            }
            else
            {
                WishList wishList1 = new WishList { CustomerId = UserId, Bookid = BookId };
                wishListContext.WishLists.Add(wishList1);
                wishListContext.SaveChanges();
                return RedirectToAction("ListBook", new { id = UserId });
            }
        }
        public ActionResult ViewWishList(int UserId)
        {
            WishListContext wishListContext = new WishListContext();
            BookData bookDataContext = new BookData();
            List<WishList> wishLists = wishListContext.WishLists.Where(entity => entity.CustomerId == UserId).ToList();
            List<BookDb> bookDbs = new List<BookDb>();
            if (wishLists != null)
            {
                foreach (var item in wishLists)
                {
                    BookDb bookDb = bookDataContext.BookDbs.SingleOrDefault(entity => entity.id == item.Bookid);
                    bookDbs.Add(bookDb);
                }
            }
            else
            {
                return Content("WishList is Empty");
            }
            ViewBag.userid = UserId;
            return View(bookDbs);
        }
        public ActionResult RemoveFromWishList(int UserId, int BookId)
        {
            try
            {
                WishListContext wishListContext = new WishListContext();
                List<WishList> wishList = wishListContext.WishLists.Where(entity => entity.CustomerId == UserId).ToList();
                foreach(var item in wishList)
                {
                    if(item.Bookid == BookId)
                    {
                        wishListContext.WishLists.Remove(item);
                        wishListContext.SaveChanges();
                        return RedirectToAction("ViewWishList", new { UserId = UserId });
                    }
                }
                return null;
            }
            catch(Exception e)
            {
                return Content("Unable to delete due to " + Convert.ToString(e));
            }
        }
        public ActionResult AddToOrder(int UserId, int BookId)
        {
            Orders ordersContext = new Orders();
            BookData bookDataContext = new BookData();
            List<Order> orders = ordersContext.OrderData.ToList();
            BookDb bookDb = bookDataContext.BookDbs.SingleOrDefault(entity => entity.id == BookId);
            foreach (var item in orders)
            {
                if(item.bookid == BookId && item.customerid == UserId)
                {
                    Order neworder1 = new Order { bookid = BookId, customerid = UserId };
                    ordersContext.OrderData.Add(neworder1);
                    ordersContext.SaveChanges();
                    return RedirectToAction("ReturnPDF", new { fileurl = bookDb.BookLink });
                }
            }
            Order neworder = new Order { bookid = BookId, customerid = UserId };
            ordersContext.OrderData.Add(neworder);
            ordersContext.SaveChanges();
            return RedirectToAction("ReturnPDF", new { fileurl = bookDb.BookLink });

        }
        
        public ActionResult ViewOrders(int UserId)
        {

            Orders ordersContext = new Orders();
            BookData bookDataContext = new BookData();
            List<Order> orders = ordersContext.OrderData.Where(entity => entity.customerid == UserId).ToList();
            List<BookDb> bookDbs = new List<BookDb>();
            if (orders != null)
            {
                foreach (var item in orders)
                {
                    BookDb bookDb = bookDataContext.BookDbs.SingleOrDefault(entity => entity.id == item.bookid);
                    bookDbs.Add(bookDb);
                }
            }
            else
            {
                return Content("WishList is Empty");
            }
            DateTime now = DateTime.Now;
            ViewBag.datetime = now;
            return View(bookDbs);
        }
        public ActionResult RequestSection(int userid)
        {
            ViewBag.userid = userid;
            return View();
        }
        [HttpPost]
        public ActionResult RequestSection(RequestSection request)
        {
            RequestSectionConfig requestSectionContext = new RequestSectionConfig();
            requestSectionContext.RequestSections.Add(request);
            requestSectionContext.SaveChanges();
            return View();
        }
    }
}