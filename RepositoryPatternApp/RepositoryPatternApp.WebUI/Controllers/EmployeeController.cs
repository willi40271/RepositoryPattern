using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using RepositoryPatternApp.Domain.Abstract;
using RepositoryPatternApp.Domain.Entities;
using RepositoryPatternApp.WebUI.Models.Employee;

namespace RepositoryPatternApp.WebUI.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository repository;

        public EmployeeController(IEmployeeRepository _repository)
        {
            repository = _repository;
        }

        public ActionResult Index()
        {
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();

            //get the list of employees, using the repository, generic GetAll method
            IQueryable<Employee> employeesList = repository.GetAll().AsQueryable();

            //traverse the list, populating the viewmodels value
            //should be done using AutoMapper or equivalent
            foreach (var item in employeesList)
            {
                EmployeeViewModel evm = new EmployeeViewModel
                {
                    EmployeeID = item.EmployeeID,
                    LastName = item.LastName,
                    FirstName = item.FirstName,
                    Title = item.Title,
                    TitleOfCourtesy = item.TitleOfCourtesy,
                    BirthDate = item.BirthDate,
                    HireDate = item.HireDate,
                    Address = item.Address,
                    City = item.City,
                    Region = item.Region,
                    PostalCode = item.PostalCode,
                    Country = item.Country,
                    HomePhone = item.HomePhone,
                    Extension = item.Extension,
                    Photo = item.Photo,
                    Notes = item.Notes,
                    ReportsTo = item.ReportsTo,
                    PhotoPath = item.PhotoPath
                };

                //add each new item
                employees.Add(evm);
            }

            IndexViewModel vm = new IndexViewModel
            {
                Employees = employees
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new EmployeeViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel vm)
        {
            try
            {
                //double check the view has no validation errors
                //in case client side validtion has been compromised
                if (!ModelState.IsValid)
                {
                    return View(vm);
                }

                //populate the entity, from the views form data
                Employee employee = new Employee
                {
                    LastName = vm.LastName,
                    FirstName = vm.FirstName,
                    Title = vm.Title,
                    TitleOfCourtesy = vm.TitleOfCourtesy,
                    BirthDate = vm.BirthDate,
                    HireDate = vm.HireDate,
                    Address = vm.Address,
                    City = vm.City,
                    Region = vm.Region,
                    PostalCode = vm.PostalCode,
                    Country = vm.Country,
                    HomePhone = vm.HomePhone,
                    Extension = vm.Extension,
                    Photo = vm.Photo,
                    Notes = vm.Notes,
                    ReportsTo = vm.ReportsTo,
                    PhotoPath = vm.PhotoPath
                };

                //use the repository to Add the new Entry
                repository.Save(employee);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(vm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee employee = repository.GetById(id);

            //make sure the entity exists
            if (employee == null)
            {
                return RedirectToAction("Index");
            }

            //populate the viewmodels value
            //should be done using AutoMapper or equivalent
            EmployeeViewModel vm = new EmployeeViewModel
            {
                EmployeeID = employee.EmployeeID,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Title = employee.Title,
                TitleOfCourtesy = employee.TitleOfCourtesy,
                BirthDate = employee.BirthDate,
                HireDate = employee.HireDate,
                Address = employee.Address,
                City = employee.City,
                Region = employee.Region,
                PostalCode = employee.PostalCode,
                Country = employee.Country,
                HomePhone = employee.HomePhone,
                Extension = employee.Extension,
                Photo = employee.Photo,
                Notes = employee.Notes,
                ReportsTo = employee.ReportsTo,
                PhotoPath = employee.PhotoPath
            };

            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeViewModel vm)
        {
            try
            {
                //double check the view has no validation errors
                //in case client side validtion has been compromised
                if (!ModelState.IsValid)
                {
                    return View(vm);
                }

                Employee employee = repository.GetById(vm.EmployeeID);

                //make sure the entity exists
                if (employee == null)
                {
                    return View(vm);
                }

                //populate the entity, from the views form data
                employee.LastName = vm.LastName;
                employee.FirstName = vm.FirstName;
                employee.Title = vm.Title;
                employee.TitleOfCourtesy = vm.TitleOfCourtesy;
                employee.BirthDate = vm.BirthDate;
                employee.HireDate = vm.HireDate;
                employee.Address = vm.Address;
                employee.City = vm.City;
                employee.Region = vm.Region;
                employee.PostalCode = vm.PostalCode;
                employee.Country = vm.Country;
                employee.HomePhone = vm.HomePhone;
                employee.Extension = vm.Extension;
                employee.Photo = vm.Photo;
                employee.Notes = vm.Notes;
                employee.ReportsTo = vm.ReportsTo;
                employee.PhotoPath = vm.PhotoPath;

                //use the repository to save the Entry data
                repository.Save(employee);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(vm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Employee employee = repository.GetById(id);

            //make sure the entity exists
            if (employee == null)
            {
                return RedirectToAction("Index");
            }

            //populate the viewmodels value
            //should be done using AutoMapper or equivalent
            EmployeeViewModel vm = new EmployeeViewModel
            {
                EmployeeID = employee.EmployeeID,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Title = employee.Title,
                TitleOfCourtesy = employee.TitleOfCourtesy,
                BirthDate = employee.BirthDate,
                HireDate = employee.HireDate,
                Address = employee.Address,
                City = employee.City,
                Region = employee.Region,
                PostalCode = employee.PostalCode,
                Country = employee.Country,
                HomePhone = employee.HomePhone,
                Extension = employee.Extension,
                Photo = employee.Photo,
                Notes = employee.Notes,
                ReportsTo = employee.ReportsTo,
                PhotoPath = employee.PhotoPath
            };

            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(EmployeeViewModel vm)
        {
            try
            {
                Employee employee = repository.GetById(vm.EmployeeID);

                //make sure the entity exists
                if (employee == null)
                {
                    return View(vm);
                }

                //use the repository to delete the Entry data
                repository.Delete(vm.EmployeeID);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(vm);
            }
        }
    }
}