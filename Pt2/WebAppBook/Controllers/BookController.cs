using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using WebAppBook.Models;
using WebAppBook.Models.Dtos;
using WebAppBook.Service.IService;

namespace WebAppBook.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IPubService _pubService;

        public BookController(IBookService bookService, IPubService pubService)
        {
            _bookService = bookService;
            _pubService = pubService;
        }

        [HttpGet]
        public async Task<IActionResult> BookIndex()
        {
            List<BookDto>? list = new();
            ResponseDto? response = await _bookService.GetAllBook();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<BookDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> BookIndex(string searchString)
        {
            List<BookDto>? list = new();
            ViewData["CurrentFilter"] = searchString;
            ResponseDto? responseSearch = await _bookService.SearchBook(searchString);
            ResponseDto? responseBook = await _bookService.GetAllBook();
            if (responseSearch != null && responseSearch.IsSuccess && !string.IsNullOrEmpty(searchString))
            {
                TempData["success"] = "Find Book Successfully !!!";
                list = JsonConvert.DeserializeObject<List<BookDto>>(Convert.ToString(responseSearch.Result));
                return View(list);
            }
            else
            {
                TempData["error"] = "Find Book Failed !!!";
                list = JsonConvert.DeserializeObject<List<BookDto>>(Convert.ToString(responseBook.Result));
                return View(list);
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateBook()
        {
            List<PubDto>? list = new();
            ResponseDto? response = await _pubService.GetAllPub();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<PubDto>>(Convert.ToString(response.Result));
                ViewBag.PubList = list.Select(p => new SelectListItem { Text = p.publisher_name, Value = p.pub_id.ToString() }).ToList();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(BookDto bookDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _bookService.CreateBook(bookDto);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = response?.Message;
                    return RedirectToAction(nameof(BookIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            List<PubDto>? list = new();
            ResponseDto? responsePub = await _pubService.GetAllPub();
            if (responsePub != null && responsePub.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<PubDto>>(Convert.ToString(responsePub.Result));
                ViewBag.PubList = list.Select(p => new SelectListItem { Text = p.publisher_name, Value = p.pub_id.ToString() }).ToList();
            }
            return View(bookDto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBook(int bookId)
        {
            List<PubDto>? list = new();
            ResponseDto? responsePub = await _pubService.GetAllPub();
            if (responsePub != null && responsePub.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<PubDto>>(Convert.ToString(responsePub.Result));
                ViewBag.PubList = list.Select(p => new SelectListItem { Text = p.publisher_name, Value = p.pub_id.ToString() }).ToList();
            }
            ResponseDto? responseBook = await _bookService.GetBook(bookId);
            if (responseBook != null && responseBook.IsSuccess)
            {
                BookDto model = JsonConvert.DeserializeObject<BookDto>(Convert.ToString(responseBook.Result));
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(BookDto bookDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _bookService.UpdateBook(bookDto);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = response?.Message;
                    return RedirectToAction(nameof(BookIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            List<PubDto>? list = new();
            ResponseDto? responsePub = await _pubService.GetAllPub();
            if (responsePub != null && responsePub.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<PubDto>>(Convert.ToString(responsePub.Result));
                ViewBag.PubList = list.Select(p => new SelectListItem { Text = p.publisher_name, Value = p.pub_id.ToString() }).ToList();
            }
            return View(bookDto);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            ResponseDto? response = await _bookService.DeleteBook(bookId);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = response?.Message;
                return RedirectToAction(nameof(BookIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
                return RedirectToAction(nameof(BookIndex));
            }
        }
    }
}
