using E_Market.Core.Application.Interfaces.Services;
using E_Market.Core.Application.ViewModel.Categories;
using E_Market.Core.Application.ViewModel.Comercials;
using E_Market.Core.Domain.Entities;
using E_Market.Midelware;
using Microsoft.AspNetCore.Mvc;

namespace E_Market.Controllers
{
    public class ComercialController : Controller
    {

        private readonly IComercialServices _cm;
        private readonly ICategoriesServices _categories;
        private readonly UserSessionValidationcs _userSessionValidations;

        public ComercialController(IComercialServices cm, ICategoriesServices cs,UserSessionValidationcs us) 
        {
            _cm = cm;
            _userSessionValidations = us;
            _categories = cs;
        }

        public async Task<IActionResult> Index()
        {
            if (!_userSessionValidations.hasUser())
            {
                return RedirectToRoute(new { controller = "Users", action = "logging" });
            }

            ViewBag.Categories = await _categories.GetAll();

            return View(await _cm.GetAll());
        }

        //create
        public async Task<IActionResult> Create()
        {
            if (!_userSessionValidations.hasUser())
            {
                return RedirectToRoute(new { controller = "Users", action = "logging" });
            }

            SaveComercialViewModel cvm = new();
            cvm.categories = await _categories.GetAll();

            return View("SaveComercial", cvm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveComercialViewModel scvm)
        {
            if (!_userSessionValidations.hasUser())
            {
                return RedirectToRoute(new { controller = "Users", action = "logging" });
            }

            //if (!ModelState.IsValid) 
            //{
            //    scvm.categories = await _categories.GetAll();

            //    return View("SaveComercial", scvm);
            //}

            scvm.comercialImage1 = " ";
            scvm.comercialImage2 = " ";//no es una solucion pero tengo que dormir :)
            scvm.comercialImage3 = " ";
            scvm.comercialImage4 = " ";

            SaveComercialViewModel comercialVM = await _cm.Add(scvm);
            if (comercialVM != null && comercialVM.id != 0) 
            {
                comercialVM.comercialImage1 = UploadFile(scvm.file1, comercialVM.id);

                if (scvm.file2 != null) 
                {
                    comercialVM.comercialImage2 = UploadFile(scvm.file2, comercialVM.id);
                }

                if (scvm.file3 != null)
                {
                    comercialVM.comercialImage3 = UploadFile(scvm.file3, comercialVM.id);
                }

                if (scvm.file4 != null)
                {
                    comercialVM.comercialImage4 = UploadFile(scvm.file4, comercialVM.id);
                }

                await _cm.Update(comercialVM);
            }

            return RedirectToRoute(new { controller = "Comercial", action = "Index" });
        }

        //edit
        public async Task<IActionResult> Edit(int id)
        {
            if (!_userSessionValidations.hasUser())
            {
                return RedirectToRoute(new { controller = "Users", action = "logging" });
            }

            SaveComercialViewModel cvm = await _cm.GetById(id);
            cvm.categories = await _categories.GetAll();

            return View("SaveComercial", cvm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveComercialViewModel scvm)
        {
            if (!_userSessionValidations.hasUser())
            {
                return RedirectToRoute(new { controller = "Users", action = "logging" });
            }

            //if (!ModelState.IsValid)
            //{
            //    scvm.categories = await _categories.GetAll();

            //    return View("SaveComercial", scvm);
            //}


            SaveComercialViewModel comercialEditVM = await _cm.GetById(scvm.id);

            scvm.comercialImage1 = UploadFile(scvm.file1, comercialEditVM.id, true, comercialEditVM.comercialImage1);

            if (scvm.file2 != null)
            {
                scvm.comercialImage2 = UploadFile(scvm.file2, comercialEditVM.id, true, comercialEditVM.comercialImage2);
            }

            if (scvm.file3 != null)
            {
                scvm.comercialImage3 = UploadFile(scvm.file3, comercialEditVM.id, true, comercialEditVM.comercialImage3);
            }

            if (scvm.file4 != null)
            {
                scvm.comercialImage4 = UploadFile(scvm.file4, comercialEditVM.id, true, comercialEditVM.comercialImage3);
            }





            await _cm.Update(scvm);
            return RedirectToRoute(new { controller = "Comercial", action = "Index" });
        }

        //delete
        public async Task<IActionResult> Delete(int id)
        {
            
            if (!_userSessionValidations.hasUser())
            {
                return RedirectToRoute(new { controller = "Users", action = "logging" });
            }


            return View(await _cm.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(SaveComercialViewModel scvm)
        {
            if (!_userSessionValidations.hasUser())
            {
                return RedirectToRoute(new { controller = "Users", action = "logging" });
            }

            string path = $"/img/comercials/{scvm.id}";
            string path2 = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{path}");

            if (Directory.Exists(path2)) 
            {
                DirectoryInfo dInfo = new DirectoryInfo(path2);

                //delete the file
                foreach (FileInfo i in dInfo.GetFiles()) 
                {
                    i.Delete();
                }

                //delete the folder
                foreach (DirectoryInfo i in dInfo.GetDirectories())
                {
                    i.Delete(true);
                }

                Directory.Delete(path2);
            }

            await _cm.Delete(scvm);
            return RedirectToRoute(new { controller = "Comercial", action = "Index" });
        }

        //comercial add method
        private string UploadFile(IFormFile file, int id, bool edit = false, string url = "") 
        {

            if (edit && file == null) 
            {
                return url;
            }

            //path
            //get directory path
            string basePath = $"/img/comercials/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            //create folder if that not exits
            if (!Directory.Exists(path)) 
            {
                Directory.CreateDirectory(path);
            }

            //get file path
            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new(file.FileName);
            string fileName = guid + fileInfo.Extension;

            //combine path
            string fileUltraBiggerMamalonPath = Path.Combine(path, fileName);

            using (var strean = new FileStream(fileUltraBiggerMamalonPath, FileMode.Create)) 
            {
                file.CopyTo(strean);
            }

            if (edit) 
            {
                string[] divideImg = url.Split("/");
                string lastSplit = divideImg[^1];
                string deleteUrl = Path.Combine(path, lastSplit);

                if (System.IO.File.Exists(deleteUrl)) 
                {
                    System.IO.File.Delete(deleteUrl);
                }
            }

            return $"{basePath}/{fileName}";
        }
    }
}
