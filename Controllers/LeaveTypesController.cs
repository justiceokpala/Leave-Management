using AutoMapper;
using Leave_management.Contracts;
using Leave_management.Data;
using Leave_management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_management.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository _repo;
        private readonly IMapper _mapper;

        public LeaveTypesController(ILeaveTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: LeaveTypesController
        public ActionResult Index()
        {
            var leavetypes = _repo.FindAll().ToList();
            var model = _mapper.Map<List<LeaveType>,List<LeaveTypeViewModel>>(leavetypes);
            return View(model);
        }

        // GET: LeaveTypesController/Details/5
        public ActionResult Details(int id)
        {
            if(!_repo.isExists(id))
            {
                return NotFound();
            }
            var leavetype = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeViewModel>(leavetype);
            return View(model);
        }

        // GET: LeaveTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var leaveType = _mapper.Map<LeaveType>(model);
                leaveType.DateCreated = DateTime.Now;
                var isSuccessful = _repo.create(leaveType);
                if (!isSuccessful)
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(model);
                }
                  

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveTypesController/Edit/5
        public ActionResult Edit(int id)
        {

            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var leavetypes = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeViewModel>(leavetypes);
            return View(model);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var leaveType = _mapper.Map<LeaveType>(model);
                var isSuccessful = _repo.Update(leaveType);
                if (!isSuccessful)
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));



            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(model);
            }
            
        }

        // GET: LeaveTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            var leavetype = _repo.FindById(id);
            if (leavetype == null)
            {
                return NotFound();
            }
            var isSuccessful = _repo.Delete(leavetype);
            if (!isSuccessful)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));

        }

        // POST: LeaveTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LeaveTypeViewModel model)
        {
            try
            {
                var leavetype = _repo.FindById(id);
                if (leavetype == null)
                {
                    return NotFound();
                }
                var isSuccessful = _repo.Delete(leavetype);
                if (!isSuccessful)
                {
                    return View(model);
                }

                return RedirectToAction(nameof(Index));

                
                
            }
            catch
            {
                return View(model);
            }
        }
    }
}
