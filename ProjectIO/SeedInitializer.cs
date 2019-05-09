using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositoty;

namespace ProjectIO
{
    class SeedInitializer : DropCreateDatabaseIfModelChanges<ClassContext>
    {
        IList<ClassArt> classArts = new List<ClassArt>();
        public SeedInitializer()
        {
            // putter værdier i db

            classArts.Add(new ClassArt() { picturePath = @"C:\skole\skole\S3\eksamen s3\WorldArtSale\Image\dsb1.jpg"
                                          ,pictureDescription = "noget med et tog"
                                          ,pictureTitel = "DSB 100 AAR"});

            classArts.Add(new ClassArt() { picturePath = @"C:\skole\skole\S3\eksamen s3\WorldArtSale\Image\dsb2.jpg"
                                          ,pictureDescription = "noget med et tog der kører stærkt"
                                          ,pictureTitel = "DSB "});

            classArts.Add(new ClassArt() { picturePath = @"C:\skole\skole\S3\eksamen s3\WorldArtSale\Image\dsb3.jpg"
                                          ,pictureDescription = "et billede af en bro"                                        
                                          ,pictureTitel = "Med DSB og så til Fods"});
        }
        protected override void Seed(ClassContext context)
        {
            foreach (ClassArt classArt in classArts)
            {
                context.classArt.Add(classArt);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
