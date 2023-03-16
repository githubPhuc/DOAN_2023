using AutoMapper;
using ToolsApp.Models;
using ToolsApp.EntityFramework.QUANLYNHANSU;

namespace ToolsApp.App_Start
{
    public static class Mapper
    {
        private static IMapper _mapper;
        public static void RegisterMappings()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                #region User
                cfg.CreateMap<User, UserViewModel>()
                                .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id))
                                .ForMember(dto => dto.Username, opt => opt.MapFrom(src => src.Username))
                                .ForMember(dto => dto.SalesRepCode, opt => opt.MapFrom(src => src.SalesRepCode))
                                .ForMember(dto => dto.Fullname, opt => opt.MapFrom(src => src.Fullname))
                                .ForMember(dto => dto.Email, opt => opt.MapFrom(src => src.Email))
                                .ForMember(dto => dto.UserCreate, opt => opt.MapFrom(src => src.UserCreate))
                                .ForMember(dto => dto.UserFullnameCreate, opt => opt.MapFrom(src => src.UserFullnameCreate))
                                .ForMember(dto => dto.DatetimeCreate, opt => opt.MapFrom(src => src.DatetimeCreate))
                                .ForMember(dto => dto.UserUpdate, opt => opt.MapFrom(src => src.UserUpdate))
                                .ForMember(dto => dto.UserFullnameUpdate, opt => opt.MapFrom(src => src.UserFullnameUpdate))
                                .ForMember(dto => dto.DatetimeUpdate, opt => opt.MapFrom(src => src.DatetimeUpdate))
                                .ForMember(dto => dto.isDelete, opt => opt.MapFrom(src => src.isDelete))
                                .ForMember(dto => dto.UserDelete, opt => opt.MapFrom(src => src.UserDelete))
                                .ForMember(dto => dto.UserFullnameDelete, opt => opt.MapFrom(src => src.UserFullnameDelete))
                                .ForMember(dto => dto.DatetimeDelete, opt => opt.MapFrom(src => src.DatetimeDelete));

                cfg.CreateMap<UserViewModel, User>()
                                .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id))
                                .ForMember(dto => dto.Username, opt => opt.MapFrom(src => src.Username))
                                .ForMember(dto => dto.SalesRepCode, opt => opt.MapFrom(src => src.SalesRepCode))
                                .ForMember(dto => dto.Fullname, opt => opt.MapFrom(src => src.Fullname))
                                .ForMember(dto => dto.Email, opt => opt.MapFrom(src => src.Email))
                                .ForMember(dto => dto.UserCreate, opt => opt.MapFrom(src => src.UserCreate))
                                .ForMember(dto => dto.UserFullnameCreate, opt => opt.MapFrom(src => src.UserFullnameCreate))
                                .ForMember(dto => dto.DatetimeCreate, opt => opt.MapFrom(src => src.DatetimeCreate))
                                .ForMember(dto => dto.UserUpdate, opt => opt.MapFrom(src => src.UserUpdate))
                                .ForMember(dto => dto.UserFullnameUpdate, opt => opt.MapFrom(src => src.UserFullnameUpdate))
                                .ForMember(dto => dto.DatetimeUpdate, opt => opt.MapFrom(src => src.DatetimeUpdate))
                                .ForMember(dto => dto.isDelete, opt => opt.MapFrom(src => src.isDelete))
                                .ForMember(dto => dto.UserDelete, opt => opt.MapFrom(src => src.UserDelete))
                                .ForMember(dto => dto.UserFullnameDelete, opt => opt.MapFrom(src => src.UserFullnameDelete))
                                .ForMember(dto => dto.DatetimeDelete, opt => opt.MapFrom(src => src.DatetimeDelete));
                #endregion

                #region Page
                cfg.CreateMap<Page, PageViewModel>()
                                .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id))
                                .ForMember(dto => dto.Controler, opt => opt.MapFrom(src => src.Controler))
                                .ForMember(dto => dto.Action, opt => opt.MapFrom(src => src.Action))
                                .ForMember(dto => dto.Code, opt => opt.MapFrom(src => src.Code))
                                .ForMember(dto => dto.Info, opt => opt.MapFrom(src => src.Info))
                                .ForMember(dto => dto.UserCreate, opt => opt.MapFrom(src => src.UserCreate))
                                .ForMember(dto => dto.UserFullnameCreate, opt => opt.MapFrom(src => src.UserFullnameCreate))
                                .ForMember(dto => dto.DatetimeCreate, opt => opt.MapFrom(src => src.DatetimeCreate))
                                .ForMember(dto => dto.UserUpdate, opt => opt.MapFrom(src => src.UserUpdate))
                                .ForMember(dto => dto.UserFullnameUpdate, opt => opt.MapFrom(src => src.UserFullnameUpdate))
                                .ForMember(dto => dto.DatetimeUpdate, opt => opt.MapFrom(src => src.DatetimeUpdate))
                                .ForMember(dto => dto.isDelete, opt => opt.MapFrom(src => src.isDelete))
                                .ForMember(dto => dto.UserDelete, opt => opt.MapFrom(src => src.UserDelete))
                                .ForMember(dto => dto.UserFullnameDelete, opt => opt.MapFrom(src => src.UserFullnameDelete))
                                .ForMember(dto => dto.DatetimeDelete, opt => opt.MapFrom(src => src.DatetimeDelete));

                cfg.CreateMap<PageViewModel, Page>()
                                .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id))
                                .ForMember(dto => dto.Controler, opt => opt.MapFrom(src => src.Controler))
                                .ForMember(dto => dto.Action, opt => opt.MapFrom(src => src.Action))
                                .ForMember(dto => dto.Code, opt => opt.MapFrom(src => src.Code))
                                .ForMember(dto => dto.Info, opt => opt.MapFrom(src => src.Info))
                                .ForMember(dto => dto.UserCreate, opt => opt.MapFrom(src => src.UserCreate))
                                .ForMember(dto => dto.UserFullnameCreate, opt => opt.MapFrom(src => src.UserFullnameCreate))
                                .ForMember(dto => dto.DatetimeCreate, opt => opt.MapFrom(src => src.DatetimeCreate))
                                .ForMember(dto => dto.UserUpdate, opt => opt.MapFrom(src => src.UserUpdate))
                                .ForMember(dto => dto.UserFullnameUpdate, opt => opt.MapFrom(src => src.UserFullnameUpdate))
                                .ForMember(dto => dto.DatetimeUpdate, opt => opt.MapFrom(src => src.DatetimeUpdate))
                                .ForMember(dto => dto.isDelete, opt => opt.MapFrom(src => src.isDelete))
                                .ForMember(dto => dto.UserDelete, opt => opt.MapFrom(src => src.UserDelete))
                                .ForMember(dto => dto.UserFullnameDelete, opt => opt.MapFrom(src => src.UserFullnameDelete))
                                .ForMember(dto => dto.DatetimeDelete, opt => opt.MapFrom(src => src.DatetimeDelete));
                #endregion

                #region Role
                cfg.CreateMap<Role, RoleViewModel>()
                                .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id))
                                .ForMember(dto => dto.RoleName, opt => opt.MapFrom(src => src.RoleName))
                                .ForMember(dto => dto.Code, opt => opt.MapFrom(src => src.Code))
                                .ForMember(dto => dto.UserCreate, opt => opt.MapFrom(src => src.UserCreate))
                                .ForMember(dto => dto.UserFullnameCreate, opt => opt.MapFrom(src => src.UserFullnameCreate))
                                .ForMember(dto => dto.DatetimeCreate, opt => opt.MapFrom(src => src.DatetimeCreate))
                                .ForMember(dto => dto.UserUpdate, opt => opt.MapFrom(src => src.UserUpdate))
                                .ForMember(dto => dto.UserFullnameUpdate, opt => opt.MapFrom(src => src.UserFullnameUpdate))
                                .ForMember(dto => dto.DatetimeUpdate, opt => opt.MapFrom(src => src.DatetimeUpdate))
                                .ForMember(dto => dto.isDelete, opt => opt.MapFrom(src => src.isDelete))
                                .ForMember(dto => dto.UserDelete, opt => opt.MapFrom(src => src.UserDelete))
                                .ForMember(dto => dto.UserFullnameDelete, opt => opt.MapFrom(src => src.UserFullnameDelete))
                                .ForMember(dto => dto.DatetimeDelete, opt => opt.MapFrom(src => src.DatetimeDelete));

                cfg.CreateMap<RoleViewModel, Role>()
                                .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id))
                                .ForMember(dto => dto.RoleName, opt => opt.MapFrom(src => src.RoleName))
                                .ForMember(dto => dto.Code, opt => opt.MapFrom(src => src.Code))
                                .ForMember(dto => dto.UserCreate, opt => opt.MapFrom(src => src.UserCreate))
                                .ForMember(dto => dto.UserFullnameCreate, opt => opt.MapFrom(src => src.UserFullnameCreate))
                                .ForMember(dto => dto.DatetimeCreate, opt => opt.MapFrom(src => src.DatetimeCreate))
                                .ForMember(dto => dto.UserUpdate, opt => opt.MapFrom(src => src.UserUpdate))
                                .ForMember(dto => dto.UserFullnameUpdate, opt => opt.MapFrom(src => src.UserFullnameUpdate))
                                .ForMember(dto => dto.DatetimeUpdate, opt => opt.MapFrom(src => src.DatetimeUpdate))
                                .ForMember(dto => dto.isDelete, opt => opt.MapFrom(src => src.isDelete))
                                .ForMember(dto => dto.UserDelete, opt => opt.MapFrom(src => src.UserDelete))
                                .ForMember(dto => dto.UserFullnameDelete, opt => opt.MapFrom(src => src.UserFullnameDelete))
                                .ForMember(dto => dto.DatetimeDelete, opt => opt.MapFrom(src => src.DatetimeDelete));
                #endregion

                #region Menu
                cfg.CreateMap<Menu, MenuViewModel>()
                                .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id))
                                .ForMember(dto => dto.MenuName, opt => opt.MapFrom(src => src.MenuName))
                                .ForMember(dto => dto.ParentId, opt => opt.MapFrom(src => src.ParentId))
                                .ForMember(dto => dto.PageId, opt => opt.MapFrom(src => src.PageId))
                                .ForMember(dto => dto.Icon, opt => opt.MapFrom(src => src.Icon))
                                .ForMember(dto => dto.OrderNo, opt => opt.MapFrom(src => src.OrderNo))
                                .ForMember(dto => dto.UserCreate, opt => opt.MapFrom(src => src.UserCreate))
                                .ForMember(dto => dto.UserFullnameCreate, opt => opt.MapFrom(src => src.UserFullnameCreate))
                                .ForMember(dto => dto.DatetimeCreate, opt => opt.MapFrom(src => src.DatetimeCreate))
                                .ForMember(dto => dto.UserUpdate, opt => opt.MapFrom(src => src.UserUpdate))
                                .ForMember(dto => dto.UserFullnameUpdate, opt => opt.MapFrom(src => src.UserFullnameUpdate))
                                .ForMember(dto => dto.DatetimeUpdate, opt => opt.MapFrom(src => src.DatetimeUpdate))
                                .ForMember(dto => dto.isDelete, opt => opt.MapFrom(src => src.isDelete))
                                .ForMember(dto => dto.UserDelete, opt => opt.MapFrom(src => src.UserDelete))
                                .ForMember(dto => dto.UserFullnameDelete, opt => opt.MapFrom(src => src.UserFullnameDelete))
                                .ForMember(dto => dto.DatetimeDelete, opt => opt.MapFrom(src => src.DatetimeDelete));

                cfg.CreateMap<MenuViewModel, Menu>()
                                .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id))
                                .ForMember(dto => dto.MenuName, opt => opt.MapFrom(src => src.MenuName))
                                .ForMember(dto => dto.ParentId, opt => opt.MapFrom(src => src.ParentId))
                                .ForMember(dto => dto.PageId, opt => opt.MapFrom(src => src.PageId))
                                .ForMember(dto => dto.Icon, opt => opt.MapFrom(src => src.Icon))
                                .ForMember(dto => dto.OrderNo, opt => opt.MapFrom(src => src.OrderNo))
                                .ForMember(dto => dto.UserCreate, opt => opt.MapFrom(src => src.UserCreate))
                                .ForMember(dto => dto.UserFullnameCreate, opt => opt.MapFrom(src => src.UserFullnameCreate))
                                .ForMember(dto => dto.DatetimeCreate, opt => opt.MapFrom(src => src.DatetimeCreate))
                                .ForMember(dto => dto.UserUpdate, opt => opt.MapFrom(src => src.UserUpdate))
                                .ForMember(dto => dto.UserFullnameUpdate, opt => opt.MapFrom(src => src.UserFullnameUpdate))
                                .ForMember(dto => dto.DatetimeUpdate, opt => opt.MapFrom(src => src.DatetimeUpdate))
                                .ForMember(dto => dto.isDelete, opt => opt.MapFrom(src => src.isDelete))
                                .ForMember(dto => dto.UserDelete, opt => opt.MapFrom(src => src.UserDelete))
                                .ForMember(dto => dto.UserFullnameDelete, opt => opt.MapFrom(src => src.UserFullnameDelete))
                                .ForMember(dto => dto.DatetimeDelete, opt => opt.MapFrom(src => src.DatetimeDelete));
                #endregion





            })
            {

            };
            _mapper = mapperConfiguration.CreateMapper();
        }

        #region User
        public static UserViewModel MapFrom(User data)
        {
            return _mapper.Map<User, UserViewModel>(data);
        }
        public static User MapFrom(UserViewModel data)
        {
            return _mapper.Map<UserViewModel, User>(data);
        }
        public static User MapFrom(UserViewModel data_view, User data_entity)
        {
            return _mapper.Map(data_view, data_entity);
        }
        #endregion

        #region Page
        public static PageViewModel MapFrom(Page data)
        {
            return _mapper.Map<Page, PageViewModel>(data);
        }
        public static Page MapFrom(PageViewModel data)
        {
            return _mapper.Map<PageViewModel, Page>(data);
        }
        public static Page MapFrom(PageViewModel data_view, Page data_entity)
        {
            return _mapper.Map(data_view, data_entity);
        }
        #endregion

        #region Role
        public static RoleViewModel MapFrom(Role data)
        {
            return _mapper.Map<Role, RoleViewModel>(data);
        }
        public static Role MapFrom(RoleViewModel data)
        {
            return _mapper.Map<RoleViewModel, Role>(data);
        }
        public static Role MapFrom(RoleViewModel data_view, Role data_entity)
        {
            return _mapper.Map(data_view, data_entity);
        }
        #endregion

        #region Menu
        public static MenuViewModel MapFrom(Menu data)
        {
            return _mapper.Map<Menu, MenuViewModel>(data);
        }
        public static Menu MapFrom(MenuViewModel data)
        {
            return _mapper.Map<MenuViewModel, Menu>(data);
        }
        public static Menu MapFrom(MenuViewModel data_view, Menu data_entity)
        {
            return _mapper.Map(data_view, data_entity);
        }
        #endregion

    }
}