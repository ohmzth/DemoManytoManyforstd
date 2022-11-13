using AutoMapper;
using DemoManytoManyforstd.Interfaces;
using DemoManytoManyforstd.Models;
using DemoManytoManyforstd.ViewModels.TagsViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoManytoManyforstd.Controllers
{
    public class TagsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public TagsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var model = _unitOfWork.Tag.GetAll();
            var vm = _mapper.Map<List<TagViewModel>>(model);
            return View(vm);
        }

        // GET: TagsController/Details/5
        public ActionResult Details(string id)
        {
            var model = _unitOfWork.Tag.GetById(id);
            var vm = _mapper.Map<TagViewModel >(model);
            return View(vm);
        }
        public ActionResult Serach(string Title)
        {
            var model = _unitOfWork.Tag.GetById(Title);
            var vm = _mapper.Map<TagViewModel>(model);
            return View(vm);
        }


        // GET: TagsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTagViewModel vm)
        {
            try
            {
                var model = _mapper.Map<Tag>(vm);
                _unitOfWork.Tag.Insert(model);
                _unitOfWork.Save();
                return RedirectToAction("Index","Tags");
            }
            catch
            {
                return View();
            }
        }

        // GET: TagsController/Edit/5
        public ActionResult Edit(string id)
        {
            var model = _unitOfWork.Tag.GetById(id);
            var vm = _mapper.Map<TagViewModel>(model);
            return View(vm);
        }

        // POST: TagsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TagViewModel vm)
        {
            try
            {
                var model = _mapper.Map<Tag>(vm);
                _unitOfWork.Tag.Update(model);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Tags");
            }
            catch
            {
                return View();
            }
        }

       
         public ActionResult Delete(string id)
        {
             var model = _unitOfWork.Tag.GetById(id);
             var vm = _mapper.Map<TagViewModel>(model);
             return View(vm);
         }

         // POST: TagsController/Delete/5
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Delete(TagViewModel vm)
         {
             try
             {
                 var model = _mapper.Map<Tag>(vm);
                 _unitOfWork.Tag.Delete(model);
                 _unitOfWork.Save();
                 return RedirectToAction("Index", "Tags");
             }
             catch
             {
                 return View();
             }
         }
    }
}
