using System;
using System.Linq;
using Devnot.AspnetCore.Sample.Models;

namespace Devnot.AspnetCore.Sample.Domain.Utils
{
    public class DbInitializer
    {

        public static void Initialize(NewsContext context)
        {

            context.Database.EnsureCreated();


            //if (context.Newses.Any())
            //{
            //    return;
            //}
            for (int i = 0; i < 10000000; i++)
            {
                Console.WriteLine(i);
                var news = new[]
                {
                    new News{Category = "Spor",Title = LoremNET.Lorem.Words(10,true,true),Content =  LoremNET.Lorem.Paragraph(25,50),Spot = LoremNET.Lorem.Words(10,30)},
                    new News{Category = "Gündem",Title = LoremNET.Lorem.Words(10,true,true),Content =  LoremNET.Lorem.Paragraph(50,50),Spot = LoremNET.Lorem.Words(20,30)},
                    new News{Category = "Ekonomi",Title = LoremNET.Lorem.Words(10,true,true),Content =  LoremNET.Lorem.Paragraph(25,50),Spot = LoremNET.Lorem.Words(20,30)},
                    new News{Category = "Dünya",Title = LoremNET.Lorem.Words(10,true,true),Content =  LoremNET.Lorem.Paragraph(50,50),Spot = LoremNET.Lorem.Words(20,30)},
                    new News{Category = "Spor",Title = LoremNET.Lorem.Words(10,true,true),Content =  LoremNET.Lorem.Paragraph(50,50),Spot = LoremNET.Lorem.Words(20,30)},
                    new News{Category = "Gündem",Title = LoremNET.Lorem.Words(10,true,true),Content =  LoremNET.Lorem.Paragraph(50,50),Spot = LoremNET.Lorem.Words(20,30)},
                    new News{Category = "Dünya",Title = LoremNET.Lorem.Words(10,true,true),Content =  LoremNET.Lorem.Paragraph(50,50),Spot = LoremNET.Lorem.Words(20,30)}
                };
                context.Newses.AddRange(news);
                context.SaveChanges();
            }

        }
    }
}
