using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagazaWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using MagazaWeb.Functions;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagazaWeb.Controllers
{
    [Authorize]
    public class SiparisController : Controller
    {
        private readonly MagazaContext context;
        private readonly UserManager<Kullanici> userManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IServiceProvider serviceProvider;

        public SiparisController(MagazaContext context, UserManager<Kullanici> userManager, IWebHostEnvironment hostingEnvironment, IServiceProvider serviceProvider)
        {
            this.context = context;
            this.userManager = userManager;
            this.hostingEnvironment = hostingEnvironment;
            this.serviceProvider = serviceProvider;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = context.Siparisler.Include(s => s.SiparisUrunleri).Where(x => x.KullaniciId == userId).OrderByDescending(x => x.Tarih).ToList();
            return View(model);
        }

        public FileResult FaturaOlusturStr(int id)
        {
            Siparis model = context.Siparisler.Include(s => s.SiparisUrunleri).FirstOrDefault(x => x.Id == id);
            string icerik = "<div style='font-family:Arial'>Örnek Yazı</div>";

            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(icerik);
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", String.Format("siparis_{0}.pdf", model.Id));
            }
        }

        public FileResult FaturaOlustur(int id)
        {
            Siparis model = context.Siparisler.Include(s => s.SiparisUrunleri).FirstOrDefault(x => x.Id == id);
            string icerik = RenderViewToString(model);

            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(icerik);
                Document pdfDoc = new Document(PageSize.A4, 30f, 30f, 50f, 50f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", String.Format("siparis_{0}.pdf", model.Id));
            }
        }

        public string RenderViewToString(Siparis model)
        {
            var viewEngine = serviceProvider.GetRequiredService<IRazorViewEngine>();
            var viewName = "Fatura"; // Render etmek istediğiniz view'ın adı

            var actionContext = new ActionContext(HttpContext, RouteData, ControllerContext.ActionDescriptor);
            using (var sw = new StringWriter())
            {
                var viewResult = viewEngine.FindView(actionContext, viewName, true);

                if (!viewResult.Success)
                {
                    // View bulunamadı
                    return string.Empty;
                }

                var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = model
                };

                var viewContext = new ViewContext(actionContext, viewResult.View, viewDictionary, new TempDataDictionary(actionContext.HttpContext, serviceProvider.GetRequiredService<ITempDataProvider>()), sw, new HtmlHelperOptions());

                viewResult.View.RenderAsync(viewContext).GetAwaiter().GetResult();
                return sw.ToString();
            }
        }

        public IActionResult Fatura(int id)
        {
            Siparis model = context.Siparisler.Include(s => s.SiparisUrunleri).FirstOrDefault(x => x.Id == id);
            return View(model);
        }


    }
}