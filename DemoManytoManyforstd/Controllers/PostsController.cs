using AutoMapper;
using DemoManytoManyforstd.Interfaces;
using DemoManytoManyforstd.Models;
using DemoManytoManyforstd.ViewModels.PostsViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DemoManytoManyforstd.Controllers
{
    public class PostsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public PostsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var model = _unitOfWork.Post.GetAll();
            var vm = _mapper.Map<List<PostViewModel>>(model);
            return View(vm);
           
        }

        // GET: PostsController/Details/5
        public ActionResult Details(string id)
        {
            var posts = _unitOfWork.Post.GetById(id);
            var tags = _unitOfWork.Tag.GetAll();
            var selectTags = posts.PostTags.Select(x => new Tag()
            {
                Id = x.Tag.Id,
                Title = x.Tag.Title,
            });
            var selectList = new List<SelectListItem>();
            tags.ForEach(i => selectList.Add(new SelectListItem(i.Title, i.Id, selectTags.Select(x => x.Id).Contains(i.Id))));
            var vm = new PostEditViewModel()
            {
                Title = posts.Title,
                Description = posts.Description,
                Tags = selectList
            };
            return View(vm);
        }

        // GET: PostsController/Create
        public ActionResult Create()
        {
            var tagFromRepo = _unitOfWork.Tag.GetAll();
            var selectList = new List<SelectListItem>();
            foreach (var item in tagFromRepo) {
                selectList.Add(new SelectListItem(item.Title, item.Id));
            }
            var vm = new PostCreateViewModel()
            {
                Tags = selectList
            };

            return View(vm);
        }

        // POST: PostsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreateViewModel vm)
        {
            try
            {
                Post post = new Post()
                {
                    Title = vm.Title,
                    Description = vm.Description
                };
                foreach (var item in vm.SelecttedTags) {
                    post.PostTags.Add(new PostTag()
                    {
                        TagId = item
                    });
                }
                _unitOfWork.Post.Insert(post);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostsController/Edit/5
        public ActionResult Edit(string id)
        {
            var posts = _unitOfWork.Post.GetById(id);
            var tags = _unitOfWork.Tag.GetAll();
            var selectTags = posts.PostTags.Select(x => new Tag()
            {
                Id = x.Tag.Id,
                Title = x.Tag.Title,
            });
            var selectList = new List<SelectListItem>();
            tags.ForEach(i => selectList.Add(new SelectListItem(i.Title, i.Id,selectTags.Select(x => x.Id).Contains(i.Id))));
            var vm = new PostEditViewModel()
            {
                Title = posts.Title,
                Description = posts.Description,
                Tags = selectList
            };
            return View(vm);
        }

        // POST: PostsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PostEditViewModel vm)
        {
            try
            {
                var post = _unitOfWork.Post.GetById(vm.Id);
                post.Title = vm.Title;
                post.Description = vm.Description;
                var selectedTags = vm.SelecttedTags;
                var existingTags = post.PostTags.Select(x => x.TagId).ToList();
                var toAdd = selectedTags.Except(existingTags).ToList();
                var toRemove = existingTags.Except(selectedTags).ToList();
                post.PostTags = post.PostTags.Where(x => !toRemove.Contains(x.TagId)).ToList();
                foreach (var item in toAdd) {
                    post.PostTags.Add(new PostTag()
                    {
                        TagId = item,
                        PostId = post.Id

                    });
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostsController/Delete/5
        public ActionResult Delete(string id)
        {
            var post = _unitOfWork.Post.GetById(id);
            var vm = _mapper.Map<PostViewModel>(post);
            return View(vm);
        }

        // POST: PostsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PostViewModel vm)
        {
            try
            {
                var post = _mapper.Map<Post>(vm);
                _unitOfWork.Post.Delete(post);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }
    }
}
