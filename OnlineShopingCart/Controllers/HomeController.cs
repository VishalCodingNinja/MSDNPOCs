	using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagementSystem.Models;
using CustomerManagementSystem.Repositories;
using CustomerManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementSystem.Controllers
{
	public class HomeController : Controller
	{
		//Child Branch
		private readonly IRepositories<Customer> _repository;

		public HomeController(IRepositories<Customer> repository)
		{
			_repository = repository;

		}

		public async Task<ActionResult<IEnumerable<Customer>>> Index()
		{
			var allCustomers = await _repository.GetAll();
			return View("Index", allCustomers);
		}



		public async Task<ActionResult> Details(int id)
		{
			var customer = await _repository.Get(id);
			if (customer == null)
			{
				return RedirectToAction(nameof(Index)); //NotFound();
			}

			return View("Details", customer);
		}

		[HttpGet]
		public IActionResult AddCustomer()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> AddCustomer(Customer customer)
		{
			if (ModelState.IsValid)
			{
				await _repository.Add(customer);
				ViewBag.added = customer.Name + ": is added sucessfull in data base";
				return RedirectToAction("Index");
			}

			return View();

		}

		[HttpGet]
		public async Task<IActionResult> EditCustomer(int id)
		{
			var customer = await _repository.Get(id);

			return View("EditCustomer", customer);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditCustomer(CustomerEditModel customerEdit)
		{
			if (ModelState.IsValid)
			{
				var customerToUpdate = new Customer
				{
					Id = customerEdit.Id,
					Name = customerEdit.Name,
					ItemPurchase = customerEdit.ItemPurchase,
					Address = customerEdit.Address,
					Discount = customerEdit.Discount,
					TotalPurchase = customerEdit.TotalPurchase,
					AddToCartAndDatabase = customerEdit.AddToCartAndDatabase
				};


				await _repository.Update(customerToUpdate);
				return RedirectToAction("Index");
			}

			return View();

		}

	

	public async Task<IActionResult> DeleteCustomer(int id)
	    {
		    var customerToDelete = await _repository.Get(id);

			 _repository.Delete(customerToDelete);
		    return RedirectToAction("Index");
	    }
	}
}