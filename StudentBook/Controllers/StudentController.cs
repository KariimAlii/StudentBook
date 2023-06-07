using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentBook.BussinessLayer;
using StudentBook.CoreLayer;

namespace StudentBook.PresentationLayer.Controllers
{
    public class StudentController : Controller
    {
        #region Fields & Constructor
        private readonly IStudentManager StudentsManager;
        private readonly IMapper mapper;

        public StudentController(IStudentManager _StudentsManager , IMapper _mapper)
        {
            StudentsManager = _StudentsManager;
            mapper = _mapper;
        }
        #endregion
        #region Actions
        // GET : Student
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PaginationParameters PaginationParameters)
        {
            return View(await StudentsManager.GetPaged(PaginationParameters));
        }
        // GET : Student/Details/:id
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || StudentsManager.GetAll() == null)
                return NotFound();
            var student = await StudentsManager.GetById(id.Value);
            if (student == null)
                return NotFound();
            return View(student);
        }

        // Get : Student/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // Post : Student/Create
        [HttpPost]
        public async Task<IActionResult> Create(StudentAddDto studentDto)
        {
            if (ModelState.IsValid)
            {
                await StudentsManager.Add(studentDto);
                return RedirectToAction(nameof(Index));
            }
            return View(studentDto);
        }
        // GET: Course/Edit/:id
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || StudentsManager.GetAll() == null)
                return NotFound();
            StudentReadDto student = await StudentsManager.GetById(id.Value);
            if (student == null)
                return NotFound();
            return View(mapper.Map<StudentUpdateDto>(student));

        }
        // POST: Course/Edit/:id
        [HttpPost]
        public async Task<IActionResult> Edit(int id , StudentUpdateDto studentDto)
        {
            if (studentDto.Id != id)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await StudentsManager.Update(studentDto);
                }
                catch (DbUpdateConcurrencyException err)
                {
                    if (!StudentsManager.StudentExists(id)) return NotFound();
                    else throw(err);
                }
                return RedirectToAction(nameof(Index));

            }
            return View(studentDto);
        }
        //GET : Student/Delete/:id
        [HttpGet]
        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null || StudentsManager.GetAll() == null)
                return NotFound();
            var student = await StudentsManager.GetById(id.Value);
            if (student == null)
                return NotFound();
            return View(student);
        }
        // POST : Student/Delete/:id
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed (int? id)
        {
            if (id == null || StudentsManager.GetAll() == null)
                return NotFound();
            var student = StudentsManager.GetById(id.Value);
            if (student != null)
            {
                await StudentsManager.Delete(id.Value);
            }
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
