using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.Pl.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        // private readonly IDepartmentRepository _unitOfWork.DepartmentRepository;

        public DepartmentController(IUnitOfWork unitOfWork)
        // Ask Clr For Creating Object  From Class Implementing  Interface
        {
            _unitOfWork = unitOfWork;
            // _departmentRepository = departmentRepository;
            // _departmentRepository = new DepartmentRepository();
        }
        #region Actions
        // BaseUrl /Department/Index
        public  async Task <IActionResult> Index()
        {
            var department = await _unitOfWork.DepartmentRepository.GetAllAsync();
            //1- ViewData=> [Dictionary]
            //.netFramework 3.5
            //ViewData["Message"] = "Hello From ViewData";
            //// ViewBage => Dynamic Property [Based On Dynamic KeyWord]
            //// TransferData From Controller[Action] To It is View
            ////.Net FrameWork 4.0
            //ViewBag.Message = "Hello From View Bag";
            return View(department);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public  async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)// Server Side Validations
            {

                _unitOfWork.DepartmentRepository.AddAsync(department);
                int Result =  await _unitOfWork.CompleteAsync();
                //3- TempData=> Dictionary 
                // Transfer Data From Action To Action
                if (Result > 0)
                {
                    TempData["Message"] = "Department Is Created";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
        // BaseUrl / Department / Details
        public  async Task<IActionResult> Details(int? id, string ViewName = "Details")

        {
            if (id is null)
                return BadRequest();// Status Code 400

            var department =  await _unitOfWork.DepartmentRepository.GetByIdAsync(id.Value);
            if (department is null)
                return NotFound();

            return View(ViewName, department);

        }

        [HttpGet]
        public async Task< IActionResult> Edit(int? id)
        {
            //if (id is null)
            //    return BadRequest();
            //var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
            //if (department is null)
            //    return NotFound();
            //return View(department);
            return await Details(id, "Edit");
        }
        [HttpPost]
        public  IActionResult Edit(Department department, [FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.DepartmentRepository.Update(department);
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {
                    //1- Log Exceptions
                    // 2- Form
                    ModelState.AddModelError(string.Empty, ex.Message);

                }

            }
            return View(department);
        }
        public async  Task<IActionResult> Delete(int? id)
        {
            return  await Details(id, "Delete");
        }
        [HttpPost]
        public IActionResult Delete(Department department, [FromRoute] int id)
        {
            if ((id != department.Id))
            {
                return BadRequest();
            }
            try
            {
                _unitOfWork.DepartmentRepository.Delete(department);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                return View(department);
            }
        }
        #endregion


    }


}
