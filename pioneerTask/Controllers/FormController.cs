using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using pioneerTask.Entities.Model;
using pioneerTask.Enums;
using pioneerTask.Models;
using System.Drawing;

namespace pioneerTask.Controllers
{
    public class FormController : Controller
    {
        private readonly ApplicatioDbContext _dbcontext;

        public FormController(ApplicatioDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public IActionResult Index()
        {
           
           // var categoryViewModels = _unitofwork.Category.GetAll();
           // return View(categoryViewModels); 
            var formViewModels = _dbcontext.Forms;
            return View(formViewModels);
        }

        public IActionResult Create()
        {
            //ViewBag.FormTypes = new SelectList(_dbcontext.FormTypes, "Id", "Name"); // Replace "Name" with the appropriate property of FormType
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//to protact me from cross attack
        public IActionResult Create(Form form)
        {
            form.Created = DateTime.Now;
            form.IsActive = true;
            //if (ModelState.IsValid)
            //{
            _dbcontext.Forms.Add(form);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> DeleteForm(int? id)
        {
            if (id == null)
                return BadRequest();

            var form = await _dbcontext.Forms.FindAsync(id);

            if (form == null)
                return NotFound();

            _dbcontext.Forms.Remove(form);
            _dbcontext.SaveChanges();

           return RedirectToAction("Index");
        }

       

        public IActionResult IndexPreview()
        {

            // var categoryViewModels = _unitofwork.Category.GetAll();
            // return View(categoryViewModels); 
            var previewViewModels = _dbcontext.UserInfos.Include(x=>x.form);
            return View(previewViewModels);
        }
     

        
        public IActionResult Preview()
        {
            var model = _dbcontext.Forms.Where(f => f.IsActive)
                                        .Select(f => new PreviewFormModel
                                        {
                                            FormControlId = f.Id,
                                            FormControlName = f.ControlName,
                                            FormControlType = f.ControlType,
                                            FormControlRequired=f.Isrequired,
                                            FormControlIsActive=f.IsActive
                                        }).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Preview(PreviewSubmitModel model)
        {
            
            foreach(var controlId in model.FormControlId)
            {

               // var file = model.FormControlFileValue.ElementAt(model.FormControlId.IndexOf(controlId));


                _dbcontext.UserInfos.Add(new UserInfo
                {
                    Created = DateTime.Now,
                    FormId = controlId,
                    ControlValue = model.FormControlValue.ElementAt(model.FormControlId.IndexOf(controlId))
                });
            }

            _dbcontext.SaveChanges();


            return Redirect("/form");
        }


        

    }
}
