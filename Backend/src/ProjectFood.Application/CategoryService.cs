using AutoMapper;
using ProjectFood.Application.Dtos;
using ProjectFood.Application.Interfaces;
using ProjectFood.Domain;
using ProjectFood.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFood.Application
{
    public class CategoryService : ICategoryService
    {
        private readonly IPersistence _persistence;
        private readonly ICategoryPersistence _categoryPersistence;
        private readonly IMapper _mapper;

        public CategoryService(IPersistence persistence,
                                ICategoryPersistence categoryPersistence,
                                IMapper mapper
                                )
        {
            _persistence = persistence;
            _categoryPersistence = categoryPersistence;
            _mapper = mapper;
        }

        public async Task<CategoryDto[]> GetAllCategoriesAsync()
        {
            try
            {
                var categories = await _categoryPersistence.GetAllCategoryAsync();
                if (categories == null) return null;

                var categoriesRet = _mapper.Map<CategoryDto[]>(categories);

                return categoriesRet;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            try
            {
                var category = await _categoryPersistence.GetCategoryByIdAsync(id);
                if (category == null) return null;

                var categoryRet = _mapper.Map<CategoryDto>(category);

                return categoryRet;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public async Task<CategoryDto> AddCategories(CategoryDto model)
        {
            try
            {
                var category = _mapper.Map<Category>(model);

                _persistence.Add<Category>(category);

                if (await _persistence.SaveChangeAsync())
                {
                    var ret = await _categoryPersistence.GetCategoryByIdAsync(category.Id);
                    return _mapper.Map<CategoryDto>(ret);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
