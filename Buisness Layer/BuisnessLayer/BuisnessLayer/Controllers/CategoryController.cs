using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BuisnessLayer.Models;

namespace BuisnessLayer.Controllers
{
    public class CategoryController : ApiController
    {
        // GET: Category
        CyberShopeeEntities3 entities = new CyberShopeeEntities3();

        // accept get request
        public List<category> getCategories()
        {
            try
            {
                List<category> newCategory = entities.categories.ToList();
                entities.Configuration.LazyLoadingEnabled = false;
                return newCategory;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Accept post request
        public IHttpActionResult postCategory(category data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    category objCategory = entities.categories.Find(data.categoryId);
                    if (objCategory == null)
                    {
                        entities.categories.Add(data);
                        entities.SaveChanges();
                        return Ok(data);
                    }
                    else
                    {
                        return BadRequest("Category id already exist!!");
                    }
                }
                
                
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(data);
        }

        //Accepts put request
        public IHttpActionResult putCategory(category data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    category objCategory = entities.categories.Find(data.categoryId);
                    if (objCategory != null)
                    {
                        objCategory.categoryId = data.categoryId;
                        objCategory.categoryName = data.categoryName;
                        entities.SaveChanges();
                    }

                    return Ok(data);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Accepts delete request
        public IHttpActionResult deleteCategory(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    category deleteObjId = entities.categories.Find(id);
                    if (deleteObjId == null)
                    {
                        return NotFound();
                    }
                    entities.categories.Remove(deleteObjId);
                    entities.SaveChanges();
                    return Ok(deleteObjId);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
