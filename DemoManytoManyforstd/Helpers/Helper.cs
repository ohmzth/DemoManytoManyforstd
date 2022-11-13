using AutoMapper;
using DemoManytoManyforstd.Models;
using DemoManytoManyforstd.ViewModels.PostsViewModel;
using DemoManytoManyforstd.ViewModels.TagsViewModel;

namespace DemoManytoManyforstd.Helpers
{
    public class Helper: Profile
    {
        
        public Helper() { 
        CreateMap<Tag,TagViewModel>();//show
        CreateMap<CreateTagViewModel, Tag>();//create
        CreateMap<Tag, TagViewModel>().ReverseMap();//edit delete

        CreateMap<Post, PostViewModel>();//show
        CreateMap<Post, PostViewModel>().ReverseMap();//edit delete
        }
        
    }
}
