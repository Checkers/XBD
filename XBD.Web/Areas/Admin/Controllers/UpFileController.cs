using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Swift.Net.API;
using System.Text;
using System.Drawing;
using System.Configuration;
using XBD.Web.Utilities;

namespace XBD.Web.Areas.Admin.Controllers
{
    public class UpFileController : Controller
    {
        string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\\Areas\\Admin\\Content\\editor\\net\\upload\\caseimgs\\";

        [HttpPost]
        public ActionResult UpLoadFile(bool isWaterMark=true)
        {
            var f = HttpContext.Request.Files[0];
            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
            var fileName = DateTime.Now.ToFileTime() + new Random().Next(100, 999) + Path.GetExtension(f.FileName);
            f.SaveAs(filePath + fileName);

            if (!isWaterMark) return Json(new DataResult<string> { Data = "/Areas/Admin/Content/editor/net/upload/caseimgs/" + fileName });

            var wi = new Imager();
            var outpath = wi.DrawImage(fileName, AppDomain.CurrentDomain.BaseDirectory + @"Content/image/logo_larger.png", 1,
                 ImagePosition.Center, filePath);

            return Json(new DataResult<string> { Data = "/Areas/Admin/Content/editor/net/upload/caseimgs/" + outpath });
        }




        // 添加图片水印
        public static string addWaterMark(string filepath, string fileName)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(filepath + fileName);
            Bitmap b = new Bitmap(image.Width, image.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(b);
            g.Clear(Color.White);
            g.DrawImage(image, 0, 0, image.Width, image.Height);

            Image watermark = new Bitmap(AppDomain.CurrentDomain.BaseDirectory + @"Content/image/logo.png");

            System.Drawing.Imaging.ImageAttributes imageAttributes = new System.Drawing.Imaging.ImageAttributes();
            System.Drawing.Imaging.ColorMap colorMap = new System.Drawing.Imaging.ColorMap();
            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            System.Drawing.Imaging.ColorMap[] remapTable = { colorMap };
            imageAttributes.SetRemapTable(remapTable, System.Drawing.Imaging.ColorAdjustType.Bitmap);
            float[][] colorMatrixElements = {
             new float[] {1.0f, 0.0f, 0.0f, 0.0f, 0.0f},
             new float[] {0.0f, 1.0f, 0.0f, 0.0f, 0.0f},
             new float[] {0.0f, 0.0f, 1.0f, 0.0f, 0.0f},
             new float[] {0.0f, 0.0f, 0.0f, 0.3f, 0.0f},
             new float[] {0.0f, 0.0f, 0.0f, 0.0f, 1.0f}
            };
            System.Drawing.Imaging.ColorMatrix colorMatrix = new System.Drawing.Imaging.ColorMatrix(colorMatrixElements);
            imageAttributes.SetColorMatrix(colorMatrix, System.Drawing.Imaging.ColorMatrixFlag.Default, System.Drawing.Imaging.ColorAdjustType.Bitmap);
            int xpos = 0;
            int ypos = 0;

            xpos = ((image.Width - watermark.Width) / 2);
            ypos = (image.Height - watermark.Height) / 2;

            g.DrawImage(watermark, new Rectangle(xpos, ypos, watermark.Width, watermark.Height), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, imageAttributes);

            watermark.Dispose();
            imageAttributes.Dispose();


            //保存加水印过后的图片,删除原始图片
            fileName = DateTime.Now.ToFileTime() + new Random().Next(100, 999) + System.IO.Path.GetExtension(fileName);
            b.Save(filepath + fileName);
            b.Dispose();
            image.Dispose();
            if (System.IO.File.Exists(filepath))
                System.IO.File.Delete(filepath);

            return fileName;
        }
    }
}